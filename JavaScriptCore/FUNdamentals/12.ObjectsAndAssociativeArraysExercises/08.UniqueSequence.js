/*jshint esversion: 6 */
function uniqueSequences(numberArrays) {
    "use strict";
    let mapOfSequences = new Map();
    for (let numberArray of numberArrays) {
        let THISISDEFINITELYANARRAYKIROBRAVO = JSON.parse(numberArray);
        let joinedAndSortedArray = THISISDEFINITELYANARRAYKIROBRAVO.sort().map(n => n.toString()).join();
        if (!mapOfSequences.has(joinedAndSortedArray)) {
            mapOfSequences.set(joinedAndSortedArray, THISISDEFINITELYANARRAYKIROBRAVO);
        }
    }
    mapOfSequences = Array.from(mapOfSequences).sort((p1,p2) => mapSort(p1,p2));
    for(let [key,sequence] of mapOfSequences){
        let sortedSequence = sequence.sort((num1,num2)=>arraySort(num1,num2));
        let joinedSequence = sortedSequence.join(", ");
        console.log("["+ joinedSequence + "]");
    }

    function mapSort(pair1, pair2) {
        return pair1[1].length - pair2[1].length;
    }

    function arraySort(num1,num2) {
        return num2-num1;
    }
}
