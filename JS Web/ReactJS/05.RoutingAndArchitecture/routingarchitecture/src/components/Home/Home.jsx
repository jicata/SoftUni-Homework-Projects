import React, { Component } from 'react'
import Login from './Login'
import Register from './Register'
import About from './About'
export default class Home extends Component {
    constructor(props) {
        super(props);

        this.state = {
            username: '',
            password: '',
        }
    }

    render() {
        return (
            <section id="viewWelcome">
                <div className="welcome">
                    <div className="signup">
                        <Login onSuccess={(username) => this.props.onSuccessfulLogin(username)}/>
                        <Register />
                    </div>
                    <About header="Welcome to SeenIt"
                        firstParagraph="Share interesting links and discuss great content. It's what's happening now."
                        secondParagraph="Sign in or sign up in a second." />
                </div>
            </section>
        )
    }
}