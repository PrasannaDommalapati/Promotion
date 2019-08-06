import React, { Component } from "react";
import './DropZone.scss'
import { Input } from 'reactstrap'

class DropZone extends Component {
    constructor(props) {
        super(props);
        this.state = { highLight: false, files: [] };
        this.fileInputRef = React.createRef();

        this.openFileDialog = this.openFileDialog.bind(this);
        this.onFilesAdded = this.onFilesAdded.bind(this);
        this.onDragOver = this.onDragOver.bind(this);
        this.onDragLeave = this.onDragLeave.bind(this);
        this.onDrop = this.onDrop.bind(this);
        this.readFile = this.readFile.bind(this);
    }

    readFile = event => {
        event.preventDefault();
        const files = event.target.files;
        let filesArray = this.fileListToArray(files);
        this.setState({ files: filesArray });
    };

    openFileDialog = () => {
        if (this.props.disabled) return;
        this.fileInputRef.current.click();
    };

    onFilesAdded = event => {
        if (this.props.disabled) return;

        let filesArray = this.fileListToArray(event.target.files);
        this.setState({ files: filesArray, highLight: false });
    };

    onDragOver = evt => {
        evt.preventDefault();
        if (this.props.disabled) return;
        this.setState({ highLight: true });
    };

    onDragLeave = () => this.setState({ highLight: false });

    onDrop = event => {
        if (this.props.disabled) return;
        console.log(event.target.files)
        const files = event.target.files;
        let filesArray = this.fileListToArray(files);
        this.setState({ files: filesArray, highLight: false });
    };

    fileListToArray = list => {
        let array = [];
        for (var i = 0; i < list.length; i++) {
            array.push(list.item(i));
        }
        return array;
    };

    handleSubmit = event => {

        const files = this.state.files;

        let reader = new FileReader();
        reader.readAsText(files[0]);

        reader.onload = async () => {
            let base64Data = new Buffer.from(reader.result).toString('base64');

            let filenameExt = files[0].name;
            let fileName = filenameExt.split(".")[0]

            let body = {
                requesterId: fileName,
                data: base64Data,
                businessApplication: "SIGMA",
                businessUnit: "SALES",
                templates: ["HAGQUR01"]

            };

            await fetch('/api/promotion/request', {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(body)
            });
        };
    };

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <div
                    className={`Dropzone ${this.state.highLight ? "Highlight" : ""} mb-5`}
                    onDragOver={this.onDragOver}
                    onDragLeave={this.onDragLeave}
                    onDrop={this.onDrop}
                    onClick={this.openFileDialog}
                    style={{ cursor: this.props.disabled ? "default" : "pointer" }}
                >
                    <input
                        ref={this.fileInputRef}
                        className="FileInput"
                        type="file"
                        multiple
                        onChange={this.onFilesAdded}
                    />
                    <span>
                        {this.state.files.length === 0 && "Click here to upload!"}

                        {this.state.files.length !== 0 && this.state.files.map((acceptedFile, i) => (
                            <div key={i}>{acceptedFile}</div>
                        ))}
                    </span>
                </div>
            </form>
        );
    }
}

export default DropZone;
