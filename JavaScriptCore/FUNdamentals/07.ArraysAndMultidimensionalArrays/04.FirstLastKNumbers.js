/*jshint esversion: 6 */
function firstLast(input) {
    k = Number(input[0]);
    let frontArray = [];
    let backArray = [];
    for(let i = 0; i< k;i++){
        frontArray[i] = input[i+1];
        backArray[i] =input[input.length-i-1];
    }
    console.log(frontArray.join(" "));
    console.log(backArray.reverse().join(" "));
}
firstLast(['3',
    '6', '7', '8', '9']);
