import React, { Component } from 'react';
import Input from '../common/Input';
import { register } from '../../api/remote';
import { withRouter } from 'react-router-dom';

export default class RegisterPage extends Component {
    constructor(props) {
        super(props);

        this.state = {
            name: '',
            email: '',
            password: '',
            repeat: '',
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
        if (this.state.password !== this.state.repeat) {
            let error = {
                message: 'Check the form for errors',
                errors: { confirm: "Passwords don't match" }
            }
            this.setState({ error: error });
            return;
        }

        const res = await register(this.state.name, this.state.email, this.state.password);
        if (!res.success) {
            this.setState({ error: res })
            return;
        }
        this.props.history.push('/login');

    }

    render() {
        let errors = null;
        if (this.state.error) {
            errors = (
                <div>
                    <h2 className="errorMessage">
                        {this.state.error.message}
                    </h2>
                    {Object.keys(this.state.error.errors).map(e => {
                        return <p key={e}>{this.state.error.errors[e]}</p>
                    })}
                </div>
            )
        }
        return (
            <div className="container">
                <h1>Register</h1>
                {errors}
                <form onSubmit={this.onSubmitHandler}>
                    <Input
                        name="name"
                        value={this.state.name}
                        onChange={this.onChangeHandler}
                        label="Name"
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
                    <input type="submit" className="btn btn-primary" value="Register" />
                </form>
            </div>
        );
    }
}