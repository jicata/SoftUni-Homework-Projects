import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import ExpenseRow from '../Expense/ExpenseRow';
import Input from '../common/Input';
import { getMonthlyBalance, deleteExpense, updateMonthlyPlan, isAuthed } from '../../api/remote';



export default class MonthlyBalancePage extends Component {
    constructor(props) {
        super(props);

        this.state = {
            expenses: [],
            budget: 0,
            income: 0,
            year: '',
            month: 0
        }
        this.onDeleteHandler = this.onDeleteHandler.bind(this);
        this.onSubmitHandler = this.onSubmitHandler.bind(this);
        this.onChangeHandler = this.onChangeHandler.bind(this);

    }

    componentWillMount() {
        if (!isAuthed()) {
            this.props.history.push('/login');
            return;
        }
        this.getData();
    }


    onChangeHandler(e) {
        this.setState({ [e.target.name]: e.target.value });
    }

    async onSubmitHandler(e) {
        e.preventDefault();
        if (!isAuthed()) {
            this.props.history.push('/login');
            return;
        }
        let date = new Date();
        let month = this.state.month || date.getMonth();
        let year = this.state.year === 'current' ? date.getFullYear() : this.state.year;

        let plan = {
            month: Number(month) + 1,
            year: Number(year),
            budget: Number(this.state.budget),
            income: Number(this.state.income)
        }
        let response = await updateMonthlyPlan(plan);

        if (!response.success) {
            console.log(response);
        }
        this.getData();
    }

    async getData() {
        let currentYear = this.props.match.params.year || 'current';
        let month = this.props.match.params.month
        let data = await getMonthlyBalance(currentYear, month);
        this.setState({ budget: data.budget, expenses: data.expenses || [], income: data.income, year: currentYear, month });
    }

    async onDeleteHandler(e) {
        if (!isAuthed()) {
            this.props.history.push('/login');
            return;
        }
        let response = await deleteExpense(e.target.id);
        this.getData();
    }

    render() {
        var monthNames = ["January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        ];
        let kur = `/expenses${this.state.year && this.state.month ? '/' + this.state.year + '/' + this.state.month : ''}`

        var d = new Date();
        let currentMonthNumber = this.state.month ? this.state.month - 1 : d.getMonth()
        let currentMonth = monthNames[currentMonthNumber];
        let yearMonthParams = this.state.year && this.state.month ? "/" + this.state.year + "/" + this.state.month : ''
        return (
            <div className="container">
                <div className="row space-top">
                    <div className="col-md-12">
                        <h1>Welcome to Budget Planner</h1>
                    </div>
                </div>
                <div className="row space-top ">
                    <div className="col-md-12 ">
                        <div className="card bg-secondary">
                            <div className="card-body">
                                <blockquote className="card-blockquote">
                                    <h2 id="month">{currentMonth} 2017</h2>
                                    <div className="row">
                                        <div className="col-md-3 space-top">
                                            <h4>Planner</h4>
                                            <form onSubmit={this.onSubmitHandler}>
                                                <Input
                                                    name="income"
                                                    value={this.state.income}
                                                    onChange={this.onChangeHandler}
                                                    label="Income:"
                                                    type="number"
                                                />
                                                <Input
                                                    name="budget"
                                                    value={this.state.budget}
                                                    onChange={this.onChangeHandler}
                                                    label="Budget:"
                                                    type="number"
                                                />
                                                <input type="submit" className="btn btn-secondary" value="Save" />
                                            </form>
                                        </div>
                                        <div className="col-md-8 space-top">
                                            <div className="row">
                                                <h4 className="col-md-9">Expenses</h4>
                                                <Link to={`/expenses${yearMonthParams}`}
                                                    className="btn btn-secondary ml-2 mb-2">Add expenses</Link>
                                            </div>
                                            <table className="table">
                                                <thead>
                                                    <tr>
                                                        <th>Name</th>
                                                        <th>Category</th>
                                                        <th>Cost</th>
                                                        <th>Payment Date</th>
                                                        <th></th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    {this.state.expenses.map(e => {
                                                        return (<ExpenseRow
                                                            key={e.id}
                                                            id={e.id}
                                                            name={e.name}
                                                            amount={e.amount}
                                                            category={e.category}
                                                            date={`${e.date}/${e.month}/${e.year}`}
                                                            onDelete={this.onDeleteHandler}
                                                        />)
                                                    })}
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </blockquote>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}

