import React from 'react';

export default function Review({ comment, rating, user, date }) {
    return (
        <article>
            <header>{user} - {rating} stars</header>
            <p>{comment}</p>
            <footer>posted on {date}</footer>
        </article>
    )
}