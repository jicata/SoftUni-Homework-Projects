import React, { Component } from 'react';
import { Switch, Route } from 'react-router-dom';

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
  render() {
    return (
      <div className="App">
        <Header />
        <main>
          <Switch>
            <Route exact path="/" render={() => <HomePage furniture={furniture} />} />
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

export default App;
