import React, { Component } from 'react';
import left from './../resources/left.png';
import right from './../resources/right.png';

class Slider extends Component {
    constructor() {
        super()

        this.state = {
            focusedEpisodeId: 0,
            imgUrl: ''
        }

        this.slideToEpisode = (id) => {
            fetch(`http://localhost:9999/episodePreview/${id}`)
            .then(episodePreview => {
                return episodePreview.json();
            })
            .then(parsedData => {
                this.episodePreviewImage = parsedData.url;
                this.setState({ imgUrl: parsedData.url, focusedEpisodeId: id });
            })
        }

    }

    componentDidMount() {
        fetch(`http://localhost:9999/episodePreview/${this.state.focusedEpisodeId}`)
            .then(episodePreview => {
                return episodePreview.json();
            })
            .then(parsedData => {
                this.episodePreviewImage = parsedData.url;
                this.setState({ imgUrl: parsedData.url });
            })
    }


    render() {
        return (
            <div className="wrapper">
                <img onClick={() => {
                    this.slideToEpisode(this.state.focusedEpisodeId - 1)
                }}
                    className='left slider-button case-left' alt='left-arrow' src={left} />
                <img className='sliderImg' alt="focusedEpisode" src={this.state.imgUrl} />
                <img onClick={() => {
                    this.slideToEpisode(this.state.focusedEpisodeId + 1)
                }} className='right slider-button case-right' alt='right-arrow' src={right} />
            </div>
        );
    }
}

export default Slider