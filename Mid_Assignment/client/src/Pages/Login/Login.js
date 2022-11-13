import { LockOutlined, UserOutlined } from '@ant-design/icons';
import { Button, Card, Form, Input } from 'antd';
import React, { useContext, useState } from 'react';
import { redirect, useNavigate } from 'react-router-dom';
import backgroundImage from '../../assets/background.jpg';
import { logIn } from '../../axiosAPIs/AuthenticationApi';
import AuthContext from '../../contexts/AuthContext';
import styles from './Login.module.scss';

const Login = () => {
  const { setAuth } = useContext(AuthContext);
  const navigate = useNavigate();
  const onFinish = async (values) => {
    const token = await logIn(values);
    setAuth(token);
    navigate('/');
  };

  return (
    <div
      className={styles.loginPage}
      style={{
        backgroundImage: `url(${backgroundImage})`,
        backgroundRepeat: 'no-repeat',
        backgroundPosition: 'center',
        backgroundSize: 'cover',
      }}
    >
      <Card className={styles.loginForm}>
        <div className={styles.header}>
          <h1>Admin Portal</h1>
          <p>Admin Portal for Nash Tech</p>
        </div>
        <Form
          name="normal_login"
          className="login-form"
          initialValues={{
            remember: true,
          }}
          onFinish={onFinish}
        >
          <Form.Item
            name="username"
            rules={[
              {
                required: true,
                message: 'Please input your Username!',
              },
            ]}
          >
            <Input prefix={<UserOutlined className="site-form-item-icon" />} placeholder="Username" />
          </Form.Item>
          <Form.Item
            name="password"
            rules={[
              {
                required: true,
                message: 'Please input your Password!',
              },
            ]}
          >
            <Input prefix={<LockOutlined className="site-form-item-icon" />} type="password" placeholder="Password" />
          </Form.Item>

          <Form.Item>
            <Button type="primary" htmlType="submit" className="login-form-button">
              Log in
            </Button>
          </Form.Item>
        </Form>
      </Card>
    </div>
  );
};

export default Login;
