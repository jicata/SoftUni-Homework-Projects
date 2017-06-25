/*jshint esversion: 6 */
function initializeTable() {

    let table = $("#countriesTable");
    seed();
    function createNewRow() {
        let capital = $("#newCapitalText").val();
        let country = $("#newCountryText").val();
        addCountryToTable(country,capital);
        normalizeLinks();
    }

    $('#createLink').click(createNewRow);

    function moveUp() {
        let row = $(this).parent().parent();
        row.fadeOut(function () {
            row.insertBefore(row.prev());
            row.fadeIn();
            normalizeLinks();
        });

    }

    function moveDown() {
        let row = $(this).parent().parent();
        row.fadeOut(function () {
            row.insertAfter(row.next());
            row.fadeIn();
            normalizeLinks();
        });
    }

    function deleteItem() {
        let row = $(this).parent().parent();
        row.fadeOut(function () {
            row.remove();
            normalizeLinks();
        })

    }

    function addCountryToTable(country, capital) {
        $(`<tr>`)
            .append($(`<td>${country}</td>`))
            .append($(`<td>${capital}</td>`))
            .append($(`<td>`)
                .append($(`<a href="#">[Up]</a>`).click(moveUp))
                .append($(`<a href="#">[Down]</a>`).click(moveDown))
                .append($(`<a href="#">[Delete]</a>`).click(deleteItem)))
            .appendTo($(table));
    }
    function normalizeLinks(){
        "use strict";
        $('tr a').show();
        $('tr:last-child a:contains(Down)').hide();
        $('tr:eq(2) a:contains(Up)').hide();

    }
    function seed() {
        let preset = ['Bulgaria, Sofia',
            'Germany, Berlin',
            'Russia, Moscow'];

        for(let countryCapital of preset){
            let countryCapitalDetails = countryCapital.split(', ');
            let country = countryCapitalDetails[0];
            let capital = countryCapitalDetails[1];

            addCountryToTable(country, capital);

        }
        normalizeLinks();
    }
    }



