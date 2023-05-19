import { createContext, useState } from "react";

export const UserContext = createContext();
const UserContextProvider = (props) => {
    const [user, setUser] = useState();
    const onSetUser = (value) => {
        localStorage.setItem("token", JSON.stringify(value.token))
        setUser(value.data);
    }
    return (
        <UserContext.Provider value={{
            user,

            onSetUser
        }}>
            {props.children}
        </UserContext.Provider>
    )
};
export default UserContextProvider;