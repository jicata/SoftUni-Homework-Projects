/*jshint esversion: 6 */
function format(func) {
    let separator = ",";
    let symbol = "$";
    let symbolFirst = true;
    return function (currency){
        "use strict";
        return func(separator,symbol,symbolFirst, currency);
    }
}


// function currencyFormatter(separator, symbol, symbolFirst, value) {
//     let result = Math.trunc(value) + separator;
//     result += value.toFixed(2).substr(-2, 2);
//     if (symbolFirst) return symbol + ' ' + result;
//     else return result + ' ' + symbol;
// }