import React, { Component } from 'react'
import Input from '../formComponents/Input'
import UserService from '../../services/UsersService'

export default class Register extends Component {
    constructor(props) {
        super(props)
        this.state = {
            username: '',
            password: '',
            confirmPassword: ''
        }

        this.submitRegister = this.submitRegister.bind(this);
    }

   async submitRegister(e) {
        e.preventDefault();
        let payload = {
            username: this.state.username,
            password: this.state.password
        }
        e.target.reset();
        try{
            let result = await UserService.register(payload);
            console.log(result);
        }
        catch(e){
            
        }
      
        
    }

    render() {
        return (
            <form id="registerForm" onSubmit={this.submitRegister}>
                <h2>Register</h2>
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
                <Input data="confirmPassword"
                    name="Password"
                    type="password"
                    onChangeFunc={(e) => this.setState({ confirmPassword: e.target.value })}
                />
                <input id="btnRegister" value="Sign Up" type="submit" />
            </form>
        )
    }
}