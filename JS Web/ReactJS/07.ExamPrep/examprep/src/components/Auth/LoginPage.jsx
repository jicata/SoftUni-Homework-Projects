import React, { Component } from 'react';
import Input from './Input';
import { loginAction, redirectAction} from '../../actions/authActions'
import { withRouter } from 'react-router-dom'
import { connect } from 'react-redux';

class LoginPage extends Component {
    constructor(props) {
        super(props)

        this.state = {
            email: '',
            password: '',
        }
        this.onChangeHandler = this.onChangeHandler.bind(this);
        this.onSubmitHandler = this.onSubmitHandler.bind(this);
    }

    onChangeHandler(e) {
        this.setState({ [e.target.name]: e.target.value });
    }

    onSubmitHandler(e) {
        e.preventDefault();
        this.props.login(
            this.state.email,
            this.state.password);
    }

    componentWillReceiveProps(newProps) {
        if (newProps.loginSuccess) {
            this.props.redirect();
            this.props.history.push('/');
        }
    }

    render() {
        return (
            <div className="container">
                <div className="row space-top">
                    <div className="col-md-12">
                        <h1>Login</h1>
                    </div>
                </div>
                <form onSubmit={this.onSubmitHandler}>
                    <div className="row space-top">
                        <div className="col-md-4">
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
                            <input type="submit" className="btn btn-primary" value="Login" />
                        </div>
                    </div>
                </form>
            </div>
        )
    }
}
function mapDispatchToProps(dispatch) {
    return {
        login: (email, password) => dispatch(loginAction(email, password)),
        redirect: () => dispatch(redirectAction())
    }
}

function mapStateToProps(state) {
    return {
        loginSuccess: state.login.success
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(withRouter(LoginPage));