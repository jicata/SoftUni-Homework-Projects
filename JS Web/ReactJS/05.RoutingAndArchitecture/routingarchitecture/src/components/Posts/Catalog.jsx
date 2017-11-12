import React, { Component } from 'react'
import PostService from './../../services/PostsService'
import Post from './Post'

export default class Catalog extends Component {
    constructor(props) {
        super(props)

        this.state = {
            posts: []
        }
    }

    async componentDidMount() {
        try {
            PostService
                .all()
                .then(allPosts => {
                    console.log(allPosts);
                    this.setState({ posts: allPosts });
                })
        }
        catch (err) {
            console.log(err)
        }
    }

    render() {
        return (
            <section id="viewCatalog">
                {this.state.posts
                    ? (this.state.posts.map((p, i) => {
                        <Post key={i}
                            url={p.url}
                            imageUrl={p.imageUrl}
                            title={p.title}
                            author={p.author}
                        />
                    }))
                    : (<h1>emi</h1>)
                }
            </section >
        )
    }
}