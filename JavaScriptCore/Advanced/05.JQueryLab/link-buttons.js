/*jshint esversion: 6 */
function attachEvents() {
    let allA = $('a');
    $('a').each(function () {
        //lol implicit argument passing?
        // arguments[0] = index param
        // arguments[1] = element param
        $(arguments[1]).click(makeItGoBoom)
    });
    function makeItGoBoom() {
        $('a').each(function () {
            $(arguments[1]).removeClass("selected");
        });
        $(this).addClass("selected");
    }
}