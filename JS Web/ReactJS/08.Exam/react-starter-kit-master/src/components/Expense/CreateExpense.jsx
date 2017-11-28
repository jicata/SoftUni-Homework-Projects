import React, { Component } from 'react';
import Input from '../common/Input';
import Errors from '../common/Errors'
import { addExpense, isAuthed } from '../../api/remote'
import { withRouter } from 'react-router-dom'


class CreateExpense extends Component {
    constructor(props) {
        super(props);

        this.state = {
            name: '',
            amount: 0,
            paymentDate: 'dd/mm/yyyy',
            category: 'Non-essential',
            month:'',
            еrror: false
        };

        this.onChangeHandler = this.onChangeHandler.bind(this);
        this.onSubmitHandler = this.onSubmitHandler.bind(this);
    }

    onChangeHandler(e) {
        this.setState({ [e.target.name]: e.target.value });
    }

    componentWillMount() {
        if (!isAuthed()) {
            this.props.history.push('/login');
            return;
        }
        if(this.props.match.params.month){
            this.setState({month : this.props.match.params.month - 1 })
        }
    }


    async onSubmitHandler(e) {
        e.preventDefault();
        let splitDate = this.state.paymentDate.split('/');
        let date = Number(splitDate[0])
        let month = Number(splitDate[1]);
        let year = Number(splitDate[2]);

        let expense = {
            name: this.state.name,
            amount: Number(this.state.amount),
            year,
            month,
            date,
            category: this.state.category
        }
        const response = await addExpense(expense);
        if (!response.success) {
            this.setState({ error: response })
            return;
        }
        if(this.state.month){
            this.props.history.push(`/monthly/${this.props.match.params.year}/${this.state.month+1}`)
        }else{
            this.props.history.push('/monthly')
        }
        

    }
    render() {
        var monthNames = ["January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        ];

        var d = new Date();
        let currentMonthNumber = this.state.month ? this.state.month : d.getMonth()
        let currentMonth = monthNames[currentMonthNumber];
        let errors = null;
        if (this.state.error) {
            errors = (
                <Errors error={this.state.error} />
            )
        }
        return (
            <div className="container">
                <div className="row space-top">
                    <div className="col-md-12">
                        <h1>Add Expenses</h1>
                        <h3>{currentMonth} 2017</h3>
                    </div>
                    {errors}
                </div>
                <div className="row space-top">
                    <div className="col-md-10">
                        <form onSubmit={this.onSubmitHandler}>
                            <legend>Add a new expense</legend>
                            <Input
                                name="name"
                                value={this.state.name}
                                onChange={this.onChangeHandler}
                                label="Name:"
                            />
                            <Input
                                name="amount"
                                value={this.state.amount}
                                onChange={this.onChangeHandler}
                                label="Amount:"
                                type="number"
                            />
                            <Input
                                name="paymentDate"
                                value={this.state.paymentDate}
                                onChange={this.onChangeHandler}
                                label="Payment Date"
                            />
                            <div className="form-group">
                                <label className="col-md-2" htmlFor="category">Category:</label>
                                <select
                                    className="col-md-2 pl-2"
                                    name="category"
                                    value={this.state.category}
                                    onChange={this.onChangeHandler}>
                                    <option>Non-essential</option>
                                    <option>Fixed</option>
                                    <option>Variable</option>
                                </select>
                            </div>
                            <input type="submit" className="btn btn-secondary" value="Add" />
                        </form>
                    </div>
                </div>
            </div>
        )
    }
}

export default withRouter(CreateExpense)