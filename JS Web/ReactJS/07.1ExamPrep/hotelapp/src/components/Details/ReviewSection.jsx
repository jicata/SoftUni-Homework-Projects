import React, { Component } from 'react';
import { postReview, getReviews } from '../../api/remote';
import Review from './Review';


export default class ReviewSection extends Component {
    constructor(props) {
        super(props)
        this.state = {
            rating: 5,
            comment: '',
            reviews: [],
            error: false,
        }

        this.onChangeHandler = this.onChangeHandler.bind(this);
        this.onSubmitHandler = this.onSubmitHandler.bind(this);
    }


    componentDidMount() {
        this.getData();
    }

    async getData() {
        const reponse = await getReviews(this.props.hotelId)
        this.setState({ reviews: reponse })
    }

    onChangeHandler(e) {
        this.setState({ [e.target.name]: e.target.value });
    }

    async onSubmitHandler(e) {
        e.preventDefault();
        const response = await postReview(this.props.hotelId,
            this.state.comment,
            Number(this.state.rating));

        if (!response.success) {
            this.setState({ error: response })
            return;
        }
        const reviews = this.state.reviews.slice();
        reviews.push(response.review);
        this.setState({ reviews });
        this.getData();

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
            <div style={{ margin: "2em" }}>
                <form onSubmit={this.onSubmitHandler}>
                    <h2>Leave a review</h2>
                    {errors}
                    <select value={this.state.rating} name="rating" onChange={this.onChangeHandler}>
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                    </select>
                    Comment: <br />
                    <textarea
                        name="comment"
                        value={this.state.comment}
                        onChange={this.onChangeHandler} />
                    <input
                        type="submit"
                        value="Post review" />
                </form>
                {this.state.reviews.map(r => {
                    return (<Review
                        key={r.id}
                        user={r.user}
                        rating={r.rating}
                        comment={r.comment}
                        date={r.createdOn} />)
                })}
            </div>
        )
    }
}