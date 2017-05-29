/*jshint esversion: 6 */
function triangleOfStars(input) {
     let num = Number(input[0]);
     for(let i=1; i <=num;i++){
         console.log("*".repeat(i));
    }
    for(let i=num-1; i>0;i--){
        console.log("*".repeat(i));
    }
}
triangleOfStars([5]);