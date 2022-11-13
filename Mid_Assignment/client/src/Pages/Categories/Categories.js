import { Button, Input, Modal, Space, Table } from 'antd';
import { Content } from 'antd/lib/layout/layout';
import { ExclamationCircleOutlined } from '@ant-design/icons';
import React, { useContext, useEffect, useState } from 'react';
import { createData, deleteData, getAllData, updateData } from '../../axiosAPIs';
import { CATEGORY } from '../../constants';
import AuthContext from '../../contexts/AuthContext';
import styles from './Categories.module.scss';

const Categories = () => {
  const [dataState, setDataState] = useState([]);
  const [dataAdd, setDataAdd] = useState({ name: '' });
  const [dataUpdate, setDataUpdate] = useState({ id: null, name: '' });
  const [error, setError] = useState('');
  const [buttonDisabled, setButtonDisabled] = useState(true);
  const [isModalOpenAdd, setIsModalOpenAdd] = useState(false);
  const [isModalOpenUpdate, setIsModalOpenUpdate] = useState(false);
  const { confirm } = Modal;

  const getData = async () => {
    const data = await getAllData(CATEGORY);
    setDataState(data);
  };

  useEffect(() => {
    getData();
  }, []);

  const { auth } = useContext(AuthContext);

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
      title: 'Action',
      key: 'action',
      render: (_, record) => (
        <Space size="middle">
          <Button type="primary" onClick={() => showModalUpdate(record)}>
            Update
          </Button>
          <Button type="primary" danger onClick={() => showConfirmDelete(record)}>
            Delete
          </Button>
        </Space>
      ),
      hidden: auth?.role === 'SuperUser' ? false : true,
    },
  ].filter((column) => !column.hidden);

  const [searchValue, setSearchValue] = useState('');
  const [pacientes, setPacientes] = useState('');

  const onSearch = (value) => {
    setSearchValue(value);
  };

  useEffect(() => {
    const newPacientes = dataState.filter((value) => value.name.toLowerCase().includes(searchValue.toLowerCase()));
    setPacientes(newPacientes);
  }, [dataState, searchValue]);

  const handleDelete = async (record) => {
    await deleteData(CATEGORY, record.id);
    getData();
  };

  // Add
  const showModalAdd = () => {
    setIsModalOpenAdd(true);
    setError('');
    setButtonDisabled(true);
  };
  const handleOkAdd = async () => {
    setIsModalOpenAdd(false);
    await createData(CATEGORY, dataAdd);
    getData();
    setDataAdd({ name: '' });
  };

  const handleCancelAdd = () => {
    setIsModalOpenAdd(false);
  };

  const handleBlurAdd = (e) => {
    if (e.target.value) {
      setError('');
    } else {
      setError('This field is required');
    }
  };

  const handleChangeAdd = (e) => {
    setError('');
    setDataAdd({ [e.target.name]: e.target.value });
  };
  // End Add

  // Update
  const showModalUpdate = (record) => {
    setIsModalOpenUpdate(true);
    setError('');
    setDataUpdate({ id: record.id, name: record.name });
    setButtonDisabled(true);
  };

  const handleBlurUpdate = (e) => {
    if (e.target.value) {
      setError('');
    } else {
      setError('This field is required');
    }
  };

  const handleChangeUpdate = (e) => {
    setError('');
    setDataUpdate({ ...dataUpdate, [e.target.name]: e.target.value });
  };

  const handleOkUpdate = async () => {
    setIsModalOpenUpdate(false);
    await updateData(CATEGORY, dataUpdate);
    getData();
  };

  const handleCancelUpdate = () => {
    setIsModalOpenUpdate(false);
  };
  // End Update

  useEffect(() => {
    if (dataAdd || dataUpdate) {
      setButtonDisabled(false);
    }
  }, [dataAdd, dataUpdate]);

  const showConfirmDelete = (record) => {
    confirm({
      title: 'Do you want to delete this category?',
      icon: <ExclamationCircleOutlined />,
      onOk() {
        handleDelete(record);
      },
      onCancel() {},
    });
  };

  return (
    <>
      <Content className="container">
        <Space direction="vertical" size="middle" style={{ display: 'flex' }}>
          {' '}
          <div className={styles.headerTable}>
            <h1>List Category</h1>
            <div className="d-flex">
              <Input.Search
                placeholder="search name category"
                allowClear
                onSearch={onSearch}
                className={styles.searchTable}
              />
              {auth?.role === 'SuperUser' && (
                <Button type="primary" onClick={showModalAdd}>
                  Add
                </Button>
              )}
            </div>
          </div>
          <Table rowKey={(dataState) => dataState.id} columns={columns} dataSource={pacientes} />
        </Space>

        <Modal
          title="Create Category"
          open={isModalOpenAdd}
          onOk={handleOkAdd}
          okButtonProps={{ disabled: buttonDisabled }}
          onCancel={handleCancelAdd}
          destroyOnClose={true}
        >
          <Input placeholder="Name" name="name" onBlur={handleBlurAdd} onChange={handleChangeAdd} />
          {error && <p className={styles.msgError}>{error}</p>}
        </Modal>

        <Modal
          title="Update Category"
          open={isModalOpenUpdate}
          onOk={handleOkUpdate}
          okButtonProps={{ disabled: buttonDisabled }}
          onCancel={handleCancelUpdate}
          destroyOnClose={true}
        >
          <Input
            placeholder="Name"
            name="name"
            onBlur={handleBlurUpdate}
            value={dataUpdate.name}
            onChange={handleChangeUpdate}
          />
          {error && <p className={styles.msgError}>{error}</p>}
        </Modal>
      </Content>
    </>
  );
};

export default Categories;
