/*jshint esversion: 6 */
function attachEvents() {
    let appId = `kid_BJ_Ke8hZg`;
    let appdataController = "appdata/";
    let rpcController = "rpc/";
    let kinveyUrl = `https://baas.kinvey.com/`;
    let base64auth = btoa(`guest:pass`);
    let authHeader = {"Authorization": "Basic " + base64auth};

    $("#getVenues").click(loadVenues);

    function error() {
        console.log("emi ne");
    }

    function loadVenues() {
        "use strict";
        let venueDate = $("#venueDate").val();
        let venuesIdsUrl = `${kinveyUrl}${rpcController}${appId}/custom/calendar?query=${venueDate}`;
        let venuesIdsRequest = {
            type: 'POST',
            url: venuesIdsUrl,
            headers: authHeader
        };

        $.ajax(venuesIdsRequest)
            .then(handleVenueIds)
            .catch(error);

        function handleVenueIds(response) {
            let venueInfoUrl = `${kinveyUrl}${appdataController}${appId}/venues/`;

            for (let venueId of response) {
                let specificVenueInfoUrl = venueInfoUrl + venueId;
                let venueInfoRequest = {
                    url: specificVenueInfoUrl,
                    headers: authHeader,
                };

                $.ajax(venueInfoRequest)
                    .then(renderVenue)
                    .catch(error);
            }


            function renderVenue(venue) {

                $(`<div class="venue" id="${venue._id}">`)
                    .append($(`<span class="venue-name">`)
                        .append($(`<input class="info" type="button" value="More info">`)
                            .click(showHideDetails))
                        .append(`${venue.name}`))
                    .append($(`<div class="venue-details" style="display: none">`)
                        .append($(`<table>`)
                            .append($(`<tr>`)
                                .append($(`<th>Ticket Price</th>`))
                                .append($(`<th>Quantity</th>`)))
                            .append($(`<tr>`)
                                .append($(`<td class="venue-price">${venue.price}</td>`))
                                .append($(`<td>`)
                                    .append($(`<select class="quantity">`)
                                        .append($(`<option value="1">1</option>`))
                                        .append($(`<option value="2">2</option>`))
                                        .append($(`<option value="3">3</option>`))
                                        .append($(`<option value="4">4</option>`))
                                        .append($(`<option value="5">5</option>`))))
                                .append($(`<td>`)
                                    .append($(`<input class="purchase" type="button" value="Purchase">`)
                                        .click(purchaseItem)))))
                        .append($(`<span class="head">Venue description:</span>`))
                        .append($(`<p class="description">${venue.description}</p>`))
                        .append($(`<p class="description">Starting time: ${venue.startingHour}</p>`)))
                    .appendTo($("#venue-info"));


                function purchaseItem() {
                    $("#venue-info").empty();
                    let parentDiv = $(this).parents("div:first");
                    let venueId = $(this).parents("div:last").attr("id");
                    let venueName = $(parentDiv).prev().text();
                    let qty = Number($(parentDiv).find(".quantity option:selected").val());
                    let price = Number($(parentDiv).find(".venue-price").text());

                    $(`<span class="head">Confirm purchase</span>`)
                        .append($(`<div class="purchase-info">`)
                            .append($(`<span>${venueName}</span>`))
                            .append($(`<span>${qty} x ${price}</span>`))
                            .append($(`<span>Total: ${qty * price} lv</span>`))
                            .append($(`<input type="button" value="Confirm">`)
                                .click(finalizePurchase)))
                        .appendTo($("#venue-info"));

                    function finalizePurchase() {
                        let purchaseUrl = `${kinveyUrl}${rpcController}${appId}/custom/purchase?venue=${venueId}&qty=${qty}`;
                        let purchaseRequest = {
                            type: 'POST',
                            url: purchaseUrl,
                            headers: authHeader
                        }

                        $.ajax(purchaseRequest)
                            .then(displayFinalStatement)
                            .catch(error);

                        function displayFinalStatement(response) {
                            $("#venue-info").empty();
                            $("#venue-info").append("You may print this page as your ticket")
                            $("#venue-info").append(response.html);
                        }

                    }

                }


                function showHideDetails() {
                    let parentDiv = $(this).parent().parent();
                    let parentDivId = $(parentDiv).attr("id");
                    let venueDetailsDiv = $(`#${parentDivId}`).find('.venue-details');
                    let displayValue = $(venueDetailsDiv).prop("style")["display"];
                    if (displayValue == 'none') {
                        $(venueDetailsDiv).css('display', 'block');
                    }
                    else {
                        $(venueDetailsDiv).css('display', 'none');
                    }
                }
            }
        }

    }
}