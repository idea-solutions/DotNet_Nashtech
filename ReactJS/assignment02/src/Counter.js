import { useState } from "react";

export const Counter = () => {
    const [counter, setCounter] = useState(0);

    const increase = () => {
        setCounter((count) => count + 1);
    };

    const decrease = () => {
        setCounter((count) => count - 1);
    };

    return (
        <>
            <div className="btn__container">
                <button className="control__btn" onClick={decrease}>
                    -
                </button>
                <span className="counter__output">{counter}</span>
                <button className="control__btn" onClick={increase}>
                    +
                </button>
            </div>
        </>
    );
};
