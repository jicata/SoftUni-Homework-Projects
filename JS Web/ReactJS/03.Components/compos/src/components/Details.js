import React, { Component } from 'react';
import ImgTag from './ImgTag';
import Text from './Text'

class Details extends Component {
    constructor() {
        super()

        this.state = {
            imgUrl: '',
            content: ''
        }
    }


    clickOnImg(){
        
    }


    componentDidMount(){
        fetch("http://localhost:9999/character/1")
            .then(rawCharacter => {
                return rawCharacter.json();
            })
            .then(character => {
                this.setState({imgUrl:character.url, content:character.bio});
            }) 
    }

    render() {
        return (
            <fieldset>
                <ImgTag imgUrl={this.state.imgUrl} />
                <Text content={this.state.content} />
            </fieldset>
        )
    }
}

export default Details