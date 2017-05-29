/*jshint esversion: 6 */
function rotateArray(input) {
    let rotate = input.pop();
    for(let i=0; i<rotate%input.length;i++){
        let popped = input.pop();
        input.unshift(popped);
    }
    console.log(input.join(" "));
}
rotateArray([1,2,3,4,2]);s