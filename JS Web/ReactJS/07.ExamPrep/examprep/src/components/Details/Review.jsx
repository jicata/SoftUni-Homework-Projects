import React from 'react'


export default  ({user, rating, comment})=> {
    return(
        <div className="col-md-8">
        <div className="card text-black bg-light">
            <div className="card-body">
                <blockquote className="card-blockquote">
                    <p>{comment}</p>
                    <footer>{user}
                        <cite title="Source Title">{rating}</cite>
                    </footer>
                </blockquote>
            </div>
        </div>
    </div>
    )
}