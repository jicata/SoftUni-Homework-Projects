/*jshint esversion: 6 */
function pallindrome([inputStr]) {
    for(let i=0; i<inputStr.length/2;i++){
        if(inputStr[i] != inputStr[inputStr.length-i-1]){
            return false;
        }
    }
    return true;
}
console.log(pallindrome(["abba"]));