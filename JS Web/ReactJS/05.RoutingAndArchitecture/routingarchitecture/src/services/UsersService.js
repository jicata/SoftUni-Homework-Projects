import Credentials from '../Credentials'

let UserService = {
    login: (payload) => {
        return fetch(`${Credentials.hostUrl}/user/${Credentials.appId}/login`, {
            method: 'POST',
            headers: {
                Authorization: 'Basic ' + btoa(`${Credentials.appId}:${Credentials.appSecret}`),
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(payload)
        })
            .then(res => {
                return res.json();
            });
    },
    register: (payload) => {
        return fetch(`${Credentials.hostUrl}/user/${Credentials.appId}/`, {
            method: 'POST',
            headers: {
                Authorization: 'Basic ' + btoa(`${Credentials.appId}:${Credentials.appSecret}`),
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(payload)
        })
            .then(res => {
                return res.json();
            });
    }
}

export default UserService;