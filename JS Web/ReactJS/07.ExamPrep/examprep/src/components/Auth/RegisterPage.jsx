import React, { Component } from 'react';
import Input from './Input';
import { register } from '../../api/remote'

export default class RegisterPage extends Component {
    constructor(props) {
        super(props)

        this.state = {
            name: '',
            email: '',
            password: '',
            repeat: ''
        }
        this.onChangeHandler = this.onChangeHandler.bind(this);
        this.onSubmitHandler = this.onSubmitHandler.bind(this);
    }

    onChangeHandler(e) {
        this.setState({ [e.target.name]: e.target.value });
    }

    async onSubmitHandler(e) {
        e.preventDefault();
        console.log(this.state)
        let response = await register(
            this.state.name,
            this.state.email,
            this.state.password);
        let json = await response.json();
        console.log(json);
    }

    render() {
        return (
            <div>
                <div className="row space-top">
                    <div className="col-md-12">
                        <h1>Register</h1>
                        <p>Please fill all fields.</p>
                    </div>
                </div>
                <form onSubmit={this.onSubmitHandler}>
                    <div className="row space-top">
                        <div className="col-md-4">
                            <Input name="name"
                                value={this.state.name}
                                onChange={this.onChangeHandler}
                                label="Name"
                            />
                            <Input name="email"
                                value={this.state.email}
                                onChange={this.onChangeHandler}
                                label="E-mail"
                            />
                            <Input name="password"
                                value={this.state.password}
                                onChange={this.onChangeHandler}
                                label="Password"
                                type="password"
                            />
                            <Input name="repeat"
                                value={this.state.repeat}
                                onChange={this.onChangeHandler}
                                label="Password"
                                type="password"
                            />
                            <input type="submit" className="btn btn-primary" value="Register" />
                        </div>
                    </div>
                </form>
            </div >
        )
    }
}