import React, { Component } from 'react';
import { getPage } from '../../api/remote'
import { Link } from 'react-router-dom'
import HotelsList from './HotelsList'

export default class HomePage extends Component {
    constructor(props) {
        super(props);

        this.state = {
            hotels: []
        }
    }

    componentDidMount() {
        this.getData();
    }

    async getData(page = Number(this.props.match.params.page || 1)) {
        //const page = Number(this.props.match.params.page || 1);
        const data = await getPage(page);
        this.setState({ hotels: data });
    }

    componentWillReceiveProps(nextProps){
        if(nextProps.match.params.page !== this.props.match.params.page){
            this.getData(Number(nextProps.match.params.page));
        }
    }

    render() {
        const page = Number(this.props.match.params.page || 1);


        return (
            <div className="container">
                <h1>Home Page</h1>
                <p>Welcome to our site.</p>
                {this.state.hotels.length === 0
                    ? <p>Loading &hellip;</p>
                    : (<HotelsList hotels={this.state.hotels} />)}
                <div className="pagination">
                    {page > 1 && <Link to={'/view/' + (page - 1)}>&lt;</Link>}
                    <Link to={'/view/' + (page + 1)}>&gt;</Link>
                </div>
            </div>
        );
    }
}