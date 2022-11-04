import axios from "axios";
import { Button, Space, Table, Input } from "antd";

import React, { useEffect, useState } from "react";
import { getAllData } from "../../axiosAPIs";

const Posts = () => {
    const [dataState, setDataState] = useState("");
    const [convertData, setConvertData] = useState("");

    const getData = async () => {
        const data = await getAllData();
        setDataState(data);
    };

    useEffect(() => {
        getData();
    }, []);

    const columns = [
        {
            title: "First Name",
            dataIndex: "firstName",
            key: "firstName",
            sorter: (a, b) => a.firstName.localeCompare(b.firstName),
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
                    <Button type="primary">Update</Button>
                    <Button
                        type="primary"
                        danger
                        onClick={() => handleDelete(record)}
                    >
                        Delete
                    </Button>
                </Space>
            ),
        },
    ];

    console.log({ convertData });

    const onSearch = (value) => console.log(value);

    const handleDelete = (record) => {
        axios
            .delete(`https://localhost:7259/api/v1/Task/${record.key}`)
            .then((response) => {
                console.log("da xoa", response.data);
            })
            .catch((err) => {
                console.log({ err });
            });
        var newData = dataState.filter(
            (data) => data.uniqueId !== parseInt(record.key)
        );
        setDataState(newData);
    };

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

    console.log({ dataState });

    return (
        <>
            <Space
                direction="vertical"
                size="middle"
                style={{ display: "flex" }}
            >
                {" "}
                <Input.Search
                    placeholder="input search First Name"
                    allowClear
                    onSearch={onSearch}
                    style={{
                        width: 300,
                        float: "right",
                    }}
                />
                <Table columns={columns} dataSource={convertData} />
            </Space>
        </>
    );
};

export default Posts;
