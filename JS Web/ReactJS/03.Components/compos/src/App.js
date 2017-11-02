import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import Slider from './components/Slider'
import Image from './components/Image'
import Details from './components/Details'

class App extends Component {
  render() {
    return (
      <div className="App">
        <Slider />
        <Image />
        <div>
          <Details />
        </div>
      </div>
      
    );
  }
}

export default App;
