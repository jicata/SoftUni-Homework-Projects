let kinveyUrl = "https://baas.kinvey.com/appdata/kid_H1ibWhxwW/players";
let appId = "kid_H1ibWhxwW";
let base64auth = btoa(`jica:123`);
let authHeader = {"Authorization": "Basic " + base64auth};
let currentPlayerId = 0;
let player = undefined;
function attachEvents() {
    loadAllPlayers();
    $(".play").click(play);

}

function loadAllPlayers() {
    let allPlayersRequest ={
        url:kinveyUrl,
        headers:authHeader
    };

    $.ajax(allPlayersRequest)
        .then(renderAllPlayers)
        .catch(error)

    function renderAllPlayers(response) {
        for(let player of response){
            let playerId = player._id;
            let playerName = player.name;
            let playerMoney = player.money;
            let playerBullets = player.bullets;

            $(`<div class="player" data-id="${playerId}">`)
                .append($(`<div class="row">`)
                    .append($(`<label>Name:</label>`))
                    .append($(`<label class="name">${playerName}</label>`)))
                .append($(`<div class="row">`)
                    .append($(`<label>Money:</label>`))
                    .append($(`<label class="money">${playerMoney}</label>`)))
                .append($(`<div class="row">`)
                    .append($(`<label>Bullets:</label>`))
                    .append($(`<label class="bullets">${playerBullets}</label>`)))
                .append($(`<button class="play">Play</button>`).click(play))
                .append($(`<button class="delete">Delete</button>`).click(deletePlayer))
                .appendTo($("#players"));
        }
    }
}

function play() {
    $("#save").show();
    $("#reload").show();
    $("#canvas").show();

    let playerId = $(this).parent().attr("data-id");
    currentPlayerId = playerId;
    let url = kinveyUrl + `/${playerId}`;
    let playerRequest = {
        url : url,
        headers: authHeader
    };

    $.ajax(playerRequest)
        .then(startGame)
        .catch(error);

    function startGame(response) {
        player = response;
       loadCanvas(response);
    }
}

function save(){
    "use strict";

}
function deletePlayer() {

}
function error() {

}
