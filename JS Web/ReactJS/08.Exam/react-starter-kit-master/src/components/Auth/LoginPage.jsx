import React, { Component } from 'react';
import Input from '../common/Input';
import Errors from '../common/Errors'
import { login } from '../../api/remote';
import { withRouter } from 'react-router-dom';

class LoginPage extends Component {
    constructor(props) {
        super(props);

        this.state = {
            email: '',
            password: '',
            error: false
        };

        this.onChangeHandler = this.onChangeHandler.bind(this);
        this.onSubmitHandler = this.onSubmitHandler.bind(this);
    }

    onChangeHandler(e) {
        this.setState({ [e.target.name]: e.target.value });
    }

    async onSubmitHandler(e) {
        e.preventDefault();
        let response = await login(this.state.email, this.state.password);
        if (!response.success) {
            this.setState({ error: response })
            return;
        }
        localStorage.setItem('authToken', response.token);
        localStorage.setItem('user', response.user.name);
        console.lo

        this.props.history.push('/')

    }

    render() {
        let errors = null;
        if (this.state.error) {
            if (this.state.error.errors) {
                errors = (
                    <Errors error={this.state.error} />
                )
            } else {
                errors = (
                    <p className="errorMessage">{this.state.error.message}</p>
                )
            }

        }
        return (
            <div className="container">
                <div className="row space-top">
                    <div className="col-md-12">
                        <h1>Login</h1>
                    </div>
                </div>
                {errors}
                <form onSubmit={this.onSubmitHandler}>
                    <div className="row space-top">
                        <div className="col-md-3">
                            <div className="form-group">
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
                            </div>
                            <input type="submit" className="btn btn-secondary" value="Login" />
                        </div>
                    </div>
                </form>
            </div>
        );
    }
}

export default withRouter(LoginPage);