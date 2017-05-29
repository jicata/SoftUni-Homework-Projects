/*jshint esversion: 6 */
function dnaHelix(input) {
    let helixLength = Number(input);
    let helixPairs = ["AT","CG", "TT", "AG", "GG"];
    let helixSequence =["**#1##2#**", "*#1#--#2#*", "#1#----#2#","*#1#--#2#*"];
    let pairCounter =0;
    let sequenceCounter = 0;
    for(let i = 0; i<helixLength;i++){
        let first = helixPairs[pairCounter][0];
        let second = helixPairs[pairCounter][1];
        let chain = helixSequence[sequenceCounter].replace("#1#",first).replace("#2#", second);
        console.log(chain);
        pairCounter++;
        sequenceCounter++;
        if(pairCounter >= helixPairs.length){
            pairCounter = 0;
        }
        if(sequenceCounter >= helixSequence.length){
            sequenceCounter = 0;
        }
    }
}
dnaHelix([10]);