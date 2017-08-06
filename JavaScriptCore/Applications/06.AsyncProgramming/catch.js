/*jshint esversion: 6 */
function attachEvents() {
    let appId = `kid_H1ibWhxwW`;
    let kinveyUrl = `https://baas.kinvey.com/appdata/${appId}/`;
    let base64auth = btoa(`jica:123`);
    let authHeader = {"Authorization": "Basic " + base64auth};

    $(".load").click(loadAllCatches);


    $(".add").click(addCatch);
    function error() {

    }

    function updateCatch() {
        let parentDiv = $(this).parent();
        let updatedCatch = {
            angler: parentDiv.find(".angler").val(),
            weight: Number(parentDiv.find(".weight").val()),
            species: parentDiv.find(".species").val(),
            location: parentDiv.find(".location").val(),
            bait: parentDiv.find(".bait").val(),
            captureTime: Number(parentDiv.find(".captureTime").val())
        };

        let id = parentDiv.attr("data-id");
        let putUrl = kinveyUrl + `biggestCatches/${id}`;

        let putRequest = {
            type: 'PUT',
            headers: authHeader,
            url: putUrl,
            contentType: "application/json",
            data: JSON.stringify(updatedCatch)
        };

        $.ajax(putRequest).then(loadAllCatches);
    }

    function deleteCatch() {
        let parentDiv = $(this).parent();
        let id = parentDiv.attr("data-id");
        let deleteUrl = kinveyUrl + `biggestCatches/${id}`;

        let deleteRequest = {
            type: 'DELETE',
            headers: authHeader,
            url: deleteUrl,
            contentType: "application/json"
        };

        $.ajax(deleteRequest).then(loadAllCatches);
    }

    function addCatch() {
        let newCatch = {
            angler: $("#addForm>.angler").val(),
            weight: Number($("#addForm>.weight").val()),
            species: $("#addForm>.species").val(),
            location: $("#addForm>.location").val(),
            bait: $("#addForm>.bait").val(),
            captureTime: Number($("#addForm>.captureTime").val())
        };
        let addUrl = kinveyUrl + "biggestCatches";
        let addRequest = {
            type: 'POST',
            url: addUrl,
            data: JSON.stringify(newCatch),
            headers: authHeader,
            contentType: "application/json",
        };
        $.ajax(addRequest).then(loadAllCatches());
    }

    function loadAllCatches() {
        let allCatchesUrl = kinveyUrl + "biggestCatches";
        let allCatchesRequest = {
            url: allCatchesUrl,
            headers: authHeader,
        };

        $.get(allCatchesRequest)
            .then(renderAllCatches)
            .catch(error);

    }

    function renderAllCatches(response) {
        $("#catches").empty();
        for (let singleCatch of response) {
            $(`<div class="catch" data-id="${singleCatch._id}">`)
                .append($(`<label>Angler</label>`))
                .append($(`<input type="text" class="angler" value="${singleCatch.angler}">`))
                .append($(`<label>Weight</label>`))
                .append($(`<input type="number" class="weight" value="${singleCatch.weight}">`))
                .append($(`<label>Species</label>`))
                .append($(`<input type="text" class="species" value="${singleCatch.species}">`))
                .append($(`<label>Location</label>`))
                .append($(`<input type="text" class="location" value="${singleCatch.location}">`))
                .append($(`<label>Bait</label>`))
                .append($(`<input type="text" class="bait" value="${singleCatch.bait}">`))
                .append($(`<label>Capture Time</label>`))
                .append($(`<input type="number" class="captureTime" value="${singleCatch.captureTime}">`))
                .append($(`<button class="update">Update</button>`).click(updateCatch))
                .append($(`<button class="delete">Delete</button>`).click(deleteCatch))
                .appendTo($("#catches"));
        }
    }
}