/*jshint esversion: 6 */
function extractText() {
    let items = $('li').toArray().map(li=>li.textContent).join(", ");
    $('#result').text(items);

}