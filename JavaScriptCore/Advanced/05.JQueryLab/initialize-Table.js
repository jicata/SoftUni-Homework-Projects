/*jshint esversion: 6 */
function initializeTable() {

    let table = $("#countriesTable");
    seed();
    function createNewRow() {
        let capital = $("#newCapitalText").val();
        let country = $("#newCountryText").val();
        addCountryToTable(country,capital);
        clearLastLinkFromLastItem();
    }

    $('createLink').click(createNewRow);

    function moveUp() {

        let row = $(this).parent().parent();
        row.fadeOut(function () {
            row.insertBefore(row.prev());
            row.fadeIn();
        })
        clearLastLinkFromLastItem();
    }

    function moveDown() {
        clearLastLinkFromLastItem();
    }

    function deleteItem() {
        clearLastLinkFromLastItem();
    }

    function addCountryToTable(country, capital) {
        let tr = $("<tr>");
        let countryTd = $("<td>");
        let capitalTd = $("<td>");
        let actionsTd = $("<td>");

        let upA = $("<a href='#'>[Up]</a>").click(moveUp);
        let downA = $("<a href='#'>[Down]</a>").click(moveDown);
        let deleteA = $("<a href='#'>[Delete]</a>").click(deleteItem);

        actionsTd.append(upA);
        actionsTd.append(downA);
        actionsTd.append(deleteA);

        countryTd.text(country);
        capitalTd.text(capital);

        tr.append(countryTd);
        tr.append(capitalTd);
        tr.append(actionsTd);

        table.append(tr);
    }
    function clearLastLinkFromLastItem(){
        "use strict";
        let lastAnchor = table.find("tr").last().find("a").last().prev();
        if(lastAnchor!=undefined && lastAnchor.text() == '[Down]'){
            $(lastAnchor).remove();
        }


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
        clearLastLinkFromLastItem();
    }
    }



