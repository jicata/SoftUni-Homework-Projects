import React from 'react';

export default function Errors({error}){
    return (
        <div>
            <h2 className="errorMessage">
                {error.message}
            </h2>
            {Object.keys(error.errors).map(e => {
                return <p key={e}>{error.errors[e]}</p>
            })}
        </div>
    )
}