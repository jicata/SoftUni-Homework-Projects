let kinveyUrl = "https://baas.kinvey.com/appdata/kid_H1ibWhxwW/players";
let appId = "kid_H1ibWhxwW";
let base64auth = btoa(`jica:123`);
let authHeader = {"Authorization": "Basic " + base64auth};

function attachEvents() {
    loadAllPlayers();

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
        // <div class="player" data-id="<id-goes-here>">
        //    <div class="row">
        //         <label>Name:</label>
        //     <label class="name">Pesho</label>
        //         </div>
        //         <div class="row">
        //         <label>Money:</label>
        //     <label class="money">500</label>
        //         </div>
        //         <div class="row">
        //         <label>Bullets:</label>
        //     <label class="bullets">6</label>
        //      </div>
        //         <button class="play">Play</button>
        //         <button class="delete">Delete</button>
        //  </div>

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

}
function deletePlayer() {

}
function error() {

}
