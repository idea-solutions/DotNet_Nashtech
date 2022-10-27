import { useState } from "react";
import { InfoMembers } from "./components/InfoMembers";
import { SelectBox } from "./components/SelectBox";
import { Checkboxs } from "./components/Checkboxs";
import "./App.css";
import { Counter } from "./components/Counter";

const App = () => {
    const [value, setValue] = useState("");

    const ResultSelected = value => {
        switch (value) {
            case "welcome":
                return (
                    <>
                        <InfoMembers
                            name={"Hoan"}
                            age={22}
                            styleBox={"member_box_red"}
                        />
                        <InfoMembers
                            name={"Dung"}
                            age={18}
                            styleBox={"member_box_yellow"}
                        />
                        <InfoMembers
                            name={"Hung"}
                            age={20}
                            styleBox={"member_box_green"}
                        />
                    </>
                );
            case "counter":
                return <Counter />;
            case "checkboxs":
                return <Checkboxs />;
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
