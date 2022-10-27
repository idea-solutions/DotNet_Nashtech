export const SelectBox = ({ value, setValue }) => {

    const handleChange = (e) => {
        setValue(e.target.value);
    };

    const options = [
        { value: "", text: "Choose an option" },
        { value: "welcome", text: "Welcome" },
        { value: "counter", text: "Counter" },
        { value: "checkboxs", text: "Checkboxs" },
    ];

    return (
        <>
            <label>
                <select value={value} onChange={handleChange}>
                    {options.map((op, i) => (
                        <option key={i} value={op.value}>
                            {op.text}
                        </option>
                    ))}
                </select>
            </label>
            <div>Option selected: {value}</div>
        </>
    );
};
