import React from 'react';
import fetch from 'isomorphic-fetch';

export default class Upload extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            loggedIn: true
        };
    }

    handleChange = (e) => {

        let files = e.target.files;
        let reader = new FileReader();
        reader.readAsText(files[0]);
        let filenameExt = files[0].name;
        let fileName = filenameExt.split(".")[0];

        reader.onload = async () => {
            let base64Data = new Buffer.from(reader.result).toString('base64');
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

    handleClick = () => {
        this.props.history.push('/login')
    };

    render() {
        return (
            <div>
                <h2>Dashboard</h2>

                <input type="file" name="file" onChange={this.handleChange} accept=".xml" />
            </div>);
    }
}