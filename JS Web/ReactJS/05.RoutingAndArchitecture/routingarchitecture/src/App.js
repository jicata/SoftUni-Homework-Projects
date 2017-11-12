import React, { Component } from 'react';
import logo from './logo.svg';
import { BrowserRouter } from 'react-router-dom'
import Header from './components/Common/Header'
import Footer from './components/Common/Footer'
import Home from './components/Home/Home.jsx'
import Notification from './components/Common/Notification'
import Navigation from './components/Common/Navigation'
import Router from './components/Router'
import './App.css';

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      username: ''
    }
  }

  render() {
    return (
      <BrowserRouter>
        <div>
          <div id="container">
            <header>
              <Header username={this.state.username} />
            </header>
            <div className="content">
              {window.localStorage.authtoken
                ? (<div><Navigation /> <Router /></div>)
                : <Home onSuccessfulLogin={(username) => this.setState({ username: username })} />}
            </div>
            <Footer />
          </div>
          {/* <Notification notificationId="infoBox" message="Bravo be" /> */}
        </div>
      </BrowserRouter >
    );
  }
}

export default App;
