import React, {Component} from 'react';
import { Link } from 'react-router-dom'


export default class MonthlyBalanceCard extends Component {
    render() {
        const { numberOfMonth, month, year, budget, income } = this.props
        return (
            <div className="col-md-3">
                <div className="card text-white bg-secondary">
                    <div className="card-body">
                        <blockquote className="card-blockquote">
                            <h2>{month}</h2>
                            <h4>Year {year}</h4>
                            <label htmlFor="budget">Budget:</label>
                            <input className="col-md-9" name="budget" value={budget} disabled />
                            <label htmlFor="balance">Balance:</label>
                            <input className="col-md-9" name="balance" value={income} disabled />
                            <div className="space-top">
                                <Link to={`monthly/${year}/${numberOfMonth + 1}`} className="btn btn-secondary">Details</Link>
                            </div>
                        </blockquote>
                    </div>
                </div>
            </div>

        )
    }
}