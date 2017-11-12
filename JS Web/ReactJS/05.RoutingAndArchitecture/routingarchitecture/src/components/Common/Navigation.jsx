import React from 'react';
import { Link } from 'react-router-dom';

let Navigation = (props) => {
    return (
        <div id="menu">
            <div className="title">Navigation</div>
            <Link className="nav" to='/Catalog'>Catalog</Link>
            <Link className="nav" to='/Submit'>Submit Link</Link>
            <Link className="nav" to='/MyPosts'>My Posts</Link>
        </div>

    )
}

export default Navigation