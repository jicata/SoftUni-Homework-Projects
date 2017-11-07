import React, { Component } from 'react'
import './App.css'

import SingUpForm from './components/form/SingUpForm'
import PokeForm from './components/form/PokeForm';

class App extends Component {
  constructor() {
    super()

    this.state = {
      username: '',
      token: ''
    }
    this.checkIfTokenExists = this.checkIfTokenExists.bind(this);
  }

  componentDidMount() {
    this.checkIfTokenExists()
  }

  checkIfTokenExists(token) {
    window.localStorage.setItem('token', token);
    this.setState({ token: token })
  }

  render() {
    return (
      <div>
        {this.state.token !== '' ? (<PokeForm />) : (<SingUpForm onSignIn={this.checkIfTokenExists} />)}
      </div>
    )
  }
}

export default App
