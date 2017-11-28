import React, { Component } from 'react';
import { getYearlyBalance, isAuthed } from '../../api/remote'
import MonthlyBalanceCard from '../Balance/MonthlyBalanceCard';
import ListMonthlyBalances from './ListMonthlyBalances';

export default class YearlyBalancePage extends Component {
    constructor(props) {
        super(props);

        this.state = {
            monthlyStats: []
        }

    }

    componentWillMount() {
        if(!isAuthed()){
            console.log(isAuthed());
            this.props.history.push('/login');
            return;
        }
        this.getData();
    }

    async getData() {
        let data = await getYearlyBalance();
        let result = [];
        for(let key in data){
            result.push(data[key]);
        }
        this.setState({ monthlyStats: result })
    }

    render() {
        let year = this.props.match.params.year || new Date().getFullYear();
        let index = -1;
        const months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

        return (
            <div className="container">
                <div className="row space-top">
                    <div className="col-md-12">
                        <h1>Yearly Balance</h1>
                    </div>
                </div>
                <ListMonthlyBalances balances={this.state.monthlyStats} year={year}/>
            </div>
        )
    }
}

