import React from 'react'

const Input = (props) => {
    return (
        <div>
        <label htmlFor={props.data}>{props.name}</label>
        <div>
            <input
                type={props.type}
                onChange={props.onChangeFunc}
                name={props.data}
            />
        </div>
    </div>
    )
}

export default Input;