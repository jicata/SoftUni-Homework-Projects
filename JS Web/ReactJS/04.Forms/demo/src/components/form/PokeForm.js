import React, { Component } from 'react'

import validationFunc from './../../utils/formValidator'
import Input from './formFields/Input'
import PokemonImage from '../pokemons/PokemonImg'

export default class PokeForm extends Component {
    constructor(props) {
        super(props)

        this.state = {
            pokemonName: '',
            pokemonImage: '',
            pokemonInfo: '',
            pokemons: []
        }
        this.createPokemonSubmit = this.createPokemonSubmit.bind(this);
    }

    createPokemonSubmit(e) {
        e.preventDefault();
        let pokemonPostObject = {
            pokemonName: this.state.pokemonName,
            pokemonImg: this.state.pokemonImage,
            pokemonInfo: this.state.pokemonInfo
        }
        this.createPokemon(pokemonPostObject);
    }

    createPokemon(pokemon) {
        fetch("http://localhost:5000/pokedex/create", {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(pokemon)
        })
            .then(res => {
                console.log(res);
            })
            .then(result => {
                this.renderPokemons()
            })
    }

    renderPokemons() {
        fetch("http://localhost:5000/pokedex/pokedex")
            .then(res => {
                return res.json();
            })
            .then(pokemons => {
                console.log(pokemons.pokemonColection);
                this.setState({ pokemons: pokemons.pokemonColection })
            })
    }

    componentDidMount() {
        this.renderPokemons();
        console.log(this.state.pokemons)
    }

    render() {
        let validatePokemonObj = validationFunc(
            '',
            '',
            this.state.pokemonName,
            '',
            '',
            ''
        )

        return (
            <div>
                <h1>LOGGED</h1>
                <form onSubmit={this.createPokemonSubmit}>
                    <fieldset className='App'>
                        <div style={{ display: 'inline-grid' }}>
                            <Input
                                type='text'
                                data='name'
                                name='Pokemon Name'
                                func={(e) => this.setState({ pokemonName: e.target.value })}
                                valid={validatePokemonObj.validName}
                            />
                            <Input
                                type='text'
                                data='image'
                                name='Pokemon Image'
                                func={(e) => this.setState({ pokemonImage: e.target.value })}
                                valid={validatePokemonObj.validName}
                            />
                            <Input
                                type='text'
                                data='ingo'
                                name='Pokemon Info'
                                func={(e) => this.setState({ pokemonInfo: e.target.value })}
                                valid={validatePokemonObj.validName}
                            />

                            <input type='submit' value='Create Pokemon' />
                        </div>
                    </fieldset>
                </form>
                <div>
                    {this.state.pokemons.map((p, i) => (
                        <PokemonImage
                            key = {i}
                            pokemonName = {p.pokemonName}
                            imgSrc = {p.pokemonImg}
                        />
                    ))}
                </div>
            </div>
        )
    }


}