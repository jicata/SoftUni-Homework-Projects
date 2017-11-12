import Credentials from '../Credentials'

let PostService = {
    all: () => {
        return fetch(`${Credentials.hostUrl}/appdata/${Credentials.appId}/posts?query={}&sort={"_kmd.ect": -1}`, {
            method: 'GET',
            headers: {
                Authorization: 'Kinvey ' + `${window.localStorage.authtoken}`
            }
        })
            .then(res => {
                return res.json();
            })
    }
}

export default PostService