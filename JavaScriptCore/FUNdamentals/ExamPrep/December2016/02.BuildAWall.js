/*jshint esversion: 6 */
function buildThatWall(input){
    "use strict";
    const costPerFoot = 195;
    const maxHeight = 30;
    const currency = "pesos";

    let dailyCost = 0;
    let costPerDay = [];
    let complete = false;


    let wallSections = input.map(Number);
    while(!complete){
       for(let section = 0; section < wallSections.length; section++){
           if(wallSections[section] < maxHeight){
               dailyCost+=costPerFoot;
               wallSections[section]++;
           }
       }
       if(dailyCost!==0){
           costPerDay.push(dailyCost);
           dailyCost = 0;
       }
       else{
           complete = true;
       }
    }

    let totalAmountOfConcrete = costPerDay.reduce((a, b) => a + b, 0);
    console.log(costPerDay.join(", "));
    console.log(`${(totalAmountOfConcrete * 1900)} ${currency}`);
}
//buildThatWall([21, 25, 28]);