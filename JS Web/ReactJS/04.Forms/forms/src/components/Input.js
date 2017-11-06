import React, { Component } from 'react';

let Input = (props) => {
    return (<div>
        <label htmlFor={props.data}>{props.name}</label>
        <div>
            <input
                style={{ width: '300px' }}
                type={props.type}
                onChange={props.onChangeFunc}
                name={props.data}
            />
        </div>
    </div>)
}

export default Input;