/*jshint esversion: 6 */
function attachEvents() {
    $("#btnLoadTowns")
        .click(print);

    function print() {
        let source = $("#towns-template").html();
        let template = Handlebars.compile(source);
        let input = $("#towns").val().split(", ");
        let towns = {
            towns:[]
        };
        for(let i = 0; i < input.length; i++){
            towns.towns.push({town:input[i]});
        }

        console.log(towns);
        let html = template(towns);

        $("#root").html(html);
    }
}