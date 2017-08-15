function startApp() {
    "use strict";
    const mainDiv = $("main");
    const loginRegisterTemplatePath = "templates/loginRegisterTemplate.hbs";
    const welcomePageTemplatePath = "templates/welcomeTemplate.hbs";
    const listAdsTemplatePath = "templates/listAdsTemplate.hbs";
    const adPartialTemplatePath = "templates/adPartialTemplate.hbs";
    const createEditAdTemplatePath = "templates/createEditAdTemplate.hbs";

    $(document).on({
        ajaxStart: () => $('#loadingBox').show(),
        ajaxStop: () => $('#loadingBox').fadeOut()
    });

    $("#menu").find("a").show();
    createWelcomeView();
    isUserLoggedIn();

    function showView(view) {
        let template = {};
        switch (view) {
            case 'home':
                return $.get(welcomePageTemplatePath);
            case 'login':
            case 'register':
                return $.get(loginRegisterTemplatePath);
            case 'create':
            case 'edit':
                return $.get(createEditAdTemplatePath);
            case 'details':
                $('#viewDetailsAd').show();
                break;
        }
        return template;
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

    //events
    $('#linkLogin').click(createLoginView);
    $('#linkRegister').click(createRegisterView);
    $('#linkLogout').click(logoutUser);
    $('#linkListAds').click(createListAdsView);
    $('#linkCreateAd').click(createCreateAdView);


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

    function userLogggedOut() {
        let greetingsSpan = $("#loggedInUser");
        greetingsSpan.text(``);
        greetingsSpan.hide();
        $("#linkLogin").show();
        $("#linkRegister").show();
        $("#linkLogout").hide();
        $("#linkListAds").hide();
        $("#linkCreateAd").hide();
    }

    async function createWelcomeView() {
        let templateSource = await showView('home');
        let homeSource = {
            title: "Welcome",
            message: "Welcome to our advertisement site."
        };
        let compiledTemplate = Handlebars.compile(templateSource);
        let homeHtml = compiledTemplate(homeSource);
        renderView(homeHtml, 'viewHome');
    }

    async function createCreateAdView() {
        let templateSource = await showView('create');
        let createAdSource = {
            viewType: 'Create',
            caption: 'Create new Advertisement',
        }
        let compiledTemplate = Handlebars.compile(templateSource);
        let createAdhtml = compiledTemplate(createAdSource);
        renderView(createAdhtml, 'viewCreateAd');
        $("#buttonCreateAd").click(createAd);
    }

    async function createListAdsView() {
        let [listAdsTemplate, adPartialTemplate] =
            await Promise.all([$.get(listAdsTemplatePath), $.get(adPartialTemplatePath)]);

        Handlebars.registerPartial('ad', adPartialTemplate);
        let compiledTemplate = Handlebars.compile(listAdsTemplate);
        let context = await getAllAds();
        let adsHtml = compiledTemplate(context);
        renderView(adsHtml, 'viewAds');
        attachEvents();
    }

    async function createRegisterView() {
        let templateSource = await showView('register');
        let registerSource = {
            viewName: "Register",
            viewClass: "Register",
            formTitle: "Please Register",
            formId: 'Register',
            buttonId: "registerButton",
            formType: "register"
        };
        let compiledTemplate = Handlebars.compile(templateSource);
        let registerHtml = compiledTemplate(registerSource);

        renderView(registerHtml, 'viewRegister');
        $("#registerButton").click(register);
    }

    async function createLoginView() {
        let templateSource = await showView('login');
        let loginSource = {
            viewName: "Login",
            viewClass: "Login",
            formTitle: "Please login",
            formId: 'Login',
            buttonId: "loginButton",
            formType: "login"
        };
        let compiledTemplate = Handlebars.compile(templateSource);
        let loginHtml = compiledTemplate(loginSource);
        renderView(loginHtml, 'viewLogin');
        $("#loginButton").click(login);
    }

    async function register() {
        let credentials = grabCredentials();
        try {
            saveSession(await requester.post('user', '', credentials, 'basic'));
            createWelcomeView();
        }
        catch (e) {
            console.log(e);
        }
    }

    async function login() {
        let credentials = grabCredentials();
        try {
            let data = await requester.post('user', 'login', credentials, 'basic');
            saveSession(data);
            createListAdsView();
        }
        catch (e) {
            console.log(e);
        }

    }

    async function logoutUser() {
        try {
            await requester.post("user", "_logout", {authtoken: localStorage.authtoken});
            localStorage.clear();
            userLogggedOut();
            createWelcomeView();
        }
        catch (e) {
            console.log(e);
        }

    }

    async function createAd() {
        let ad = grabAdDetails();
        try {
            await requester.post("appdata",'adverts', ad,'');
        }
        catch (e) {
            console.log(e)
        }
    }

    async function getAllAds() {
        return {
            ads: await requester.get('appdata', 'adverts', '')
        };
    }

    function deleteItem(e) {
        console.log($(e.target).attr('data-id'));
    }

    function editItem() {
        console.log("kurrrrrrrrrrrr")
    }

    function attachEvents() {
        $(".deleteBtn").click(deleteItem);
        $(".editBtn").click(editItem);

    }

    function renderView(viewHtml, viewId) {
        mainDiv.html(viewHtml);
        $(`#${viewId}`).show();
    }

    function grabCredentials() {
        let form = $(".form");
        let username = form.find('input[name="username"]').val();
        let password = form.find('input[name="passwd"]').val();
        return {username, password};
    }

    function grabAdDetails() {
        let form = $(".form");

        let id = form.find('input[name="id"]').val();
        let publisher = form.find('input[name="publisher"]').val();
        let title = form.find('input[name="title"]').val();
        let description = form.find('textarea[name="description"]').val();
        let date = form.find('input[name="datePublished"]').val();
        let price = form.find('input[name="price"]').val();

        if (id) {
            return {
                id,
                publisher,
                title,
                description,
                date,
                price
            }
        }
        else {
            return {
                publisher : localStorage["id"],
                title,
                description,
                date,
                price
            }
        }

    }

    function isUserLoggedIn() {
        let usernameInLocalStorage = localStorage.username;
        if (usernameInLocalStorage) {
            userLoggedIn(usernameInLocalStorage);
        }
        else {
            userLogggedOut();
        }
    }
}