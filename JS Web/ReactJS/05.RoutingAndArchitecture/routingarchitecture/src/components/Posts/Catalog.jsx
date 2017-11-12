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
        PostService.all()
            .then(allPosts => {
                this.setState({ posts: allPosts });
                console.log(this.state.posts)
            })

    }

    render() {
        return (
            <section id="viewCatalog">
                {this.state.posts.map((p, i) => {
                    return (<Post key={i}
                        url={p.url}
                        imageUrl={p.imageUrl}
                        title={p.title}
                        author={p.author}
                    />)
                })
                }
            </section >
        )
    }
}