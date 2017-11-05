import React, { Component } from 'react';
import ImgTag from './ImgTag';
import Text from './Text'
import Image from './Image';

class Details extends Component {
    constructor() {
        super()

        this.state = {
            imgUrl: '',
            content: ''
        }
    }

    childImgWasClicked(imgId) {
        fetch("http://localhost:9999/character/"+imgId)
        .then(rawCharacter => {
            return rawCharacter.json();
        })
        .then(character => {
            this.setState({ imgUrl: character.url, content: character.bio });
        })
    }

    componentDidMount() {
        fetch("http://localhost:9999/character/0")
            .then(rawCharacter => {
                return rawCharacter.json();
            })
            .then(character => {
                this.setState({ imgUrl: character.url, content: character.bio });
            })
    }

    render() {
        return (
            <div>
            <Image parentCallback = {(imgId) => this.childImgWasClicked(imgId)} />
            <fieldset >
                <ImgTag imgUrl={this.state.imgUrl} />
                <Text content={this.state.content} />
            </fieldset>
            </div>
        )
    }
}

export default Details