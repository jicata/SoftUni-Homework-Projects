$("#BirthDate").on('change', function () {

    // parse the date as it comes in DD/MM/YYYY format
    // since in order for JS to consider it a proper date
    // it needs to be in the MM/DD/YYYY format
    let pattern = /(\d+)[\/-](\d+)[\/-](\d+)/;
    let matched = pattern.exec($('#BirthDate').val());
    let dateString = `${matched[2]}/${matched[1]}/${matched[3]}`;

    // compare the "birthDate" with the current date
    // in order to fulfil our business logic
    let d2 = new Date(dateString);
    let d1 = new Date();
    let timeDiff = Math.abs(d1.getTime() - d2.getTime());
    let diffDays = Math.floor(Math.ceil(timeDiff / (1000 * 3600 * 24)) / 365);


    // set the checkbox to checked/unchecked
    // depending on our business logic
    if (diffDays > 18) {
        $('#IsYoungDriver').prop('checked', false);
    } else {
        $('#IsYoungDriver').prop('checked', true);
    }
});