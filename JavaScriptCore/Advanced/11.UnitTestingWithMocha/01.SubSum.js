/*jshint esversion: 6 */
function sumStuff(collection,startIndex,endIndex) {
    if(!Array.isArray(collection)){
        return NaN;
    }
    if(startIndex < 0){
        startIndex = 0;
    }
    if(endIndex >= collection.length){
        endIndex = collection.length-1;
    }
    let result = 0;
    for(let i = startIndex; i <= endIndex; i++){
        result += Number(collection[i]);
    }
    return result;
}
