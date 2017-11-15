import React, { Component } from 'react';
import FurtnitureList from '../Common/Furniture/FurnitureList'
import Paginator from '../Common/Paginator';

export default class HomePage extends Component {
    render() {
        const { furniture } = this.props;
        return (
            <div className="container">
                <div className="row space-top">
                    <div className="col-md-12">
                        <h1>Welcome to Furniture System</h1>
                        <p>Select furniture from the catalog to view details.</p>

                        <form className="form-inline my-2 my-lg-0">
                            <input className="form-control mr-sm-2" placeholder="Search" type="text" />
                            <button className="btn btn-secondary my-2 my-sm-0" type="submit">Search</button>
                        </form>
                    </div>
                </div>
                <FurtnitureList furniture={furniture} />
                <Paginator />
            </div>
        )
    }
}