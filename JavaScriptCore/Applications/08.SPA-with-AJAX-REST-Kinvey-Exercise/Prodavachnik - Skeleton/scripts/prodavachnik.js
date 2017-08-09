function startApp() {
    "use strict";


    $("#menu").find("a").show();

    function navigateTo(e) {
        $('section').hide();
        let target = $(e.target).attr("data-target");
        $("#" + target).show();
    }

    function showView(view){
        $("section").hide();
        switch (view){
            case 'home':
                $('#viewHome').show();
                break;
            case 'login':
                $('#viewLogin').show();
                break;
            case 'register':
                $('#viewRegister').show();
                break;
            case 'ads':
                $('#viewAds').show();
                loadAds();
                break;
            case 'create':
                $('#viewCreateAd').show();
                break;
            case 'details':
                $('#viewDetailsAd').show();
                break;
            case 'edit':
                $('#viewEditAd').show();
                break;

        }

    }

    // Attach listeners
    $("#linkHome").click(()=>showView('home'));
    $("#linkLogin").click(()=>showView('login'));
    $("#linkRegister").click(()=>showView('register'));
    $("#linkCreateAd").click(()=>showView('create'));
    $("#linkListAds").click(()=>showView('ads'));
    $("#linkLogout").click(logout);
    $("#buttonLoginUser").click(login);
    $("#buttonRegisterUser").click(register);


    // Notifications

    // Bind the info / error boxes
    $(".notification").click(function() {
        $(this).fadeOut();
    });

    // Attach AJAX "loading" event listener
    $(document).on({
        ajaxStart: function() { $("#loadingBox").fadeIn() },
        ajaxStop: function() { $("#loadingBox").fadeOut('slow') }
    });
    
    function showInfo(message) {
        $('#infoBox').text(message);
        $('#infoBox').show();
        setTimeout(function() {
            $('#infoBox').fadeOut();
        }, 3000);
    }

    function showError(errorMsg) {
        $('#errorBox').text("Error: " + errorMsg);
        $('#errorBox').show();
    }
    
    function handleError(reason) {
        showError(reason.responseJSON.description);
    }

    let requester = (() => {
        const appId = 'kid_SJhx5dvvZ';
        const appSecret = 'b24ec0d1cfac4d7186d5b7cc0671e046';
        const baseKinveyUrl = 'https://baas.kinvey.com/';

        function createAuth(type) {
            if (type === 'basic') {
                return 'Basic ' + btoa(appId + ":" + appSecret);
            }
            return 'Kinvey ' + localStorage.getItem('authtoken');
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
            req.data = data;
            return $.ajax(req);
        }

        function update(module, url, data, auth) {
            let req = createRequest('PUT', module, url, auth);
            req.data = JSON.stringify(data);
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

    if (localStorage.getItem("authtoken")
        && localStorage.getItem("username")) {
        userLoggedIn(localStorage.getItem("username"));
    }
    else {
        userLoggedOut()
    }
    $("#viewHome").show();

    function saveSession(data) {
        localStorage.setItem('username', data.username);
        localStorage.setItem('id', data._id);
        localStorage.setItem('authtoken', data._kmd.authtoken);
        userLoggedIn(data.username);
    }

    function userLoggedIn(username) {
        let greetingsSpan = $("#loggedInUser");
        greetingsSpan.text(`Welcome ${username}!`);
        greetingsSpan.show();
        $("#linkLogin").hide();
        $("#linkRegister").hide();
        $("#linkLogout").show();
        $("#linkListAds").show();
        $("#linkCreateAd").show();
    }

    function userLoggedOut() {
        let greetingsSpan = $("#loggedInUser");
        greetingsSpan.text(``);
        greetingsSpan.hide();
        $("#linkLogin").show();
        $("#linkRegister").show();
        $("#linkLogout").hide();
        $("#linkListAds").hide();
        $("#linkCreateAd").hide();
    }

    async function login() {
        let form = $("#formLogin");
        let username = form.find('input[name="username"]').val();
        let password = form.find('input[name="passwd"]').val();

        let data = {
            username,
            password
        };

        try {
            saveSession(await
                requester.post("user", 'login', data, 'basic')
            )
            ;
            $("section").hide();
            $("#viewAds").show();
        }
        catch (error) {
            handleError(error);
        }

    }

    async function register() {
        let registerForm = $("#formRegister");
        let username = registerForm.find('input[name="username"]').val();
        let password = registerForm.find('input[name="passwd"]').val();

        let newUser = {
            username,
            password
        };

        try {
            saveSession(await requester.post("user", '', newUser, 'basic'));
            $("section").hide();
            $("#viewAds").show();
        }
        catch (error) {
            handleError(error);
        }
    }

    async function logout() {
        try {
            let data = await requester.post("user", '_logout', {authtoken: localStorage['authtoken']});
            localStorage.clear();
            userLoggedOut();
            $("section").hide();
            $("#viewHome").show();

        }
        catch (error) {
           handleError(error);
        }
    }
    
    async function loadAds() {
        let adverts = await requester.get('appdata','adverts');
        console.log(adverts);
    }
}