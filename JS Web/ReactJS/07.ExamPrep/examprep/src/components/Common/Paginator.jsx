import React, { Component } from 'react';

export default class Paginator extends Component {
    render() {
        const { items, length, current } = this.props;
        const pageCount = Math.ceil(items / length)
        const pages = [];

        for (let i = 1; i <= pageCount; i++) {
            pages.push((
                <li className={`page-item${i === current ? `active` : ''}`}>
                    <a className="page-link" href={`/${i}`}>{i}</a>
                </li>))
        }

        return (
            <div className="row space-top">
                <div className="col-md-12">
                    <ul className="pagination">
                        <li className="page-item disabled">
                            <a className="page-link" href="#">«</a>
                        </li>
                        {pages}
                        <li className="page-item">
                            <a className="page-link" href="#">»</a>
                        </li>
                    </ul>
                </div>
            </div>
        )
    }
}
