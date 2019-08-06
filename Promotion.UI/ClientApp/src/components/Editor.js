import React, { Component } from 'react'
import CKEditor from '@ckeditor/ckeditor5-react';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';

class Editor extends Component {
    render() {
        return (
            <div className="App">
                <CKEditor
                    editor={ ClassicEditor }
                    data="<p>Please write the description.</p>"
                    onChange={ ( event, editor ) => {
                        const data = editor.getData();
                        console.log( { event, editor, data } );
                    } }
                />
            </div>
        );
    }
}

export default Editor;