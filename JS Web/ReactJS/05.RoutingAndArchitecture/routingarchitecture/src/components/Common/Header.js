import React from 'react'

let Header = (props) => {
    return(
    <header>
        <span className="logo">☃</span><span className="header">SeenIt</span>
        <div id="profile">
        {props.username.length > 0
            ? (<div><span>hello, {props.username}</span> <a href="#/logout">logout</a></div>) 
            : (<a href="#/login">login</a>)}
        </div>
    </header>)
}

export default Header