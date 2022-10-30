import { useState } from "react";
import "./App.css";
import { Pokemon } from "./components/Pokemon";
import { SelectBox } from "./components/SelectBox";

const App = () => {
    const [value, setValue] = useState("");

    const ResultSelected = (value) => {
        switch (value) {
            case "pokemon":
                return <Pokemon />;
            default:
                return;
        }
    };

    return (
        <div className="App">
            <SelectBox value={value} setValue={setValue} />
            {ResultSelected(value)}
        </div>
    );
};

export default App;
