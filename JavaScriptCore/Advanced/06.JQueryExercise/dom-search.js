/*jshint esversion: 6 */
function domSearch(elementId, caseSensitive) {

    $(`<div class="add-controls"></div>`)
        .append($('<label>Enter text: </label>')
            .append($('<input>')))
        .append($('<a class="button">Add</a>').click(addElement))
        .appendTo($(elementId));

    $(`<div class="search-controls"></div>`)
        .append($('<label>Search: </label>')
            .append($('<input>').change(searchForElement)))
        .appendTo($(elementId));

    $(`<div class="result-controls"></div>`)
        .append($('<ul class="items-list"></ul>'))
        .appendTo($(elementId));


    function searchForElement() {
        let searchTerm = $(`.search-controls input`).val();
        let itemNames = $(`.list-item`);
        if (searchTerm == "") {
            itemNames.each(function (index, element) {
                $(element).css("display", "block")
            });
        }
        else {
            if (!caseSensitive) {
                searchTerm = searchTerm.toLowerCase();
            }
            itemNames.each(function (index, element) {
                "use strict";
                let liText = $(`strong`, element).text();
                if (!caseSensitive) {
                    liText = liText.toLowerCase();
                }
                if (!liText.includes(searchTerm)) {
                    $(element).css('display', 'none');
                }
                else {
                    $(element).css('display', 'block');
                }
            })
        }
    }


    function addElement() {
        let itemName = $(this).parent().find('input').val();
        let listElement = $('<li class="list-item"></li>')
            .append($('<a class="button">X</a>').click(deleteItem))
            .append($(`<strong>${itemName}</strong>`));

        listElement.appendTo($(`.items-list`));

        $(this).parent().find('input').val("");
    }

    function deleteItem() {
        $(this).parent().remove();
    }

}