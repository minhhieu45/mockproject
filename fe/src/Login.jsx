import { LockOutlined, UserOutlined, GoogleCircleFilled } from '@ant-design/icons';
import { Button, Checkbox, Form, Input, Row, Col } from 'antd';
export default function Login() {
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
                <h2 style={{ marginBottom: '10px' }}>Sign In</h2>
                <p>Sign in to stay connnected.</p>
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
                <Input prefix={<UserOutlined className="site-form-item-icon" />} placeholder="Enter email" type='email' />
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
            <Form.Item>
                <Row>
                    <Col span={12} >
                        <Form.Item name="remember" valuePropName="checked" style={{ float: 'left' }}>
                            <Checkbox>Remember me</Checkbox>
                        </Form.Item>
                    </Col>
                    <Col span={12}>
                        <a className="login-form-forgot" href="/forgot" style={{ float: 'right' }}>
                            Forgot password
                        </a>
                    </Col>
                </Row>
            </Form.Item>
            <Form.Item style={{ marginTop: '-20px' }}>
                <Button type="primary" htmlType='submit' block className="login-form-button" style={{ marginBottom: '10px' }}>
                    Log in
                </Button>
                <p style={{ marginBottom: '10px' }}>or sign in with other accounts ?</p>
                <a href='#'><GoogleCircleFilled style={{ fontSize: '30px' }} /></a>
                <p>Don't have an account? <a href='/register'>Click here to sign up.</a></p>
            </Form.Item>
        </Form>
    );
};