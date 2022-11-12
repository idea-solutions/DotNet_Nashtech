import React, { useContext } from 'react';
import { Menu, Grid } from 'antd';
import { Link } from 'react-router-dom';
import AuthContext from '../../contexts/AuthContext';
import { TOKEN_KEY } from '../../constants';

const { useBreakpoint } = Grid;

const RightMenu = () => {
  const { md } = useBreakpoint();

  const { auth, setAuth } = useContext(AuthContext);

  const onLogOut = () => {
    localStorage.removeItem(TOKEN_KEY);
    setAuth(undefined);
  };

  console.log('auth', auth);

  const items = [
    {
      label: auth === undefined ? <Link to="/login">Login</Link> : <div onClick={onLogOut}>Logout</div>,
      key: auth === undefined ? 'login' : 'logout',
    },
  ];
  return <Menu mode={md ? 'horizontal' : 'inline'} items={items} />;
};

export default RightMenu;
