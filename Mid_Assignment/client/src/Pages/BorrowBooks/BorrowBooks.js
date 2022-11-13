import { Button, Input, Space, Table, Tag } from 'antd';
import { Content } from 'antd/lib/layout/layout';
import React, { useEffect, useState } from 'react';
import { createData, getAllData } from '../../axiosAPIs';
import { BORROW_BOOKS, UPDATE_STATUS_BORROW } from '../../constants';
import styles from './BorrowBooks.module.scss';
const BorrowBooks = () => {
  const [dataState, setDataState] = useState([]);

  const getData = async () => {
    const data = await getAllData(BORROW_BOOKS);
    setDataState(data);
  };

  useEffect(() => {
    getData();
  }, []);
  const handleApproved = async (id) => {
    await createData(UPDATE_STATUS_BORROW, { id: id, isApproved: true });
    getData();
  };

  const handleRejected = async (id) => {
    await createData(UPDATE_STATUS_BORROW, { id: id, isApproved: false });
    getData();
  };

  const columns = [
    {
      title: 'ID',
      dataIndex: 'id',
      key: 'id',
    },
    {
      title: 'Username',
      dataIndex: 'username',
      key: 'username',
      sorter: (a, b) => a.username.localeCompare(b.username),
    },
    {
      title: 'Status',
      dataIndex: 'status',
      key: 'status',
      sorter: (a, b) => a.status.localeCompare(b.status),
      render: (_, { status }) => (
        <>{<Tag color={status === 'Approved' ? 'success' : status === 'Waiting' ? 'processing' : 'error'}>{status}</Tag>}</>
      ),
    },
    {
      title: 'Books name',
      dataIndex: 'booksName',
      key: 'booksName',
      render: (_, { booksName }) => (
        <>
          {booksName.map((book) => {
            return <Tag key={book.id}>{book.name}</Tag>;
          })}
        </>
      ),
    },
    {
      title: 'Update By User',
      dataIndex: 'updateByUser',
      key: 'updateByUser',
      sorter: (a, b) => a.updateByUser.localeCompare(b.updateByUser),
    },
    {
      title: 'Action',
      key: 'action',
      render: (_, record) => (
        <Space size="middle">
          <Button
            disabled={record.status === 'Approved' || record.status === 'Rejected'}
            type="primary"
            onClick={() => {
              handleApproved(record.id);
            }}
          >
            Approve
          </Button>
          <Button
            disabled={record.status === 'Approved' || record.status === 'Rejected'}
            type="primary"
            danger
            onClick={() => {
              handleRejected(record.id);
            }}
          >
            Reject
          </Button>
        </Space>
      ),
    },
  ];

  const [dataTable, setDataTable] = useState();

  useEffect(() => {
    if (dataState) {
      setDataTable(
        dataState.map((data) => {
          return {
            id: data.id,
            username: data.requestedBy.username,
            status: data.status,
            booksName: data.books.map((bookName) => {
              return { id: bookName.id, name: bookName.name };
            }),
            updateByUser: data.statusUpdateByUserId !== null ? data.statusUpdateByUserId.username : 'None',
          };
        }),
      );
    }
  }, [dataState]);

  return (
    <Content className="container">
      <Space direction="vertical" size="middle" style={{ display: 'flex' }}>
        {' '}
        <div className={styles.headerTable}>
          <h1>List Borrow Books</h1>
        </div>
        <Table rowKey={(dataState) => dataState.id} columns={columns} dataSource={dataTable} />
      </Space>
    </Content>
  );
};

export default BorrowBooks;
