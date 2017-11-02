import React, { Component } from 'react'
import ImgTag from './ImgTag'

class Image extends Component {
    constructor(props) {
        super(props);

        this.state = {
            roster: []
        }
    }

    componentDidMount() {
        fetch('http://localhost:9999/roster/')
            .then(rawRoster => {
                return rawRoster.json();
            })
            .then(roster => {
                this.setState({ roster: roster });
                console.log(roster);
            })
    }

    render() {
        return (
            <div>
                {this.state.roster.map((r, index) => {
                    return  <ImgTag key={index} imgUrl={r.url} height="200" width="178"/> 
                })}
            </div>
        )
    }
}


export default Image;