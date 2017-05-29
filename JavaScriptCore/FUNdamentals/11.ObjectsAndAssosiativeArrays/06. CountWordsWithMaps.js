/*jshint esversion: 6 */
function countWordsWithMaps(input) {
    let sentence = input[0]
        .split(/[^\w\d_]/)
        .filter(element =>element!=='')
        .map(word=>word.toLowerCase());
    let storageMap = new Map();
    for(let word of sentence){
        if(!storageMap.has(word)){
            storageMap.set(word,1);
        }
        else{
            let oldValue = storageMap.get(word);
            storageMap.set(word,++oldValue);
        }
    }


    var mapAsc = new Map([...storageMap.entries()].sort());

    for(let [key,value] of mapAsc.entries()){
        console.log(`'${key}' -> ${value} times`);
    }
}
//countWordsWithMaps(["Far too slow, you're far too slow."]);