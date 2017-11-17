import React, { Component } from 'react';
import { Switch, Route, withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import { logoutAction } from './actions/authActions';
import { fetchStatsAction } from './actions/statsActions';


import Header from './components/Common/Header';
import Footer from './components/Common/Footer';

import HomePage from './components/Home/HomePage';
import CreatePage from './components/Create/CreatePage';
import ProfilePage from './components/Profile/ProfilePage';
import LoginPage from './components/Auth/LoginPage';
import RegisterPage from './components/Auth/RegisterPage';
import DetailsPage from './components/Details/DetailsPage';
import NotFound from './components/Common/NotFound';

import { furniture } from './data.json'

class App extends Component {
  constructor(props) {
    super(props)
    this.state = {
      loggedIn: false
    }
    this.onLogout = this.onLogout.bind(this);
  }

  onLogout() {
    this.props.logout();
    this.props.history.push("/");
    this.setState({ loggedIn: false })
  }

  componentDidMount() {
    if (sessionStorage.getItem("authToken")) {
      this.setState({ loggedIn: true })
    }
  }

  componentWillReceiveProps(nextProps) {
    if (nextProps.loginSuccess) {
      this.setState({ loggedIn: true })
    }
  }

  componentWillMount() {
    if (sessionStorage.getItem("authToken")) {
      this.setState({ loggedIn: true })
    }
    this.props.getStats();
  }

  render() {
    return (
      <div className="App">
        <Header
          items={this.props.stats.furniture}
          users={this.props.stats.users}
          loggedIn={this.state.loggedIn}
          logout={this.onLogout} />
        <main>
          <Switch>
            <Route exact path="/" component={HomePage} />
            <Route path="/view/:page" component={HomePage} />
            <Route path="/create" component={CreatePage} />
            <Route path="/profile" component={ProfilePage} />
            <Route path="/details/:id" component={DetailsPage} />
            <Route path="/login" component={LoginPage} />
            <Route path="/register" component={RegisterPage} />
            <Route component={NotFound} />
          </Switch>
        </main>
        <Footer />
      </div>
    );
  }
}

function mapDispatchToProps(dispatch) {
  return {
    logout: () => dispatch(logoutAction()),
    getStats: () => dispatch(fetchStatsAction())

  }
}

function mapStateToProps(state) {
  return {
    loginSuccess: state.login.success,
    stats: state.stats
  }
}

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(App));
