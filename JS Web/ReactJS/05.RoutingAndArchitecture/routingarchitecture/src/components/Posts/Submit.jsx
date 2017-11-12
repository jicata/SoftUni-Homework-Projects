import React, { Component } from 'react'
import Input from './../formComponents/Input'

export default class Submit extends Component {
    constructor(props) {
        super(props)
        this.submitSubmit = this.submitSubmit.bind(this);
    }

    submitSubmit(e) {
        e.preventDefault();
        console.log(this.state);
    }

    render() {
        return (
            <section id="viewSubmit">
                <div className="submitArea">
                    <h1>Submit Link</h1>
                    <p>Please, fill out the form. A thumbnail image is not required.</p>
                </div>
                <div className="submitArea formContainer">
                    <form id="submitForm" className="submitForm" onSubmit={this.submitSubmit}>
                        <Input data="url"
                            name="Link URL:"
                            type="text"
                            onChangeFunc={(e) => this.setState({ linkUrl: e.target.value })} />
                        <Input data="title"
                            name="Title"
                            type="text"
                            onChangeFunc={(e) => this.setState({ title: e.target.value })} />
                        <Input data="image"
                            name="Thumbnal Image Link (optional)"
                            type="text"
                            onChangeFunc={(e) => this.setState({ image: e.target.value })} />
                        <Input data="comment"
                            name="Comment (optional)"
                            type="text"
                            onChangeFunc={(e) => this.setState({ comment: e.target.value })} />
                        <input id="btnSubmitPost" value="Submit" type="submit" />
                    </form>
                </div>
            </section>
        )
    }
}