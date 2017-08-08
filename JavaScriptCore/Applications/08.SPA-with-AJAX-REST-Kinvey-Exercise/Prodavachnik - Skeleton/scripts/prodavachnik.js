function startApp() {
    "use strict";


    $("#menu").find("a").show();
    $("#viewHome").show();


    // Attach listeners
    $('header').find('a[data-target]').click(navigateTo);
    $("#buttonLoginUser").click(login);

    function navigateTo(e) {
        $('section').hide();
        let target = $(e.target).attr("data-target");
        $("#" + target).show();
    }


    let requester = (() => {
        const appId = 'kid_SJhx5dvvZ';
        const appSecret = 'b24ec0d1cfac4d7186d5b7cc0671e046';
        const baseKinveyUrl = 'https://baas.kinvey.com/';

        function createAuth(type) {
            if (type === 'basic') {
                return 'Basic ' + btoa(appId + ":" + appSecret);
            }
            return 'Kinvey' + localStorage.getItem('authtoken');
        }

        function createRequest(method, module, url, auth) {
            return {
                url: baseKinveyUrl + module + "/" + appId + "/" + url,
                method,
                headers: {
                    'Authorization': createAuth(auth),
                    //'Content-Type':
                }
            };
        }

        function get(module, url, auth) {
            return $.ajax(createRequest('GET', module, url, auth));
        }

        function post(module, url, data, auth) {
            let req = createRequest('POST', module, url, auth);
            req.data = JSON.stringify(data);
            return $.ajax(req);
        }

        function update(module, url, data, auth) {
            let req = createRequest('PUT', module, url, auth);
            req.data = data;
            return $.ajax(req);
        }

        function remove(module, url, auth) {
            let req = createRequest('DELETE', module, url, auth);
            return $.ajax(req);
        }

        return {
            get,
            post,
            update,
            remove
        }
    })();

    function saveSession(data) {
        localStorage.setItem('username', data.username);
        localStorage.setItem('id', data._id);
        localStorage.setItem('authtoken', data._kmd.authtoken);
    }

    async function login() {
        let form = $("#formLogin");
        let username = form.find('input[name="username"]').val();
        let password = form.find('input[name="passwd"]').val();

        let data = {
            username,
            password
        };

        saveSession(await requester.post("user", 'login', data, 'basic'));
        $("section").hide();
        $("#viewAds").show();
    }
}