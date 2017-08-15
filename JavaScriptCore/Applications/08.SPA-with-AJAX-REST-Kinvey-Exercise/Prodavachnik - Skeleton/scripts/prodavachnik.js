function startApp() {
    "use strict";


    $("#menu").find("a").rshow();

    function navigateTo(e) {
        $('section').hide();
        let target = $(e.target).attr("data-target");
        $("#" + target).show();
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