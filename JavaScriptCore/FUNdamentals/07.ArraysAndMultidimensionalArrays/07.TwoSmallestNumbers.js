/*jshint esversion: 6 */
function twoSmallestNumbers(input) {
    input = input.map(Number);

    function compareNumbers(a, b) {
        return a - b;
    }

    input.sort(compareNumbers);
    input = input.slice(0,2);
    console.log(input.join(" "));
}
twoSmallestNumbers(['30', '15', '50', '5']);