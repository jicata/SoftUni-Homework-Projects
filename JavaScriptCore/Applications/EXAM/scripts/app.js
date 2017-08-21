/*jshint esversion: 6 */
function doMagic() {

    const mainDiv = $("main");
    const welcomePageTemplatePath = "templates/welcomeTemplate.hbs";
    const notificationsTemplatePath = "templates/notificationsTemplate.hbs";
    const catalogTemplatePath = "templates/catalogTemplate.hbs";
    const postPartialTemplatePath = "templates/postPartialTemplate.hbs";
    const menuTemplatePath = "templates/menuTemplate.hbs";
    const editCreateTemplatePath = "templates/editCreateTemplate.hbs";
    const detailsTemplatePath = "templates/detailsTemplate.hbs";
    const commentPartialTemplatePath = "templates/commentPartialTemplate.hbs";

    //events
    $("#linkMenuLogout").click(logout);


    $(document).on({
        ajaxStart: () => $('#loadingBox').show(),
        ajaxStop: () => $('#loadingBox').fadeOut()
    });


    if (currentlyActiveUser) {
        userLoggedIn();
    } else {
        $("#username").text("Hello {username}!");
        loadHomeView();
    }

    function getTemplate(viewName) {
        switch (viewName) {
            case 'notify':
                return $.get(notificationsTemplatePath);
            case 'home':
                return $.get(welcomePageTemplatePath);
            case 'allPosts':
                return Promise.all([$.get(catalogTemplatePath), $.get(postPartialTemplatePath)]);
            case 'menu':
                return $.get(menuTemplatePath);
            case 'create':
            case 'edit':
                return $.get(editCreateTemplatePath);
            case 'details':
                return Promise.all([$.get(detailsTemplatePath), $.get(commentPartialTemplatePath)]);

        }
    };

    let requester = (() => {
        const baseUrl = 'https://baas.kinvey.com/';
        const appKey = 'kid_ryZNFp-O-';
        const appSecret = 'a46414ddd0df47c9a90362e28c83af21';

        function makeAuth(type) {
            if (type === 'basic') return 'Basic ' + btoa(appKey + ':' + appSecret);
            else return 'Kinvey ' + localStorage.getItem('authtoken');
        }

        function makeRequest(method, module, url, auth) {
            return req = {
                url: baseUrl + module + '/' + appKey + '/' + url,
                method,
                headers: {
                    'Authorization': makeAuth(auth),
                    'Access-Control-Allow-Origin': 'http://localhost:63342',
                    "Access-Control-Allow-Headers": "Cache-Control, Pragma, Origin, Authorization, Content-Type, X-Requested-With",
                    "Access-Control-Allow-Methods": "GET, PUT, POST"
                }
            };
        }

        function get(module, url, auth) {
            return $.ajax(makeRequest('GET', module, url, auth));
        }

        function post(module, url, data, auth) {
            let req = makeRequest('POST', module, url, auth);
            req.data = JSON.stringify(data);
            req.headers['Content-Type'] = 'application/json';
            return $.ajax(req);
        }

        function update(module, url, data, auth) {
            let req = makeRequest('PUT', module, url, auth);
            req.data = JSON.stringify(data);
            req.headers['Content-Type'] = 'application/json';
            return $.ajax(req);
        }

        function remove(module, url, auth) {
            return $.ajax(makeRequest('DELETE', module, url, auth));
        }

        return {
            get, post, update, remove
        }
    })();

    function saveSession(data) {
        localStorage.setItem('username', data.username);
        localStorage.setItem('id', data._id);
        localStorage.setItem('authtoken', data._kmd.authtoken);
        userLoggedIn();
    }

    async function loadHomeView() {
        let homePageTemplate = await getTemplate('home');
        let homeData = {
            header: "Welcome to SeenIt",
            paragraphOne: "Share interesting links and discuss great content. It's what's happening now.",
            paragraphTwo: "Sign in or sign up in a second."
        };
        let compiledTemplate = Handlebars.compile(homePageTemplate);
        let homeHtml = compiledTemplate(homeData);
        await renderView(homeHtml, '');
        $("#loginForm").submit(login);
        $("#registerForm").submit(register);
    }

    function createBackingDataForEdit() {
        return {
            viewType: 'Edit',
            heading: 'Edit Post',
            formName: 'edit',
            descOrOpt: 'Comment',
            inputValue: 'Edit Post'
        }
    }

    function editPost(e) {
        e.preventDefault();
        let form = $("#editPostForm");
        let url = form.find('input[name="url"]').val();
        let title = form.find('input[name="title"]').val();
        let image = form.find('input[name="image"]').val();
        let description = form.find('input[name="description"]').val();

        if (!validatePost(url, title)) {
            showError("Error: I don't know, man, you fucked up... maybe have at it again?")
            return;
        }
        let editedPost = {
            author: localStorage['username'],
            title: title,
            description: description,
            url: url,
            imageUrl: image,
        };
        try {
            requester.update("appdata", `posts\\${postIdForEdit}`, editedPost, '');
            showInfo(`Post ${title} edited`);
            clearFields();
            loadCatalogView();
        }
        catch (e) {
            handleError(e)
        }


        function validatePost(url, title) {
            if (!url || !title || !url.startsWith("http")) {
                return false;
            }
            return true;
        }

        function clearFields() {
            let form = $("#createPostForm");
            form.find("input").val('');
            $('input[type="submit"]').val('Create Post');
        }

    }

    function fillOutView(post) {
        postIdForEdit = post._id;
        let form = $("#editPostForm");
        let url = form.find('input[name="url"]').val(post.url);
        let title = form.find('input[name="title"]').val(post.title);
        let image = form.find('input[name="image"]').val(post.imageUrl);
        let description = form.find('input[name="description"]').val(post.description);

        let createBtn = $('input[value="Edit Post"]');
        $(createBtn).click(editPost);
    }

    async function loadEditPostView(postId) {
        let editTemplate = await getTemplate('edit');
        let compiledTemplate = Handlebars.compile(editTemplate);
        let backingData = createBackingDataForEdit();
        let editTemplateHtml = compiledTemplate(backingData);

        let post = await requester.get("appdata", `posts\\${postId}`, '');
        if (post.author !== localStorage['username']) {
            showError('You are unauthorized to edit this post');
            return;
        }
        await renderView(editTemplateHtml);
        fillOutView(post)

    }

    async function deletePost(e) {
        let postId = $(e.target).attr('data-id');
        let post = await requester.get("appdata", `posts\\${postId}`, '');
        if (post.author !== localStorage['username']) {
            showError('You are unauthorized to delete this post');
            return;
        }
        try {
            await requester.remove("appdata", `posts\\${postId}`, '');
            showInfo('Post Deleted');
            loadCatalogView();
        }
        catch (e) {

        }
    }

    async function getAllCommentsForPost(postId) {
        let allComments = await requester.get("appdata", "comments", '');
        let associatedComments = [];
        for (let comment of allComments) {
            if (comment.postId == postId) {
                associatedComments.push(comment);
            }
        }
        return associatedComments;
    }


    async function loadDetailedPostView(postId) {
        let [detailsTemplate, commentPartialTemplate] = await getTemplate('details');

        let compiledTemplate = Handlebars.compile(detailsTemplate);
        let comments = await getAllCommentsForPost(postId);
        let post = await requester.get("appdata", `posts\\${postId}`, '');
        let detailsHtml = compiledTemplate(post);
        console.log(detailsHtml);

        await renderView(detailsHtml);
        let commentSection = $("#allComments");
        if (comments.length == 0) {
            commentSection.append($(`<p>No comments yet</p>`))
        }
        else {
            for (let comment of comments) {
                $(`<article class="comment">`)
                    .append(`<div class="comment-content">${comment.content}</div>`)
                    .append(`<a href=# class="action">[Delete]</a>`)
                    .appendTo(commentSection);

            }
        }
    }

    function prepareDetailsView(e) {
        let postId = $(e.target).attr('data-id');
        loadDetailedPostView(postId)
    }

    async function loadCatalogView() {
        let [catalogTemplate, postPartialTemplate] =
            await getTemplate('allPosts');
        Handlebars.registerPartial('post', postPartialTemplate);

        let compiledTemplate = Handlebars.compile(catalogTemplate);
        let posts = await getAllPosts();
        let catalogHtml = compiledTemplate(posts);
        await renderView(catalogHtml);
        $(".editPost").click(prepareEditPostView);
        $(".deletePost").click(deletePost);
        $('a:contains("Details")').click(prepareDetailsView);


    }

    function prepareEditPostView(e) {
        let postId = $(e.target).attr('data-id');
        loadEditPostView(postId)
    }

    function loadCreateData() {
        return {
            viewType: 'Create',
            heading: 'Create Post',
            formName: 'create',
            descOrOpt: 'Description',
            inputValue: 'Create Post'
        }
    }

    async function loadCreateView() {
        let createTemplate = await getTemplate('create');
        let compiledTemplate = Handlebars.compile(createTemplate);
        let backingFieldsData = loadCreateData();
        let createHtml = compiledTemplate(backingFieldsData);
        await renderView(createHtml);
        let createBtn = $('input[value="Create Post"]');
        $(createBtn).click(createPost);
    }

    function createPost(e) {
        e.preventDefault();
        let form = $("#createPostForm");
        let url = form.find('input[name="url"]').val();
        let title = form.find('input[name="title"]').val();
        let image = form.find('input[name="image"]').val();
        let description = form.find('input[name="description"]').val();

        if (!validatePost(url, title)) {
            showError("Error: I don't know, man, you fucked up... maybe have at it again?")
            return;
        }
        let post = {
            author: localStorage['username'],
            title: title,
            description: description,
            url: url,
            imageUrl: image,
        };
        try {
            requester.post('appdata', 'posts', post, '');
            showInfo("Post created");
            clearFields();
            loadCatalogView();
        }
        catch (e) {
            handleError(e)
        }


        function validatePost(url, title) {
            if (!url || !title || !url.startsWith("http")) {
                return false;
            }
            return true;
        }

        function clearFields() {
            let form = $("#createPostForm");
            form.find("input").val('');
            $('input[type="submit"]').val('Create Post');
        }
    }

    async function register(e) {
        e.preventDefault();
        let credentials = grabCredentials('registerForm');
        if (!credentials) return;
        try {
            let data = await requester.post('user', '', credentials, 'basic');
            saveSession(data);
            clearFields();
            showInfo("User registration successful.");
            userLoggedIn();
        }
        catch (e) {
            console.log(e);
            handleError(e);
        }

        function clearFields() {
            let form = $("#registerForm");
            form.find("input").val('');
            $("#btnRegister").val('Sign Up');
        }
    }

    async function login(e) {
        e.preventDefault();
        let credentials = grabCredentials('loginForm');
        if (!credentials) return;
        try {
            let data = await requester.post('user', 'login', credentials, 'basic');
            saveSession(data);
            clearFields();
            showInfo("Login successful");
            userLoggedIn()
        }
        catch (e) {
            showError("Error: Invalid credentials. Please retry your request with different credentials")
        }

        function clearFields() {
            let form = $("#loginForm");
            form.find("input").val('');
            $("#btnRegister").val('Sign In');
        }


    }

    async function logout() {
        try {
            await requester.post('user', '_logout', {authtoken: localStorage.getItem('authtoken')});
            localStorage.clear();
            userLoggedOut();
            showInfo('Logged out');
        } catch (err) {
            handleError(err);
        }
    }

    async function getAllPosts() {
        let allPosts = await requester.get("appdata", "posts", '');
        let postsInFormat = [];
        let counter = 1;
        for (let post of allPosts) {
            let postInFormat = {
                id: post._id,
                rank: counter,
                url: post.url,
                imgUrl: post.imageUrl,
                title: post.title,
                createdBefore: calcTime(post._kmd.ect),
                author: post.author
            }
            counter++;
            postsInFormat.push(postInFormat);
        }
        let source = {
            posts: postsInFormat
        };

        return source;
    }

    function userLoggedIn() {
        $("#username").html(`Hello, ${localStorage.username}!`);
        loadCatalogView();
    }

    function userLoggedOut() {
        $("#username").text("Hello {username}!");
        loadHomeView();
    }

    function grabCredentials(formId) {
        let form = $(`#${formId}`);
        let username = form.find('input[name="username"]').val();
        let password = form.find('input[name="password"]').val();
        if (formId == 'registerForm') {
            let repeatPassword = form.find('input[name="repeatPass"]').val();
            if (!validateRegister(username, password, repeatPassword)) {
                showError("Error: Invalid credentials. Please retry your request with different credentials");
                return;
            }
        }
        if (!validateLogin(username, password)) {
            showError("Error: Invalid credentials. Please retry your request with different credentials");
            return;
        }
        return {username, password};
    }

    function validateRegister(username, password, repeatPassword) {
        if (!username.match(/^[a-z]{3,}$/i) || !password.match(/^[a-z0-9]{6,}$/i) ||
            password !== repeatPassword) {
            return false;
        }
        return true;
    }

    function validateLogin(username, password) {
        if (!username.match(/^[a-z]{3,}$/i) || !password.match(/^[a-z0-9]{6,}$/i)) {
            return false;
        }
        return true;
    }

    async function loadMenu() {
        let menuTemplate = await getTemplate('menu');
        let compiledTemplate = Handlebars.compile(menuTemplate);
        menuHtml = compiledTemplate({});
        return menuHtml;
    }

    async function renderView(viewHtml) {
        let notificationsTemplate = await getTemplate('notify');
        let compiledTemplate = Handlebars.compile(notificationsTemplate);
        let notificationHtml = compiledTemplate({});

        let menuHtml = '';
        if (currentlyActiveUser()) {
            menuHtml = await loadMenu();
        }
        mainDiv.html(notificationHtml + menuHtml + viewHtml);
        attachNotificationEvents();
        attachMenuEvents();
    }

    function attachMenuEvents() {
        let menu = $("#menu");
        let createLink = menu.find("a[data-target='PostCreate']");
        let catalogLink = $("#linkCatalog");
        $(createLink).click(loadCreateView);
        $(catalogLink).click(loadCatalogView);
    }

    function attachNotificationEvents() {
        $(".notification").hide();
        $('#infoBox').click((event) => $(event.target).hide());
        $('#errorBox').click((event) => $(event.target).hide());
    }

    function showInfo(message) {
        $('#infoBox').text(message);
        $('#infoBox').show();
        setTimeout(() => $('#infoBox').fadeOut(), 3000);
    }

    function showError(message) {
        $('#errorBox').text(message);
        $('#errorBox').show();
    }

    function handleError(reason) {
        showError(reason.responseJSON.description);
    }

    function calcTime(dateIsoFormat) {
        let diff = new Date - (new Date(dateIsoFormat));
        diff = Math.floor(diff / 60000);
        if (diff < 1) return 'less than a minute';
        if (diff < 60) return diff + ' minute' + pluralize(diff);
        diff = Math.floor(diff / 60);
        if (diff < 24) return diff + ' hour' + pluralize(diff);
        diff = Math.floor(diff / 24);
        if (diff < 30) return diff + ' day' + pluralize(diff);
        diff = Math.floor(diff / 30);
        if (diff < 12) return diff + ' month' + pluralize(diff);
        diff = Math.floor(diff / 12);
        return diff + ' year' + pluralize(diff);

        function pluralize(value) {
            if (value !== 1) return 's';
            else return '';
        }
    }

    function currentlyActiveUser() {
        if (localStorage.getItem('authtoken') !== null &&
            localStorage.getItem('username') !== null) {
            return true;
        }
        return false;
    }

    // sometimes a man has to var his way out...
    var postIdForEdit = '';
}