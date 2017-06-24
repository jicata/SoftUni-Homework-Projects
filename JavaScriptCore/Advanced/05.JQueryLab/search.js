/*jshint esversion: 6 */
function search() {
    let searchTerm = $("#searchText").val();
    let listItems = $("#towns").children();
    let matches = 0;

    for(let li of listItems){
        if(li.textContent.indexOf(searchTerm) !=-1){
            $(li).css('font-weight','bold');
            matches++;
        }
    }
    $("#result").text(`${matches} matches found.`);


}