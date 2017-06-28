/*jshint esversion: 6 */
function calendar(dateInfo) {
    "use strict";
    let day = Number(dateInfo[0]);
    let month = Number(dateInfo[1]);
    let year = Number(dateInfo[2]);

    let monthName = findMonth(month);
    let targetElement = $("#content");

    let table = $(`<table></table>`)
        .append($(`<caption>${monthName} ${year}</caption>`));

    let tableBody = $(`<tbody></tbody>`)
        .append($(`<tr></tr>`)
            .append($(`<th>Mon</th>`))
            .append($(`<th>Tue</th>`))
            .append($(`<th>Wed</th>`))
            .append($(`<th>Thu</th>`))
            .append($(`<th>Fri</th>`))
            .append($(`<th>Sat</th>`))
            .append($(`<th>Sun</th>`)));

    let totalDaysInMonth = daysInMonth(month, year);
    let firstDayOfMonthOfWeek = getDayOfWeek(month, year) == 0 ? 7 : getDayOfWeek(month, year);
    let firstRow = true;
    let lastRow = false;
    let dayNumber = 1;
    let addedRows = firstDayOfMonthOfWeek == 7 && totalDaysInMonth == 28 ? 0 : 1;
    let totalRows = Math.floor((totalDaysInMonth / 7)+ addedRows) ;
    let rows  = 1;
    while (!lastRow && dayNumber - 1 != totalDaysInMonth) {
        let tableRow = $(`<tr></tr>`);

        for (let dayOfWeek = 0; dayOfWeek <= 6; dayOfWeek++) {
            let tableData = $(`<td></td>`);
            if (dayOfWeek +1 == firstDayOfMonthOfWeek) {
                firstRow = false;
            }
            if (dayNumber - 1 == totalDaysInMonth) {
                lastRow = true;
            }
            if (!firstRow && !lastRow) {
                tableData.text(dayNumber);
                if(dayNumber == day){
                    tableData.addClass('today');
                }
                dayNumber++;
            }
            tableData.appendTo(tableRow);

        }
        rows++;
        tableRow.appendTo(tableBody);
    }

    tableBody.appendTo(table);
    table.appendTo(targetElement);


    function getDayOfWeek(month, year) {
        return new Date(year, month - 1, 1).getDay();
    }

    function daysInMonth(month, year) {
        return new Date(year, month, 0).getDate();
    }

    function findMonth(month) {
        switch (month) {
            case 1:
                return `January`;
                break;
            case 2:
                return `February`;
                break;
            case 3:
                return `March`;
                break;
            case 4:
                return `April`;
                break;
            case 5:
                return `May`;
                break;
            case 6:
                return `June`;
                break;
            case 7:
                return `July`;
                break;
            case 8:
                return `August`;
                break;
            case 9:
                return `September`;
                break;
            case 10:
                return `October`;
                break;
            case 11:
                return `November`;
                break;
            case 12:
                return `December`;
                break;
        }
    }
}
