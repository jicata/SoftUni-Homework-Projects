import React, { Component } from 'react';
import Input from './Input';
import { registerAction } from '../../actions/authActions'
import { Redirect } from 'react-router-dom'
import { connect } from 'react-redux';

class RegisterPage extends Component {
    constructor(props) {
        super(props)

        this.state = {
            name: '',
            email: '',
            password: '',
            repeat: '',
            redirect: false
        }
        this.onChangeHandler = this.onChangeHandler.bind(this);
        this.onSubmitHandler = this.onSubmitHandler.bind(this);
    }

    onChangeHandler(e) {
        this.setState({ [e.target.name]: e.target.value });
    }

    onSubmitHandler(e) {
        e.preventDefault();
        const promise = this.props.register(
            this.state.name,
            this.state.email,
            this.state.password);
        console.log(promise);
        promise.then(kur => console.log(kur));
    }

    render() {
        if (this.state.redirect) {
            return (
                <Redirect to="/" />
            );
        }
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
            </div>
        )
    }
}

function mapDispatchToProps(dispatch) {
    return {
        register: (name, email, password) => dispatch(registerAction(name, email, password))
    }
}

function mapStateToProps(state){
    return {
        registerSuccess: state.register.success;
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(RegisterPage)