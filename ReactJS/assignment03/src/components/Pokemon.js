import { useEffect, useState } from "react";
import axios from "axios";

export const Pokemon = () => {
    const [pokemonState, setPokemonState] = useState("");
    const [pokemonId, setPokemonId] = useState(1);
    const [errorMsg, setErrorMsg] = useState("");
    const [loading, setLoading] = useState(false);

    const pegaPokemon = (pokeId) => {
        setLoading(true);
        axios
            .get(`https://pokeapi.co/api/v2/pokemon/${pokeId}`)
            .then((response) => {
                setLoading(false);
                setPokemonState(response.data);
            })
            .catch((err) => {
                setLoading(false);
                setErrorMsg(err.message);
            });
    };

    useEffect(() => {
        pegaPokemon(pokemonId);
    }, [pokemonId]);

    useEffect(() => {
        if (errorMsg) {
            alert(errorMsg);
            setErrorMsg("");
            setPokemonId(1);
        }
    }, [errorMsg, pokemonId]);

    return (
        <>
            {loading ? (
                <div>Loading</div>
            ) : (
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
                        <button
                            style={{ marginRight: "40px" }}
                            onClick={() => setPokemonId((pre) => pre - 1)}
                            disabled={pokemonId === 1}
                        >
                            Previous
                        </button>
                        <button onClick={() => setPokemonId((pre) => pre + 1)}>
                            Next
                        </button>
                    </div>
                </div>
            )}
        </>
    );
};
