import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import { createStore } from 'redux'

const ADD_INPUT = 'ADD_INPUT';
const EDIT_INPUT = 'EDIT_INPUT';
const ON_CHANGE = 'ON_CHANGE';

let inputReducers = (state, action) => {
    switch (action.type) {
        case ADD_INPUT:
            return [...state, {
                index: state.length,
                value: action.payload.value,
                buttonText: "Edit input",
                onClickHandler: (e) => { store.dispatch(actions.editInput('kur')) }
            }]
        case EDIT_INPUT:
            return
        case ON_CHANGE:
            let lol = [...state.slice(0, action.payload.index),
            Object.assign({}, state[action.payload.index], { value: action.payload.value }),
            ...state.slice(action.payload.index+1)
            ];
            return lol;
        default:
            return state;
    }
}


let store = createStore(inputReducers, [{
    value: 'New input',
    index: 0,
    buttonText: 'Add',
    onClickHandler: (e) => {
        store.dispatch(actions.addInput({ value: e.target.value }))
    }
}]);


let actions = {
    addInput: (payload) => {
        return { type: ADD_INPUT, payload };
    },
    editInput: (payload) => {
        return { type: EDIT_INPUT, payload };
    },
    onChange: (payload) => {
        return { type: ON_CHANGE, payload };
    }
}

let Input = ({ value, index, buttonText, onClickHandler }) => {
    return (
        <div style={{ display: "inline-block" }}>
            <input type="text" value={value} onChange={(e) => store.dispatch(actions.onChange({ index: index, value: e.target.value }))} />
            <button onClick={onClickHandler}>{buttonText}</button>
        </div>
    )
}

let InputWrapper = () => {
    return (
        <div style={{ display: "inline-block" }} >
            {store.getState().map((input, index) => {
                return (<div>
                    <br />
                    <Input key={index}
                        value={input.value}
                        index={input.index}
                        buttonText={input.buttonText}
                        onClickHandler={input.onClickHandler} />
                </div>)
            })}
        </div >
    )
}


store.subscribe(() => {
    ReactDOM.render(<InputWrapper />, document.getElementById('root'));
})

ReactDOM.render(<InputWrapper />, document.getElementById('root'));
registerServiceWorker();

