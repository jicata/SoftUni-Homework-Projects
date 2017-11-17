import React, { Component } from 'react';

export default class Paginator extends Component {
    render() {
        const { items, length, current } = this.props;
        const pageCount = Math.ceil(items / length)
        const pages = [];
        const lastPage =  Number(pageCount) - 1;
        const firstPage = Number(current) - 1;

        for (let i = 1; i <= pageCount; i++) {
            pages.push((
               
                <li className={`page-item${i == current ? ` active` : ''}`}>
                    <a className="page-link" href={`/view/${i}`}>{i}</a>
                </li>))
        }

        return (
            <div className="row space-top">
                <div className="col-md-12">
                    <ul className="pagination">
                        <li className={`page-item${current == 1 ? ' disabled' : ''}`}>
                            <a className="page-link" href={`/view/${firstPage}`}>«</a>
                        </li>
                        {pages}

                        <li className={`page-item${current == pageCount ? ' disabled' : ''}`}>
                            <a className="page-link" href={`/view/${lastPage}`}>»</a>
                        </li>
                    </ul>
                </div>
            </div>
        )
    }
}
