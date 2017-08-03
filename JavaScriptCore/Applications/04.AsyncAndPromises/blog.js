/*jshint esversion: 6 */
$(document).ready(function hehe() {
    let kinveyUrl = "https://baas.kinvey.com/appdata";
    let appId = "kid_H1ibWhxwW";
    let commentsPostfix = "comments";
    let postsPostfix = "posts";
    let base64auth = btoa(`jica:123`);
    let authHeader = {"Authorization": "Basic " + base64auth};

    $("#btnLoadPosts").click(loadPostsEvent);
    $("#btnViewPost").click(viewPostEvent);

    function viewPostEvent() {
        let idOfSelectedPost = $("#posts").val();
        let request = {
            url: `${kinveyUrl}\\${appId}\\${postsPostfix}\\${idOfSelectedPost}`,
            headers: authHeader
        };

        $.ajax(request)
            .then(loadPost)
            .catch(error);
    }

    function loadComments(response) {
        $("#post-comments").empty();
        for(let i = 0; i < response.length; i++){
            let commentText = response[i].text;
            $(`<li>${commentText}</li>`).appendTo($("#post-comments"));
        }
    }

    function requestComments(id) {
        let request = {
            url: `${kinveyUrl}\\${appId}\\${commentsPostfix}?query={"post_id":\"${id}\"}`,
            headers: authHeader
        };
        $.ajax(request)
            .then(loadComments)
            .catch(error);
    }

    function loadPost(response) {
        $("#post-title").empty();
        $("#post-body").empty();

        let postTitle = response.title;
        let postBody = response.body;
        $("#post-title").textContent(postTitle);
        $("#post-body").textContent(postBody);
        requestComments(response._id);
    }

    function loadPostsEvent() {

        let request = {
            url: `${kinveyUrl}\\${appId}\\${postsPostfix}`,
            headers: authHeader
        };
        $.ajax(request)
            .then(displayPosts)
            .catch(error)
    }

    function error() {
        console.log("sori brat");
    }

    function displayPosts(response) {
        $("#posts").empty();
        for (let i = 0; i < response.length; i++) {
            let post = response[i];
            let postId = post._id;
            $(`<option>${post.title}</option>`).val(postId).appendTo($("#posts"));
        }
    }


});