import axios from 'axios';
import { BASE_URL, TOKEN_KEY } from '../constants';

export async function logIn(loginInfo) {
  const url = `${BASE_URL}/authentication`;

  let response = undefined;

  await axios
    .post(url, loginInfo)
    .then((result) => {
      response = result.data;
      localStorage.setItem(TOKEN_KEY, response);
    })
    .catch((error) => {
      console.log({ error });
    });

  return response;
}
