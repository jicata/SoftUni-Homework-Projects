import React from 'react';

let About = (props) => {
    return (
        <div className="about">
            <h1>{props.header}</h1>
            <p>{props.firstParagraph}</p>
            <p>{props.secondParagraph}</p>
        </div>
    )
}

export default About;