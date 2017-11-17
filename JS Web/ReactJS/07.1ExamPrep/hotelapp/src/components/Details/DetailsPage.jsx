import React, { Component } from 'react';
import { getDetails, postReview } from '../../api/remote'
import ReviewSection from './ReviewSection'

export default class DetailsPage extends Component {
    constructor(props) {
        super(props);

        this.state = {
            hotel: false,
        }
    }

    componentDidMount() {
        this.getData();
    }

    async getData() {
        const hotel = await getDetails(Number(this.props.match.params.id))
        this.setState({ hotel });
    }

    render() {
        let errors = null;
        if (this.state.error) {
            console.log(this.state.error)
            errors = (
                <div>
                    <h2 className="errorMessage">
                        {this.state.error.message}
                    </h2>
                    {Object.keys(this.state.error.errors).map(e => {
                        return <p key={e}>{this.state.error.errors[e]}</p>
                    })}
                </div>
            )
        }
        let main = <p>Loading... &hellip;</p>
        if (this.state.hotel) {
            const hotel = this.state.hotel;
            main = (
                <div className="hotelDetails">
                    <img alt={hotel.image} src={hotel.image} />
                    <h2>{hotel.name}</h2>
                    <h3>{hotel.location}</h3>
                    <p>{hotel.description}</p>
                    <p>Rooms: {hotel.numberOfRooms}</p>
                    <p>Parking spots: {hotel.parkingSlots}</p>
                </div>
            )
        }
        return (
            <div className="container">
                <h1>Details</h1>
                {main}
                <ReviewSection hotelId = {Number(this.props.match.params.id)} />
            </div >
        )
    }
}