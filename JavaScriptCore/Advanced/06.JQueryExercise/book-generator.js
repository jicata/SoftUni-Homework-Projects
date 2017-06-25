/*jshint esversion: 6 */
let createBook = (function createBook() {
    let bookId = 1;
    return function (elementId, name, author, isbn) {
        "use strict";
        let targetElement = $(elementId);

        function select() {
            let divNode = $(this).parent();
            divNode.css('border', '2px solid blue');
        }

        function deselect() {
            let divNode = $(this).parent();
            divNode.css('border', 'none');
        }

        $(`<div id="book${bookId}"></div>`)
            .append($(`<p class="title">${name}</p>`))
            .append($(`<p class="author">${author}</p>`))
            .append($(`<p class="isbn">${isbn}</p>`))
            .append($(`<button>Select</button>`).click(select))
            .append($(`<button>Deselect</button>`).click(deselect)).appendTo(targetElement);

        bookId++;

    }
}());