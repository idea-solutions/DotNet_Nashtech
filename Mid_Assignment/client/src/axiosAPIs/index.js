import axios from 'axios';
const BASE_URL = 'https://localhost:7233/api';
export const CATEGORY = 'category';
export const BOOK = 'book';

export const getAllData = async (url) => {
  let data = [];
  await axios
    .get(`${BASE_URL}/${url}`)
    .then((response) => {
      data = [...response.data];
    })
    .catch((err) => {
      console.log({ err });
    });
  return data;
};

export const deleteData = async (url, id) => {
  let data = [];
  await axios
    .delete(`${BASE_URL}/${url}/${id}`)
    .then((response) => {
      data = [...response.data];
    })
    .catch((err) => {
      console.log({ err });
    });
  return data;
};

export const createData = async (url, data) => {
  let response = [];
  await axios
    .post(`${BASE_URL}/${url}`, data)
    .then((res) => {
      response = [...res.data];
    })
    .catch((err) => {
      console.log({ err });
    });
  return response;
};

export const updateData = async (url, data) => {
  let response = [];
  await axios
    .put(`${BASE_URL}/${url}`, data)
    .then((res) => {
      response = [...res.data];
    })
    .catch((err) => {
      console.log({ err });
    });
  return response;
};
