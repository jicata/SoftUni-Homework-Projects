import React from 'react'

let PokemonImage = props => {
    return (
        <div style={{ display: 'inline-grid', border: 'solid 1px' }}>
            <h4>{props.pokemonName}</h4>
            <img height="150px" width="150px" src={props.imgSrc} />
        </div>
    )

}



export default PokemonImage;