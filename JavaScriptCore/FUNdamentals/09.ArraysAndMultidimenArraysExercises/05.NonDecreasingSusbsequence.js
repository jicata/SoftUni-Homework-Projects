/*jshint esversion: 6 */
function extractNonDecreasingSubsequence(input) {
    input = input.map(Number);
    let currentMax = input[0];
    input.filter(function(value){
        if(value>=currentMax){
            currentMax = value;
            return true;
        }

    }).forEach(v=>console.log(v));
}
extractNonDecreasingSubsequence([1,3,8,4,10,12,3,2,24]);

