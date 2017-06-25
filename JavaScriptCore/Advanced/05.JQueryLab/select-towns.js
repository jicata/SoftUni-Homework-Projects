/*jshint esversion: 6 */
function attachEvents() {
    $("ul li").each(function (index,element) {
        $(element).click(selectEvent)
    });

    let resultDiv = $("#selectedTowns");
    $("#showTownsButton").click(showSelected);

    function selectEvent() {
        let selectedAttribute = $(this).attr('data-selected');

        if(typeof selectedAttribute !== typeof undefined && selectedAttribute !==false){
            $(this).removeAttr('data-selected style');
        }
        else{
            $(this).attr('data-selected',true).css('background-color','#DDD');

        }
    }


    function showSelected() {
        let selectedTowns = $('li[data-selected]').toArray().map(a=>a.textContent).join(", ");
        $(resultDiv).text(`Selected towns: ${selectedTowns}`);

    }


}