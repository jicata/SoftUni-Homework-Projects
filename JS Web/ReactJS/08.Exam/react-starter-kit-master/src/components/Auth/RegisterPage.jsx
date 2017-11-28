import React, { Component } from 'react';
import Input from '../common/Input';
import { register } from '../../api/remote';
import { withRouter } from 'react-router-dom'
import Errors from '../common/Errors'

class RegisterPage extends Component {
    constructor(props) {
        super(props);

        this.state = {
            name: '',
            email: '',
            password: '',
            repeat: '',
            еrror: false
        };

        this.onChangeHandler = this.onChangeHandler.bind(this);
        this.onSubmitHandler = this.onSubmitHandler.bind(this);
    }

    onChangeHandler(e) {
        this.setState({ [e.target.name]: e.target.value });
    }

    async onSubmitHandler(e) {
        e.preventDefault();
        if (this.state.password !== this.state.repeat) {
            let error = {
                message: 'Check the form for errors',
                errors: { confirm: "Passwords don't match" }
            }
            this.setState({ error: error });
            return;
        }
        const response = await register(this.state.name, this.state.email, this.state.password);
        if (!response.success) {
            this.setState({ error: response })
            return;
        }
        this.props.history.push('/login');
    }

    render() {
        let errors = null;
        if (this.state.error) {
            errors = (
                <Errors error={this.state.error} />
            )
        } 
        return (
            <div className="container">
                <div className="row space-top">
                    <div className="col-md-12">
                        <h1>Register</h1>
                    </div>
                </div>
                {errors}
                <form onSubmit={this.onSubmitHandler}>
                    <div className="row space-top">
                        <div className="col-md-3">
                                <Input
                                    name="name"
                                    value={this.state.name}
                                    onChange={this.onChangeHandler}
                                    label="Username"
                                />
                                <Input
                                    name="email"
                                    value={this.state.email}
                                    onChange={this.onChangeHandler}
                                    label="E-mail"
                                />
                                <Input
                                    name="password"
                                    type="password"
                                    value={this.state.password}
                                    onChange={this.onChangeHandler}
                                    label="Password"
                                />
                                <Input
                                    name="repeat"
                                    type="password"
                                    value={this.state.repeat}
                                    onChange={this.onChangeHandler}
                                    label="Repeat password"
                                />
                            <input type="submit" className="btn btn-secondary" value="Login" />
                        </div>
                    </div>
                </form>
            </div>
        );
    }
}

export default withRouter(RegisterPage);