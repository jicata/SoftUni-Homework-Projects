import React from 'react';
import MonthlyBalanceCard from './MonthlyBalanceCard';

export default function ListMonthlyBalances({ balances, year }) {
    let firstQuarter = balances.slice(0, 4);
    let secondQuarter = balances.slice(4, 8);
    let finalQuarter = balances.slice(8, 12);
    let index = -1;
    const months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
    let stuff = [];

    return (

        <div>
            <div className="row space-top col-md-12">
                {firstQuarter.map(b => {
                    index++;
                    return (<MonthlyBalanceCard
                        key={index}
                        numberOfMonth ={index}
                        month={months[index]}
                        year={year}
                        budget={b.budget}
                        income={b.balance} />)
                })}
            </div>
            <div className="row space-top col-md-12">
                {secondQuarter.map(b => {
                    index++;
                    return (<MonthlyBalanceCard
                        key={index}
                        numberOfMonth ={index}
                        month={months[index]}
                        year={year}
                        budget={b.budget}
                        income={b.balance} />)
                })}
            </div>
            <div className="row space-top col-md-12">
                {finalQuarter.map(b => {
                    index++;
                    return (<MonthlyBalanceCard
                        key={index}
                        numberOfMonth ={index}
                        month={months[index]}
                        year={year}
                        budget={b.budget}
                        income={b.balance} />)
                })}
            </div>
        </div>
    )
}