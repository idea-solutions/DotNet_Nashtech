import { Button, Space, Table, Input, Modal, Tag, Select, Checkbox } from 'antd';
import { Content } from 'antd/lib/layout/layout';

import React, { useContext, useEffect, useState } from 'react';
import { createData, deleteData, getAllData, updateData } from '../../axiosAPIs';
import styles from './Books.module.scss';
import { ExclamationCircleOutlined } from '@ant-design/icons';
import AuthContext from '../../contexts/AuthContext';
import { BOOK, BORROW_BOOKS, CATEGORY } from '../../constants';

const Books = () => {
  const [dataBooks, setDataBooks] = useState([]);
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
  const { auth } = useContext(AuthContext);

  const { confirm } = Modal;

  const [dataCategories, setDataCategories] = useState([]);
  const [dataBorrowBooks, setDataBorrowBooks] = useState([]);

  const getData = async () => {
    const dataBook = await getAllData(BOOK);
    const dataCategory = await getAllData(CATEGORY);
    const dataBorrowBook = await getAllData(BORROW_BOOKS);
    setDataBooks(dataBook);
    setDataCategories(dataCategory);
    setDataBorrowBooks(dataBorrowBook);
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
      hidden: auth?.role === 'SuperUser' ? false : true,
    },
    {
      title: 'Borrow Books',
      key: 'borrow-books',
      render: (_, record) => (
        <>
          <Space size="middle">
            {booksBorrowId?.includes(record.id) ? (
              <Checkbox
                checked={booksBorrowId?.includes(record.id)}
                disabled={booksBorrowId?.includes(record.id)}
                onChange={() => onChangeCheckbox(record.id)}
              >
                Borrow
              </Checkbox>
            ) : (
              <Checkbox onChange={() => onChangeCheckbox(record.id)}>Borrow</Checkbox>
            )}
          </Space>
        </>
      ),
      hidden: auth?.role === 'SuperUser' ? true : false,
    },
  ].filter((column) => !column.hidden);

  const [idsSelectArr, setIdsSelectArr] = useState([]);

  const onChangeCheckbox = (id) => {
    if (idsSelectArr.includes(id)) {
      setIdsSelectArr(idsSelectArr.filter((idSelect) => idSelect !== id));
    } else {
      setIdsSelectArr([...idsSelectArr, id]);
    }
  };

  const [booksBorrowId, setBooksBorrowId] = useState([]);

  useEffect(() => {
    const borrowBooksArr = dataBorrowBooks.filter((borrowBook) => borrowBook.requestedBy.id === auth?.id);
    const id = Array.from(
      new Set(
        borrowBooksArr
          .filter((a) => a.status === 'Approved')
          .map((x) => x.books)
          .map((book) => book.map((b) => b.id))
          .flat(),
      ),
    );
    setBooksBorrowId(id);
  }, [auth, auth?.id, dataBorrowBooks]);

  const [msg, setMsg] = useState('');
  const handleBorrowBooks = async () => {
    const res = await createData(BORROW_BOOKS, { BookIds: idsSelectArr });

    if (res.code === 'ERR_BAD_REQUEST') {
      setMsg(res.response.data);
    } else {
      setMsg('Borrowing book successfully, waiting for approval');
    }

    getData();
  };

  useEffect(() => {
    if (msg !== '') alert(msg);
  }, [msg]);

  const [searchValue, setSearchValue] = useState('');
  const [pacientes, setPacientes] = useState('');

  const onSearch = (value) => {
    setSearchValue(value);
  };

  useEffect(() => {
    const newPacientes = dataBooks?.filter((value) => value.name.toLowerCase().includes(searchValue.toLowerCase()));
    setPacientes(newPacientes);
  }, [dataBooks, searchValue]);

  console.log('dataBooks', dataBooks);

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

  const options = dataCategories.map((category) => {
    return { label: category.name, value: category.id };
  });

  return (
    <Content className="container">
      <Space direction="vertical" size="middle" style={{ display: 'flex' }}>
        {' '}
        <div className={styles.headerTable}>
          <h1>List Book</h1>
          <div className="d-flex">
            <Input.Search placeholder="search name books" allowClear onSearch={onSearch} className={styles.searchTable} />
            {auth?.role === 'SuperUser' ? (
              <Button type="primary" onClick={showModalAdd}>
                Add
              </Button>
            ) : (
              <Button type="primary" onClick={handleBorrowBooks}>
                Borrow Books
              </Button>
            )}
          </div>
        </div>
        <Table rowKey={(dataState) => dataState.id} columns={columns} dataSource={pacientes} />
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
  );
};

export default Books;
