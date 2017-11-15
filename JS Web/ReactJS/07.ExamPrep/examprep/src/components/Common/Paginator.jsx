import React, { Component } from 'react';

export default class Paginator extends Component {
    render() {
        return (
            <div className="row space-top">
            <div className="col-md-12">
                <ul className="pagination">
                    <li className="page-item disabled">
                        <a className="page-link" href="#">«</a>
                    </li>
                    <li className="page-item active">
                        <a className="page-link" href="#">1</a>
                    </li>
                    <li className="page-item">
                        <a className="page-link" href="#">2</a>
                    </li>
                    <li className="page-item">
                        <a className="page-link" href="#">3</a>
                    </li>
                    <li className="page-item">
                        <a className="page-link" href="#">4</a>
                    </li>
                    <li className="page-item">
                        <a className="page-link" href="#">5</a>
                    </li>
                    <li className="page-item">
                        <a className="page-link" href="#">»</a>
                    </li>
                </ul>
            </div>
        </div>
        )
    }
}
