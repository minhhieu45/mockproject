import { Routes, Route } from "react-router-dom"
import UserContextProvider from "../../contexts/UserContext"
import Login from "./components/Login";
import Register from "./components/Register";
import ForgotPassword from "./components/ForgotPassword"
import ConfirmEmail from "./components/ConfirmEmail";
import Home from "./components/Home";
export const Index = () => {
    return (
        <UserContextProvider>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/confirm" element={<ConfirmEmail />} />
                <Route path="confirm/:id" element={<ConfirmEmail />} />
                <Route path="/login" element={<Login />} />
                <Route path="/register" element={<Register />} />
                <Route path="/forgot" element={<ForgotPassword />} />
            </Routes>
        </UserContextProvider>
    )
}