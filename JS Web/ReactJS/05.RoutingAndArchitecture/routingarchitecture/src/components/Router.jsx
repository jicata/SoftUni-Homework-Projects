import React from 'react'
import { Switch, Route } from 'react-router-dom'
import Catalog from './Posts/Catalog'
import MyPosts from './Posts/MyPosts'
import Submit from './Posts/Submit'

const Main = () => (
  <main>
    <Switch>
      <Route exact path='/' component={Catalog}/>
      <Route path='/Catalog' component={Catalog}/>
      <Route path='/MyPosts' component={MyPosts}/>
      <Route path='/Submit' component={Submit} /> 
    </Switch>
  </main>
)

export default Main
