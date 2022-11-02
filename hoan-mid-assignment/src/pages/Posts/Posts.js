import axios from "axios";
import { Space, Table } from "antd";

import React, { useEffect, useState } from "react";

const Posts = () => {
    const [dataState, setDataState] = useState("");
    const [convertData, setConvertData] = useState("");
    const dataAPI = () => {
        axios
            .get(`https://localhost:7259/api/v1/Task`)
            .then((response) => {
                setDataState(response.data);
            })
            .catch((err) => {
                console.log({ err });
            });
    };

    useEffect(() => {
        dataAPI();
    }, []);

    console.log({ dataState });

    const columns = [
        {
            title: "First Name",
            dataIndex: "firstName",
            key: "firstName",
            render: (text) => <a>{text}</a>,
        },
        {
            title: "Last Name",
            dataIndex: "lastName",
            key: "lastName",
        },
        {
            title: "Gender",
            dataIndex: "gender",
            key: "gender",
        },
        {
            title: "Date Of Birth",
            dataIndex: "dateOfBirth",
            key: "dateOfBirth",
        },
        {
            title: "Birth Place",
            dataIndex: "birthPlace",
            key: "birthPlace",
        },
        {
            title: "Action",
            key: "action",
            render: (_, record) => (
                <Space size="middle">
                    <a>Update {record.firstName}</a>
                    <a>Delete</a>
                </Space>
            ),
        },
    ];

    useEffect(() => {
        if (dataState) {
            setConvertData(
                dataState.map(({ uniqueId, ...data }) => {
                    return {
                        ...data,
                        key: uniqueId,
                    };
                })
            );
        }
    }, [dataState]);

    console.log({ convertData });

    return <Table columns={columns} dataSource={convertData} />;
};

export default Posts;
