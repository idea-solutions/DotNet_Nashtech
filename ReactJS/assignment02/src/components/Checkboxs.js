import { useState } from "react";
import { Checkbox } from "./Checkbox";

export const Checkboxs = ({ value, setValue }) => {
    const [isCheckAll, setIsCheckAll] = useState(false);
    const [isCheck, setIsCheck] = useState([]);

    const interestsList = [
        {
            id: "01",
            name: "Coding",
        },
        {
            id: "02",
            name: "Music",
        },
        {
            id: "03",
            name: "Reading books",
        },
    ];

    const handleSelectAll = (e) => {
        setIsCheckAll(!isCheckAll);
        setIsCheck(interestsList.map((li) => li.id));
        if (isCheckAll) {
            setIsCheck([]);
        }
    };

    const handleClick = (e) => {
        const { id, checked } = e.target;
        setIsCheck([...isCheck, id]);
        if (!checked) {
            setIsCheck(isCheck.filter((item) => item !== id));
        }
    };

    const interest = interestsList.map(({ id, name }) => {
        return (
            <div key={id} className="checkbox-list">
                <Checkbox
                    key={id}
                    type="checkbox"
                    name={name}
                    id={id}
                    handleClick={handleClick}
                    isChecked={isCheck.includes(id)}
                />
                {name}
            </div>
        );
    });

    const displayInterest = () => {
        return interestsList.map((interest) => {
            return `"${interest.name}": ${
                isCheck.includes(interest.id) ? "true" : "false"
            }`;
        });
    };

    return (
        <>
            <Checkbox
                type="checkbox"
                name="selectAll"
                id="selectAll"
                handleClick={handleSelectAll}
                isChecked={isCheckAll}
            />
            Select All
            {interest}
            <div>Your Selected: </div>
            <div>{`{${displayInterest()}}`}</div>
        </>
    );
};
