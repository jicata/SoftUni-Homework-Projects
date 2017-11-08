import React from 'react'

let Header = (props) => {
    return(
    <header>
        <span class="logo">☃</span><span class="header">SeenIt</span>
        <div id="profile">
        {props.token 
            ? (<span>pesho</span>|<a href="#/logout">logout</a>) 
            : (<a href="#/login">login</a>)}
        </div>
    </header>)
}

export default Header