export const IsPhone = (value) => {
    const regex = new RegExp("^[0-9\-\+]{9,15}$");
    return regex.test(value);
}
export const IsPassword = (value) => {
    const regex = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})")
    return regex.test(value);
}
export const IsConfirmPassword = (value_1, value_2) => {
    return value_1 === value_2
}
export const IsValues = (values) => {
    if (!IsPassword(values.password)) {
        return {
            status: 0,
            message: 'Password is minimum eight characters, at least one letter, one number and one special character!'
        }
    }
    if (!IsConfirmPassword(values.password, values.passwordconfirm)) {
        return {
            status: 0,
            message: 'Password is not match!'
        }
    }
    if (!IsPhone(values.phone)) {
        return {
            status: 0,
            message: 'Phone number is invalid!'
        }
    }
    if (values.remember === false) {
        return {
            status: 0,
            message: 'Please agree to our terms!'
        }
    }
    return {
        status: 1,
        message:'Ok'
    }
}