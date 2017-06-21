/*jshint esversion: 6 */
function reverseNotation(data) {
    "use strict";
    let storageArray = [];
    for (let i = 0; i < data.length; i++) {
        let element = data[i];

        if (typeof element !== 'number') {
            if (storageArray.length < 2) {
                console.log("Error: not enough operands!");
               return;
            }
            let secondNumber = storageArray.pop();
            let firstNumber = storageArray.pop();
            let result = 0;
            if (element == "-") {
                result = firstNumber - secondNumber;
            }
            else if (element == "+") {
                result = firstNumber + secondNumber;
            }
            else if (element == "/") {
                result = firstNumber / secondNumber;
            }
            else {
                result = firstNumber * secondNumber;
            }
            storageArray.push(result);
        }
        else{
            storageArray.push(element);
        }
    }
    if(storageArray.length>1){
        console.log("Error: too many operands!")
    }
    else{
        console.log(storageArray.pop());
    }
}
//reverseNotation([15,'/']);