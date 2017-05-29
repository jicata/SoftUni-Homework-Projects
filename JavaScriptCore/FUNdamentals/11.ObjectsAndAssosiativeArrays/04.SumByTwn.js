/*jshint esversion: 6 */
function sumByTown(input){
    "use strict";
    let sumByTowns = {};
    for(let i=0;i < input.length;i+=2){
        let key = input[i];
        let value = Number(input[i+1]);
        if(sumByTowns[key]==undefined){
            sumByTowns[key]=value;
        }
        else{
            sumByTowns[key]+= value;
        }

    }
    var result = JSON.stringify(sumByTowns);
    console.log(result);
}
sumByTown(['Sofia',20,'Varna',3,'Sofia',5,'Varna',4]);