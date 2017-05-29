/*jshint esversion: 6 */
function printWithDelim(input) {
    let delimiter = input[input.length-1];
    input.pop();
    console.log(input.join(delimiter));
}
printWithDelim(["How about no?", "I", "will", "not","do","it!","_"]);