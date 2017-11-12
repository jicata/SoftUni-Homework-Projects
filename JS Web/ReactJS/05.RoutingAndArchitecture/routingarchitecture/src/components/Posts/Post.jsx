import React from 'react'

let Post = (props) => {
    return (
        <div class="posts">
            <article class="post">
                <div class="col rank">
                    <span>1</span>
                </div>
                <div class="col thumbnail">
                    <a href={props.url}>
                        <img src={props.imageUrl} />
                    </a>
                </div>
                <div class="post-content">
                    <div class="title">
                        <a href={props.url}>
                            {props.title}
                        </a>
                    </div>
                    <div class="details">
                        <div class="info">
                            submitted 1 day ago by {props.author}
                        </div>
                        <div class="controls">
                            <ul>
                                <li class="action"><a class="commentsLink" href="#">comments</a></li>
                                <li class="action"><a class="editLink" href="#">edit</a></li>
                                <li class="action"><a class="deleteLink" href="#">delete</a></li>
                            </ul>
                        </div>

                    </div>
                </div>
            </article>
        </div>
    )
}

export default Post