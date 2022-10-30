import { useEffect, useState } from "react";
import axios from "axios";

export const Pokemon = () => {
    const [pokemonState, setPokemonState] = useState("");
    const [pokemonId, setPokemonId] = useState(1);
    const [errorMsg, setErrorMsg] = useState("");

    const pegaPokemon = (pokeId) => {
        axios
            .get(`https://pokeapi.co/api/v2/pokemon/${pokeId}`)
            .then((response) => {
                setPokemonState(response.data);
            })
            .catch((err) => {
                setErrorMsg(err.message);
            });
    };

    useEffect(() => {
        pegaPokemon(pokemonId);
    }, [pokemonId]);

    useEffect(() => {
        if (errorMsg && pokemonId >= 0) {
            alert(errorMsg);
            setErrorMsg("");
            setPokemonId(1);
        }
    }, [errorMsg, pokemonId]);

    const handleBtnPre = () => {
        if (errorMsg === "") {
            setPokemonId((pre) => pre - 1);
        }
    };

    return (
        <div>
            <p>ID: {pokemonState.id}</p>
            <p>Name: {pokemonState.name}</p>
            <p>Weight: {pokemonState.weight}</p>
            {pokemonState.sprites && (
                <img
                    src={pokemonState.sprites.front_default}
                    alt={pokemonState.name}
                />
            )}
            {pokemonState.sprites && (
                <img
                    src={pokemonState.sprites.back_default}
                    alt={pokemonState.name}
                />
            )}
            <div>
                <button style={{ marginRight: "40px" }} onClick={handleBtnPre}>
                    Previous
                </button>
                <button onClick={() => setPokemonId((pre) => pre + 1)}>
                    Next
                </button>
            </div>
        </div>
    );
};
