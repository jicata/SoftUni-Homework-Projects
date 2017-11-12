import React, {Component} from 'react'

export default class MyPosts extends Component {
    constructor(props){
        super(props)
    }

    render(){
        return(
            <section id="viewMyPosts">
            <div class="post post-content">
                <h1>Your Posts</h1>
            </div>
            <div class="posts">
                <article class="post">
                    <div class="col rank">
                        <span>1</span>
                    </div>
                    <div class="col thumbnail">
                        <a href="http://sammyjs.org/docs/api/0.7.4/all#Sammy.RenderContext-load">
                            <img src="src/RuditoFreshStep.jpg"/>
                        </a>
                    </div>
                    <div class="post-content">
                        <div class="title">
                            <a href="http://sammyjs.org/docs/api/0.7.4/all#Sammy.RenderContext-load">
                                Sammy Docs
                            </a>
                        </div>
                        <div class="details">
                            <div class="info">
                                submitted 5 days ago by pesho
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
                    <div class="clear"></div>
                </article>
            </div>
        </section>
        )
    }
}