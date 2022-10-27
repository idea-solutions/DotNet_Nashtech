export const InfoMembers = ({ name, age, styleBox }) => {
    return (
        <div className={`member_box ${styleBox}`}>
            <h1>{name}</h1>
            <div>Age: {age}</div>
        </div>
    );
};
