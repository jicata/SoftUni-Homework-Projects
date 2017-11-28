import React from 'react'

export default function ExpenseRow({id,name, category, amount, date, onDelete}){
    return (
        <tr>
        <td>{name}</td>
        <td>{category}</td>
        <td>{amount}</td>
        <td>{date}</td>
        <td>
        <a href="javascript:void(0)" onClick={onDelete} id={id} className="btn btn-secondary">Delete</a>
        </td>
    </tr>
    )
}