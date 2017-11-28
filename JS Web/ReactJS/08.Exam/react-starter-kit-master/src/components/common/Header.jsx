import React, { Component } from 'react';
import { NavLink } from 'react-router-dom';

export default class Header extends Component {
    render() {
        const { loggedIn, onLogout } = this.props;

        return (
            <header>
                <nav className="navbar navbar-dark bg-secondary">
                    <div className="container">
                        <div className="row">
                            <div className="col-md-12">
                                <NavLink exact to="/" activeClassName="active" className={"nav-link"}>Home</NavLink>
                                {loggedIn && <NavLink to="/monthly" activeClassName="active" className={"nav-link"}>Monthly Balance</NavLink>}
                                {loggedIn && <NavLink to="/yearly" activeClassName="active" className={"nav-link"}>Yearly Balance</NavLink>}
                                {loggedIn && <a href="javascript:void(0)" onClick={onLogout}>Logout</a>}
                                {!loggedIn && <NavLink to="/login" activeClassName="active"  className={"nav-link"}>Login</NavLink>}
                                {!loggedIn && <NavLink to="/register" activeClassName="active"  className={"nav-link"}>Register</NavLink>}
                            </div>
                        </div>
                    </div>
                </nav>
            </header>
        );
    }
}