import React, { Component } from 'react'
import Input from '../formComponents/Input'
import UserService from '../../services/UsersService'

export default class Login extends Component {
    constructor(props) {
        super(props);

        this.state = {
            username: '',
            password: '',
        }
        this.submitLogin = this.submitLogin.bind(this);
    }

    async submitLogin(e) {
        e.preventDefault();
        let payload = {
            username: this.state.username,
            password: this.state.password
        }
        e.target.reset();
        try {
            let result = await UserService.login(payload);
            console.log(result);
            window.localStorage.setItem('authtoken', result._kmd.authtoken);
            this.props.onSuccess(result.username);
        }
        catch (err) {
            console.log(err);
        }

    }
    render() {
        return (
            <form id="loginForm" onSubmit={this.submitLogin}>
                <h2>Sign In</h2>
                <Input data="username"
                    name="Username"
                    type="text"
                    onChangeFunc={(e) => this.setState({ username: e.target.value })}
                />
                <Input data="password"
                    name="Password"
                    type="password"
                    onChangeFunc={(e) => this.setState({ password: e.target.value })}
                />
                <input id="btnLogin" value="Sign In" type="submit" />
            </form>
        )
    }
}