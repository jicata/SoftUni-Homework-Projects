/*jshint esversion: 6 */
function squareOfStars(input=5) {
    let num= Number(input);
    for(let row=1; row<= num;row++){
        console.log("* ".repeat(num));
    }
}
squareOfStars([1]);