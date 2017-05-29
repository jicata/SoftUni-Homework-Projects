/*jshint esversion: 6 */
function triangleOfDollars(input) {
    let number = Number(input);
    for(var i=1;i<=number;i++){
       console.log("$".repeat(i));
    }
}
triangleOfDollars(["5"]);