/*jshint esversion: 6 */
function lastKNumbers(input) {
    let totalLength = Number(input[0]);
    let stepBack = Number(input[1]);
    let resultingArray = [1];
    for(let i = 1;i< totalLength;i++){
        let nextNumber = 0;
        let startingIndex = i - stepBack;

        if(startingIndex < 0)
            startingIndex = 0;
        for(let j = startingIndex; j< i ; j++){
            nextNumber+=resultingArray[j];
        }
        resultingArray[i] = nextNumber;

    }
    console.log(resultingArray.join(" "));
}
lastKNumbers(['8','2']);