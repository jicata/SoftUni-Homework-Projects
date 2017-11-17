import React from 'react';
import {Link} from 'react-router-dom'

export default function HotelCard({ name, image, location,id }) {
    return (
        <article className="hotelCard">
            <img alt={image} src={image} />
            <p>{name} in {location}</p>
            <Link to={"/details/"+id}>View Details</Link>
        </article>
    )
}