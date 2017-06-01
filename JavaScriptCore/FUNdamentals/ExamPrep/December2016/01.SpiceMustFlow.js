/*jshint esversion: 6 */
function spiceMustFlow(startingYield) {
    "use strict";
    const workerConsumptionPerDay = 26;
    const yieldDecreasePerDay = 10;
    const minimumYieldPerDay = 100;

    let totalYield = 0;
    let totalDays = 0;

    let remainingSpice = Number(startingYield[0]);

    while (remainingSpice >= minimumYieldPerDay) {
        totalYield += remainingSpice;
        totalDays++;
        remainingSpice -= yieldDecreasePerDay;
        totalYield -= workerConsumptionPerDay;
    }
    if(totalYield!=0){
        totalYield -= workerConsumptionPerDay;
    }

    console.log(totalDays);
    console.log(totalYield);
}
// spiceMustFlow(["200"]);