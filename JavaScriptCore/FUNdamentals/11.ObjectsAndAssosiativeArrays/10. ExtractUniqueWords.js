/*jshint esversion: 6 */
function extractUniqueWords(input) {
    let uniqueWords = [];
    for(let i = 0; i< input.length; i++){
        let sentence = input[i].split(" ").filter(String).map(el=>el.replace('.','').replace(',',''));
        for(let word of sentence){
            if(uniqueWords.indexOf(word.toLowerCase())==-1){
                uniqueWords.push(word.toLowerCase());
            }
        }
    }
        console.log(uniqueWords.join(', '))
}
extractUniqueWords(["Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque quis hendrerit dui."]);