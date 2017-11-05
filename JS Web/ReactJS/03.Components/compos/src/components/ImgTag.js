import React, { Component } from 'react'
import Details from './Details'

class ImgTag extends Component {
    constructor() {
        super();
    }

    onClicked(event) {  
        console.log(event);
        this.props.parentCallback(this.props.dataId);
    }

    render() {      
        return <div className="rosterImg" onClick={(e)=>this.onClicked(e)}>
            <img height={this.props.height} width={this.props.width} src={this.props.imgUrl} />
        </div>
    }
}



export default ImgTag