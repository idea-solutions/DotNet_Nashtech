import React from 'react';
import { Menu, Grid } from 'antd';
import { Link } from 'react-router-dom';
const { useBreakpoint } = Grid;

const LeftMenu = () => {
  const { md } = useBreakpoint();
  const items = [
    {
      label: <Link to={'/'}>Home</Link>,
      key: 'home',
    },
    {
      label: <Link to={'/categories'}>Categories</Link>,
      key: 'categories',
    },
    {
      label: <Link to={'/books'}>Books</Link>,
      key: 'books',
    },
    {
      label: <Link to={'/profile'}>Profile</Link>,
      key: 'profile',
    },
  ];
  return <Menu defaultSelectedKeys="home" mode={md ? 'horizontal' : 'inline'} items={items} />;
};

export default LeftMenu;
