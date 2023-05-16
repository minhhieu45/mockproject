import { LockOutlined, UserOutlined, GoogleCircleFilled } from '@ant-design/icons';
import { Button, Checkbox, Form, Input, Row, Col } from 'antd';
export default function Register() {
    const onFinish = (values) => {
        console.log('Received values of form: ', values);
    };
    return (
        <Form
            name="normal_login"
            className="login-form"
            initialValues={{
                remember: true,
            }}
            onFinish={onFinish}
        >
            <Form.Item>
                <h2 style={{ marginBottom: '10px' }}>Sign Up</h2>
                <p>Create your new account.</p>
            </Form.Item>
            <Form.Item

                name="email"
                rules={[
                    {
                        required: true,
                        message: 'Please input your email!',
                    },
                ]}
            >
                <Input prefix={<UserOutlined className="site-form-item-icon" />} placeholder="Enter email" />
            </Form.Item>
            <Form.Item
                name="password"
                rules={[
                    {
                        required: true,
                        message: 'Please input your password!',
                    },
                ]}
            >
                <Input.Password
                    prefix={<LockOutlined className="site-form-item-icon" />}
                    type="password"
                    placeholder="Enter password"
                />
            </Form.Item>
            <Form.Item
                name="passwordconfirm"
                rules={[
                    {
                        required: true,
                        message: 'Please input your password confirm!',
                    },
                ]}
            >
                <Input.Password
                    prefix={<LockOutlined className="site-form-item-icon" />}
                    type="password"
                    placeholder="Enter password confirm"
                />
            </Form.Item>
            <Form.Item
                name="name"
                rules={[
                    {
                        required: true,
                        message: 'Please input your name!',
                    },
                ]}
            >
                <Input
                    type="text"
                    placeholder="Enter your name"
                />
            </Form.Item>
            <Form.Item
                name="idCard"
                rules={[
                    {
                        required: true,
                        message: 'Please input your card!',
                    },
                ]}
            >
                <Input
                    type="text"
                    placeholder="Enter your id card"
                />
            </Form.Item>
            <Form.Item
                name="phone"
                rules={[
                    {
                        required: true,
                        message: 'Please input your name!',
                    },
                ]}
            >
                <Input
                    type="text"
                    placeholder="Enter your phone"
                />
            </Form.Item>
            <Form.Item name="remember" valuePropName="checked" style={{ marginTop: "-10px" }}>
                <Checkbox>I agree with the terms of use</Checkbox>
            </Form.Item>
            <Form.Item style={{ marginTop: '-20px' }}>
                <Button type="primary" htmlType='submit' block className="login-form-button" style={{ marginBottom: '10px' }}>
                    Sign up
                </Button>
                <p style={{ marginBottom: '10px' }}>or sign up with other accounts ?</p>
                <a href='#'><GoogleCircleFilled style={{ fontSize: '30px' }} /></a>
                <p>Already have an account? <a href='/login'>Click here to sign in.</a></p>
            </Form.Item>
        </Form>
    );
};