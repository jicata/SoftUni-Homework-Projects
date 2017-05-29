/*jshint esversion: 6 */
function quadraticEquation([a,b,c]) {
    var d = (Math.pow(b, 2) - (4 * a * c));
    var x1 = (-b + Math.sqrt(d)) / (2 * a);
    var x2 = (-b - Math.sqrt(d)) / (2 * a);

    if (d > 0) {
        x1 = (-b - Math.sqrt(d)) / (2 * a);
        x2 = (-b + Math.sqrt(d)) / (2 * a);
        console.log("x1 = " + x1 + "\nx2 = " + x2);
    }
    if (d === 0) {
        x1 = (-b) / (2 * a);
        console.log("X = " + x1);
    }
    if (d < 0) {
        console.log("No real roots");
    }
}