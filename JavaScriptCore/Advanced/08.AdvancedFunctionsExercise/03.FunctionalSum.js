/*jshint esversion: 6 */
function sum() {
    let sum = 0;
    return function NonAnon(number) {
        "use strict";
        sum += number;
        NonAnon.toString = () => sum;
        return NonAnon;
    };
}