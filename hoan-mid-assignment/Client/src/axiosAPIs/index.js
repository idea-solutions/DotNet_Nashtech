import axios from "axios";

export const getAllData = async () => {
    let data = [];
    await axios
        .get(`https://localhost:7259/api/v1/Task`)
        .then((response) => {
            data = [...response.data];
        })
        .catch((err) => {
            console.log({ err });
        });
    return data;
};
