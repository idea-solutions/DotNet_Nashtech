import { Button, Space, Table, Input, Modal, Tag, Select } from 'antd';
import { Content } from 'antd/lib/layout/layout';

import React, { useEffect, useState } from 'react';
import { BOOK, CATEGORY, createData, deleteData, getAllData, updateData } from '../../axiosAPIs';
import styles from './Books.module.scss';
import { ExclamationCircleOutlined } from '@ant-design/icons';

const Books = () => {
  const [dataState, setDataState] = useState('');
  const [dataAdd, setDataAdd] = useState({
    name: '',
    author: '',
    summary: '',
    categoryIds: [],
  });
  const [dataUpdate, setDataUpdate] = useState({
    id: null,
    name: '',
    author: '',
    summary: '',
    categoryIds: [],
  });
  const [error, setError] = useState({ name: '', author: '', summary: '', categoryIds: '' });
  const [buttonDisabled, setButtonDisabled] = useState(true);
  const [isModalOpenAdd, setIsModalOpenAdd] = useState(false);
  const [isModalOpenUpdate, setIsModalOpenUpdate] = useState(false);
  const { confirm } = Modal;

  const getData = async () => {
    const data = await getAllData(BOOK);
    setDataState(data);
  };

  useEffect(() => {
    getData();
  }, []);

  const columns = [
    {
      title: 'ID',
      dataIndex: 'id',
      key: 'id',
    },
    {
      title: 'Name',
      dataIndex: 'name',
      key: 'name',
      sorter: (a, b) => a.name.localeCompare(b.name),
    },
    {
      title: 'Author',
      dataIndex: 'author',
      key: 'author',
      sorter: (a, b) => a.author.localeCompare(b.author),
    },
    {
      title: 'Summary',
      dataIndex: 'summary',
      key: 'summary',
    },
    {
      title: 'Categories',
      key: 'categories',
      dataIndex: 'categories',
      render: (_, { categories }) => (
        <>
          {categories.map((category) => {
            return (
              <Tag style={{ marginBottom: '6px' }} key={category.id}>
                {category.name.toUpperCase()}
              </Tag>
            );
          })}
        </>
      ),
    },
    {
      title: 'Action',
      key: 'action',
      render: (_, record) => (
        <Space size="middle">
          <Button
            type="primary"
            onClick={() => {
              showModalUpdate(record);
            }}
          >
            Update
          </Button>
          <Button type="primary" danger onClick={() => showConfirmDelete(record)}>
            Delete
          </Button>
        </Space>
      ),
    },
  ];

  const onSearch = (value) => console.log(value);

  const handleDelete = async (record) => {
    await deleteData(BOOK, record.id);
    getData();
  };

  // Add
  const showModalAdd = () => {
    setIsModalOpenAdd(true);
    setError({ name: '', author: '', summary: '', categoryIds: '' });
    setDataAdd({
      name: '',
      author: '',
      summary: '',
      categoryIds: options[0].value ? [options[0].value] : [],
    });
    setButtonDisabled(true);
  };

  const handleOkAdd = async () => {
    setIsModalOpenAdd(false);
    await createData(BOOK, dataAdd);
    getData();
    setDataAdd({
      name: '',
      author: '',
      summary: '',
      categoryIds: [],
    });
  };

  const handleCancelAdd = () => {
    setIsModalOpenAdd(false);
  };

  const handleBlurAdd = (e) => {
    if (e.target.value) {
      setError({ name: '', author: '', summary: '', categoryIds: '' });
    } else {
      setError({ ...error, [e.target.name]: 'This field is required' });
    }
  };

  const handleChangeAdd = (e) => {
    setError({ name: '', author: '', summary: '', categoryIds: '' });
    setDataAdd({ ...dataAdd, [e.target.name]: e.target.value });
  };
  // End Add

  // Update
  const showModalUpdate = (record) => {
    setIsModalOpenUpdate(true);
    setError({ name: '', author: '', summary: '', categoryIds: '' });
    setDataUpdate({
      id: record.id,
      name: record.name,
      author: record.author,
      summary: record.summary,
      categoryIds: record.categories.map((category) => {
        return category.id;
      }),
    });
    setButtonDisabled(true);
  };

  const handleBlurUpdate = (e) => {
    if (e.target.value) {
      setError({ name: '', author: '', summary: '', categoryIds: '' });
    } else {
      setError({ ...error, [e.target.name]: 'This field is required' });
    }
  };

  const handleChangeUpdate = (e) => {
    setError({ name: '', author: '', summary: '', categoryIds: '' });
    setDataUpdate({ ...dataUpdate, [e.target.name]: e.target.value });
  };

  const handleOkUpdate = async () => {
    setIsModalOpenUpdate(false);
    await updateData(BOOK, dataUpdate);
    getData();
  };

  const handleCancelUpdate = () => {
    setIsModalOpenUpdate(false);
  };

  // End Update

  useEffect(() => {
    if (
      (dataAdd.name && dataAdd.author && dataAdd.summary && dataAdd.categoryIds !== []) ||
      (dataUpdate.name && dataUpdate.author && dataUpdate.summary && dataUpdate.categoryIds !== [])
    ) {
      setButtonDisabled(false);
    }
  }, [dataAdd, dataUpdate.author, dataUpdate.categoryIds, dataUpdate.name, dataUpdate.summary]);

  const showConfirmDelete = (record) => {
    confirm({
      title: 'Do you want to delete this book?',
      icon: <ExclamationCircleOutlined />,
      onOk() {
        handleDelete(record);
      },
      onCancel() {},
    });
  };
  const handleChangeSelectAdd = (value) => {
    setDataAdd({ ...dataAdd, categoryIds: value });
  };

  const handleChangeSelectUpdate = (value) => {
    setDataUpdate({ ...dataUpdate, categoryIds: value });
  };

  console.log({ dataUpdate });
  const [dataCategories, setDataCategories] = useState([]);
  const getAllCategory = async () => {
    const data = await getAllData(CATEGORY);
    setDataCategories(data);
  };

  useEffect(() => {
    getAllCategory();
  }, []);

  const options = dataCategories.map((category) => {
    return { label: category.name, value: category.id };
  });

  return (
    <>
      <Content className="container">
        <Space direction="vertical" size="middle" style={{ display: 'flex' }}>
          {' '}
          <div className={styles.headerTable}>
            <h1>List Book</h1>
            <div className="d-flex">
              <Input.Search placeholder="input search" allowClear onSearch={onSearch} className={styles.searchTable} />
              <Button type="primary" onClick={showModalAdd}>
                Add
              </Button>
            </div>
          </div>
          <Table rowKey={(dataState) => dataState.id} columns={columns} dataSource={dataState} />
        </Space>

        <Modal
          title="Create Book"
          open={isModalOpenAdd}
          onOk={handleOkAdd}
          okButtonProps={{ disabled: buttonDisabled }}
          onCancel={handleCancelAdd}
          destroyOnClose={true}
        >
          <Input
            className={styles.inputModal}
            placeholder="Name"
            name="name"
            onBlur={handleBlurAdd}
            onChange={handleChangeAdd}
          />
          {error.name && <p className={styles.msgError}>{error.name}</p>}
          <Input
            className={styles.inputModal}
            placeholder="Author"
            name="author"
            onBlur={handleBlurAdd}
            onChange={handleChangeAdd}
          />
          {error.author && <p className={styles.msgError}>{error.author}</p>}
          <Input
            className={styles.inputModal}
            placeholder="Summary"
            name="summary"
            onBlur={handleBlurAdd}
            onChange={handleChangeAdd}
          />
          {error.summary && <p className={styles.msgError}>{error.summary}</p>}
          <Select
            mode="multiple"
            allowClear
            style={{
              width: '100%',
            }}
            onBlur={handleBlurAdd}
            className={styles.selectModal}
            name="categoryIds"
            placeholder="Please select categories"
            defaultValue={options[0] ? [options[0]] : []}
            onChange={handleChangeSelectAdd}
            options={options}
          />
          {error.categoryIds && <p className={styles.msgError}>{error.categoryIds}</p>}
        </Modal>

        <Modal
          title="Update Book"
          open={isModalOpenUpdate}
          onOk={handleOkUpdate}
          okButtonProps={{ disabled: buttonDisabled }}
          onCancel={handleCancelUpdate}
          destroyOnClose={true}
        >
          <Input
            className={styles.inputModal}
            placeholder="Name"
            name="name"
            value={dataUpdate.name}
            onBlur={handleBlurUpdate}
            onChange={handleChangeUpdate}
          />
          {error.name && <p className={styles.msgError}>{error.name}</p>}
          <Input
            className={styles.inputModal}
            placeholder="Author"
            value={dataUpdate.author}
            name="author"
            onBlur={handleBlurUpdate}
            onChange={handleChangeUpdate}
          />
          {error.author && <p className={styles.msgError}>{error.author}</p>}
          <Input
            className={styles.inputModal}
            placeholder="Summary"
            value={dataUpdate.summary}
            name="summary"
            onBlur={handleBlurUpdate}
            onChange={handleChangeUpdate}
          />
          {error.summary && <p className={styles.msgError}>{error.summary}</p>}
          <Select
            mode="multiple"
            allowClear
            style={{
              width: '100%',
            }}
            onBlur={handleBlurUpdate}
            className={styles.selectModal}
            name="categoryIds"
            placeholder="Please select categories"
            defaultValue={dataUpdate.categoryIds}
            onChange={handleChangeSelectUpdate}
            options={options}
          />
          {error.categoryIds && <p className={styles.msgError}>{error.categoryIds}</p>}
        </Modal>
      </Content>
    </>
  );
};

export default Books;
