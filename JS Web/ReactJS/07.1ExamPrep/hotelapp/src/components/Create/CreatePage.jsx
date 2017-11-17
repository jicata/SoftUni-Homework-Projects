import React, { Component } from 'react';
import Input from '../common/Input';
import { createHotel } from '../../api/remote';
import { withRouter } from 'react-router-dom'

class CreatePage extends Component {
    constructor(props) {
        super(props);

        this.state = {
            name: '',
            location: '',
            description: '',
            rooms: 0,
            image: '',
            parkingSlots: '',
            error: false,
            submitting: false
        }

        this.onChangeHandler = this.onChangeHandler.bind(this);
        this.onSubmitHandler = this.onSubmitHandler.bind(this);
    }

    onChangeHandler(e) {
        this.setState({ [e.target.name]: e.target.value });
    }

    async onSubmitHandler(e) {
        this.setState({submitting:true})
        e.preventDefault();
        let hotel = {
            name: this.state.name,
            location: this.state.location,
            description: this.state.description,
            numberOfRooms: this.state.rooms,
            image: this.state.image,
            parkingSlots: this.state.parkingSlots
        }

        let error = {
            message: 'Check the form for errors',
            errors: {}
        }

        if (hotel.description.length < 10) {
            error.errors.description = 'Description has to be more than 10 symbols'
        }

        if (isNaN(hotel.numberOfRooms) || hotel.numberOfRooms <= 0) {
            error.errors.rooms = 'Number of rooms must be a positive number'
        }
        this.setState({submitting:false})
        if (error.errors.length > 0) {
            this.setState({ error })
            return;
        } else {
            let response = await createHotel(hotel);
            if (!response.success) {
                this.setState({ error: response })
                return;
            } else {
                this.setState({ error: false })
            }
        }
        this.props.history.push('/');
    }

    render() {
        let errors = null;
        if (this.state.error) {
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
        return (
            <div>
                <h1>Create Hotel</h1>
                {errors}
                <form onSubmit={this.onSubmitHandler}>
                    <Input
                        label="Name"
                        value={this.state.name}
                        onChange={this.onChangeHandler}
                        name="name"
                    />
                    <Input
                        label="Location"
                        value={this.state.location}
                        onChange={this.onChangeHandler}
                        name="location"
                    />
                    <Input
                        label="Description"
                        value={this.state.description}
                        onChange={this.onChangeHandler}
                        name="description"
                    />
                    <Input
                        label="Image"
                        value={this.state.image}
                        onChange={this.onChangeHandler}
                        name="image"
                    />
                    <Input
                        label="Number of Rooms"
                        value={this.state.rooms}
                        onChange={this.onChangeHandler}
                        name="rooms"
                        type="number"
                    />
                    <Input
                        label="Parking Slots"
                        value={this.state.parkingSlots}
                        onChange={this.onChangeHandler}
                        name="parkingSlots"
                    />
                    <input type="submit" value="Create" disabled={this.state.submitting}/>
                </form>
            </div>
        )
    }
}


export default withRouter(CreatePage);