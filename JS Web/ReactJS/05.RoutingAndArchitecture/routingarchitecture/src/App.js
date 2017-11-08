import React, { Component } from 'react';
import logo from './logo.svg';
import { BrowserRouter } from 'react-router-dom'
import Header from './components/Header'
import Footer from './components/Footer'
import './App.css';

class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <div>
          <Header />
          <Footer />
        </div>
      </BrowserRouter>
    );
  }
}

export default App;
