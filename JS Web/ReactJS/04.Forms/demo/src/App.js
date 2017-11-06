import React, { Component } from 'react'
import './App.css'

import SingUpForm from './components/form/SingUpForm'

class App extends Component {
  constructor () {
    super()

    this.state = {
      username: '',
      token: ''
    }
  }

  render () {
    return <SingUpForm />
  }
}

export default App
