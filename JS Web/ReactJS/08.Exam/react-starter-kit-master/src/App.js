import React, { Component } from 'react';
import { Route, Switch, withRouter } from 'react-router-dom';

import Header from './components/common/Header';
import Footer from './components/common/Footer'
import RegisterPage from './components/Auth/RegisterPage';
import LoginPage from './components/Auth/LoginPage';
import HomePage from './components/HomePage/HomePage';
import MonthlyBalancePage from './components/Balance/MonthlyBalancePage'
import YearlyBalancePage from './components/Balance/YearlyBalancePage'
import CreateExpense from  './components/Expense/CreateExpense';

class App extends Component {
    constructor(props) {
        super(props);

        this.onLogout = this.onLogout.bind(this);
    }

    onLogout() {
        localStorage.clear();
        this.props.history.push('/');
    }

    render() {
        return (
            <div className="App">
                <Header loggedIn={localStorage.getItem('authToken') != null} onLogout={this.onLogout} />
                <main>
                     <Switch>
                        <Route exact path="/" component={HomePage} />
                        <Route exact path="/monthly" component={MonthlyBalancePage} />
                        <Route path="/monthly/:year/:month" component={MonthlyBalancePage} />
                        <Route exact path="/yearly" component={YearlyBalancePage} />
                        <Route path="/yearly/:year" component={YearlyBalancePage} />
                        <Route path="/login" component={LoginPage} />
                        <Route path="/login" component={LoginPage} />
                        <Route path="/register" component={RegisterPage} />
                        <Route exact path="/expenses" component={CreateExpense} />
                        <Route path="/expenses/:year/:month" component={CreateExpense} />
                    </Switch>
                </main>
                <Footer />  
            </div>
        );
    }
}

export default withRouter(App);