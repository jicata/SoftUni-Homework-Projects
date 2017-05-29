/*jshint esversion: 6 */
function countWordsInText(input) {
    let words = input[0].split(/[^\w\d_]/).filter(String);
    let wordsByCount = {};
    for(let word of words){
        if(wordsByCount[word] == undefined){
            wordsByCount[word] = 1;
        }
        else{
            wordsByCount[word] ++;
        }
    }
    console.log(JSON.stringify(wordsByCount))
}
countWordsInText("JS devs use Node.js for server-side JS.-- JS for devs");