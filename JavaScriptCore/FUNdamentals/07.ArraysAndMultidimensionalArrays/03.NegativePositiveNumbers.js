/*jshint esversion: 6 */
function negativePositive(input) {
    input = input.map(Number);
    let resultArray =[];
    for(let i=0; i<input.length; i++){
        if(input[i] < 0){
            resultArray.unshift(input[i]);
        }
        else{
            resultArray.push(input[i]);
        }
    }
    console.log(resultArray.join("\n"));
}
negativePositive(['7', '-2', '8', '9']);