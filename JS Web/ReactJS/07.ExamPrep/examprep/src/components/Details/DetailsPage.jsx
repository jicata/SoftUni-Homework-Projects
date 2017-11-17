import React, { Component } from 'react';
import Review from './Review';
import { connect } from 'react-redux';
import { fetchDetailsAction } from '../../actions/furnitureActions'

class DetailsPage extends Component {

    componentWillMount() {
        console.log(this.props.match.params.id);
        this.props.getData(this.props.match.params.id)

    }

    render() {
        const { make, model, year, image, description, price, material } = this.props.furniture;
        return (
            <div className="container">
                <div className="row space-top">
                    <div className="col-md-12">
                        <h1>Furniture Details</h1>
                    </div>
                </div>
                <div className="row space-top">
                    <div className="col-md-4">
                        <div className="card text-white bg-primary">
                            <div className="card-body">
                                <blockquote className="card-blockquote">
                                    <img alt={"Kur"} src={image} />
                                </blockquote>
                            </div>
                        </div>
                    </div>
                    <div className="col-md-4">
                        <p>Make: {make}</p>
                        <p>Model: {model}</p>
                        <p>Year: {year}</p>
                        <p>Description: {description}</p>
                        <p>Price: {price}</p>
                        <p>Material: {material}</p>
                        <a href="#" className="btn btn-primary">Like</a>
                    </div>
                </div>
                <div className="row space-top">
                    <div className="col-md-8">
                        <form>
                            <legend>Leave a review</legend>
                            <div className="form-group">
                                <textarea className="form-control"></textarea>
                            </div>
                            <div className="form-group">
                                <label>Rating</label>
                                <div className="btn-group mr-2" role="group" aria-label="First group">
                                    <button type="button" className="btn btn-secondary">1</button>
                                    <button type="button" className="btn btn-secondary">2</button>
                                    <button type="button" className="btn btn-primary">3</button>
                                    <button type="button" className="btn btn-secondary">4</button>
                                    <button type="button" className="btn btn-secondary">5</button>
                                </div>
                                <input type="submit" className="btn btn-primary" value="Submit review" />
                            </div>
                        </form>
                    </div>

                    <Review
                        user="pesho"
                        rating="4"
                        comment="staa"
                    />
                    <Review
                        user="maria"
                        rating="1"
                        comment="naah"
                    />
                </div>
            </div>
        )
    }
}

function mapState(state, ownProps) {
    //console.log(ownProps.match.params.id);
    const item = state.furniture.filter(f => {
        console.log(f.id == ownProps.match.params.id);
    })

    return {
        furniture: item || {
            make: 'КУР БАТЕ...',
            model: 'КУР БАТЕ...',
            year: 'КУР БАТЕ...',
            description: 'КУР БАТЕ...',
            image: 'КУР БАТЕ...',
            material: 'КУР БАТЕ...',
            price: 'КУР БАТЕ...',
        },
        reviews: item ? item.reviews : []
    }
}

function mapDispatch(dispatch) {
    return {
        getData: (id) => dispatch(fetchDetailsAction(id))
    }
}


export default connect(mapState, mapDispatch)(DetailsPage);