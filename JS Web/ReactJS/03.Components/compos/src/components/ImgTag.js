import React from 'react'
import Details from './Details'

const ImgTag = (props) => {
    return <div onClick= {Details.clickOnImg} className="rosterImg">
        <img height={props.height} width={props.width} src={props.imgUrl} />
    </div>
}

export default ImgTag