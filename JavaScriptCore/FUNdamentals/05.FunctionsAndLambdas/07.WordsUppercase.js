/*jshint esversion: 6 */
function wordsUppercase(input) {
    let sentence = input[0];
    let rgx = new RegExp("\b(\w+)\b");
    var matched = sentence.match(/\b(\w+)\b/g);
    for(let i = 0; i<matched.length; i++){
        matched[i] = matched[i].toUpperCase();
    }
    console.log(matched.join(", "));
}
wordsUppercase(['Hi, how are you?']);