import { register, login } from '../api/remote'
import { REGISTER_SUCCESS, LOGIN_SUCCESS, REDIRECTED } from '../actions/actionTypes'

function registerSuccess() {
    return {
        type: REGISTER_SUCCESS
    }
}

function loginSuccess() {
    return {
        type: LOGIN_SUCCESS
    }
}

function redirectAction() {
    return {
        type: REDIRECTED
    }
}

function registerAction(name, email, password) {
    return async (dispatch) => {
        return register(name, email, password)
            .then(response => {
                if (response.success) {
                    dispatch(registerSuccess());
                }
            })

    }
}

function loginAction(email, password) {
    return async (dispatch) => {
        return login(email, password)
            .then(token => {
                sessionStorage.setItem('authToken', token.token);
                sessionStorage.setItem('user', token.user.name);
                dispatch(loginSuccess());
            })

    }
}


export { registerAction, loginAction, redirectAction}