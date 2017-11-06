import React, { Component } from 'react';
import Input from './Input';

export default class Login extends Component {
    constructor(props) {
        super(props);

        this.onInputChange = this.onInputChange.bind(this);
    }

    onInputChange(e){
        console.log(e)
    }

    render() {
        return (
            <div>
                <Input data='email'
                    name='Email'
                    type='text'
                    onChangeFunc ={this.onInputChange}/>
            </div>
        )
    }
}