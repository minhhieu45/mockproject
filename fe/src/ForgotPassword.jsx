import { LockOutlined, UserOutlined, GoogleCircleFilled } from '@ant-design/icons';
import { Button, Checkbox, Form, Input, Row, Col } from 'antd';
export default function ForgotPassword() {
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
                <h2 style={{ marginBottom: '10px' }}>Forgot Password</h2>
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
                <Input placeholder="Enter email" type='email' />
            </Form.Item>
            <Form.Item>
                <p>You will receive a new password provided by us. This password will be valid for 10 minutes. Please go to your email to receive your password and change it</p>
            </Form.Item>
            <Form.Item style={{ marginTop: '-20px' }}>
                <Button type="primary" htmlType='submit' block className="login-form-button" style={{ marginBottom: '10px' }}>
                    Send email
                </Button>
                <p>Don't have an account? <a href='login'>Click here to sign up.</a></p>
            </Form.Item>
        </Form>
    );
};