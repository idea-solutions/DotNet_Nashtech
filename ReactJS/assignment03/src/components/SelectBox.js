export const SelectBox = ({ value, setValue }) => {
    const options = [
        { value: "", text: "Choose an option" },
        { value: "pokemon", text: "Pokemon" },
    ];

    const handleChange = (e) => {
        setValue(e.target.value);
    };

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
