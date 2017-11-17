import React, { Component } from 'react';
import Input from '../Auth/Input';
import { createFurnitureAction } from '../../actions/furnitureActions';
import { withRouter } from 'react-router-dom'
import { connect } from 'react-redux';

class CreatePage extends Component {
    constructor(props) {
        super(props)

        this.state = {
            make: '',
            model: '',
            year: 0,
            description: '',
            price: 0,
            image: '',
            material: '',
            submitting: false
        }
        this.onChangeHandler = this.onChangeHandler.bind(this);
        this.onSubmitHandler = this.onSubmitHandler.bind(this);
    }

    onChangeHandler(e) {
        this.setState({ [e.target.name]: e.target.value });
    }

    async onSubmitHandler(e) {
        e.preventDefault();
        this.setState({ submitting: true });
        let furniture = {
            make: this.state.make,
            model: this.state.model,
            year: this.state.year,
            description: this.state.description,
            price: this.state.price,
            image: this.state.image,
            material: this.state.material,
        }
        await this.props.create(furniture);
        this.setState({ submitting: false });
        this.props.history.push('/');

    }
    render() {
        return (
            <div className="container">
                <div className="row space-top">
                    <div className="col-md-12">
                        <h1>Create New Furniture</h1>
                        <p>Please fill all fields.</p>
                    </div>
                </div>
                <form onSubmit={this.onSubmitHandler}>
                    <div className="row space-top">
                        <div className="col-md-4">
                            <Input name="make"
                                value={this.state.make}
                                onChange={this.onChangeHandler}
                                label="Make"
                            />
                            <Input name="model"
                                value={this.state.model}
                                onChange={this.onChangeHandler}
                                label="Model"
                            />
                            <Input name="year"
                                value={this.state.year}
                                onChange={this.onChangeHandler}
                                label="new-year"
                                type="Number"
                            />
                            <Input name="description"
                                value={this.state.description}
                                onChange={this.onChangeHandler}
                                label="Description"
                            />
                        </div>
                        <div className="col-md-4">
                            <Input name="price"
                                value={this.state.price}
                                onChange={this.onChangeHandler}
                                label="Price"
                                type="number"
                            />
                            <Input name="image"
                                value={this.state.image}
                                onChange={this.onChangeHandler}
                                label="Image"
                            />
                            <Input name="material"
                                value={this.state.material}
                                onChange={this.onChangeHandler}
                                label="Material"
                            />
                            <input type="submit" className="btn btn-primary" value="Create" disabled={this.state.submitting} />
                        </div>
                    </div>
                </form>
            </div>
        )
    }
}

function mapDispatchToProps(dispatch) {
    return {
        create: (payload) => dispatch(createFurnitureAction(payload))
    }
}

function mapStateToProps(state) {
    return {

    }
}
export default connect(mapStateToProps, mapDispatchToProps)(withRouter(CreatePage));