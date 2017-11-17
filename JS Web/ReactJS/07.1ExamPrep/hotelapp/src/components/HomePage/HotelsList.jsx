import React, { Component } from 'react';
import HotelCard from './HotelCard'

export default class HotelsList extends Component {
    render(){
        return (
            <div>
                {this.props.hotels.map(h=>{
                    return(
                        <HotelCard 
                            key={h.id}
                            name={h.name}
                            location={h.location}
                            image={h.image}
                            id={h.id} />
                    )
                })}
            </div>
        )
    } 
}