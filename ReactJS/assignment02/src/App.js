import { SelectBox } from "./SelectBox";
import "./App.css";
import { InfoMembers } from "./InfoMembers";
import { useState } from "react";
import { Counter } from "./Counter";

const App = () => {
    const [value, setValue] = useState("");

    const ResultSelected = () => {
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
                return (
                    <>
                        <Counter />
                    </>
                );
            case "checkboxs":
                return <>TODO</>;
            default:
                break;
        }
    };

    return (
        <div className="App">
            <SelectBox value={value} setValue={setValue} />
            {ResultSelected()}
        </div>
    );
};

export default App;
