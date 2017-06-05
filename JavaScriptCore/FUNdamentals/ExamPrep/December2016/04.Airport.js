/*jshint esversion: 6 */
function airport(data) {
    let planes = new Map();
    let townsPlanes = new Map();
    let arrivalsByTown = new Map();

    for (let airplaneInfo of data) {
        let airplaneDetails = airplaneInfo.split(' ');

        let planeId = airplaneDetails[0];
        let town = airplaneDetails[1];
        let passengers = Number(airplaneDetails[2]);
        let action = airplaneDetails[3];

        let planeInfo = {
            passengers: passengers,
            action: action
        };

        if (validatePlane(planeId, planes, action)) {
            planes.set(planeId,action);
            let planesInTown = new Map();
            if (!townsPlanes.has(town)) {
                planesInTown.set(planeId, planeInfo);
                townsPlanes.set(town, planesInTown);
            }
            else {
                planesInTown = townsPlanes.get(town);
                planesInTown.set(planeId, planeInfo);
                townsPlanes.set(town, planesInTown);
            }
            let arrivals = {arrivals:0, departures:0};
            if(arrivalsByTown.has(town)){
                arrivals = arrivalsByTown.get(town);
            }

            if(action == 'land'){
                arrivals.arrivals+=passengers;
            }
            else{
                arrivals.departures+=passengers;
            }
            arrivalsByTown.set(town, arrivals);
        }
    }
    console.log("Planes left:");
    let sortedPlanes = Array.from(planes).sort((a,b) =>alphabeticalSort(a[0],b[0]));
    for(let [plane,action] of sortedPlanes){
        if(action!='depart'){
            console.log(`- ${plane}`)
        }
    }
    let sortedArrivals = Array.from(arrivalsByTown).sort(sortTowns);
    for(let [town,arrivals] of sortedArrivals){
        console.log(town);
        console.log(`Arrivals: ${arrivals.arrivals}`);
        console.log(`Departures: ${arrivals.departures}`);
        console.log("Planes:")
        let sortedPlanesInTown = Array.from(townsPlanes.get(town)).sort((a,b) => alphabeticalSort(a[0],b[0]));
        for(let [plane,planeinfo] of sortedPlanesInTown){
            console.log(`-- ${plane}`);
        }
    }

    function validatePlane(planeId, planes, newAction) {
        "use strict";
        if (!planes.has(planeId) && newAction == 'land') {
            planes.set(planeId, newAction);
            return true;
        }
        let oldAction = planes.get(planeId);
        if (oldAction == 'depart') {
            return newAction == 'land';
        }
        if (oldAction == 'land') {
            return newAction != 'land';
        }
    }
    function alphabeticalSort(a, b){
        let lowerA = a.toLowerCase();
        let lowerB= b.toLowerCase();
        if (lowerA < lowerB) //sort string ascending
            return -1;
        if (lowerA > lowerB)
            return 1;
        return 0; //default return value (no sorting)
    }
    function sortTowns(a,b){
        if(a[1].arrivals < b[1].arrivals){
            return 1;
        }
        if(a[1].arrivals > b[1].arrivals){
            return -1;
        }
        else{
            return alphabeticalSort(a[0],b[0]);
        }
    }

}
// airport([
//     "Airbus Paris 356 land",
//     "Airbus London 321 land",
//     "Airbus Paris 213 depart",
//     "Airbus Ljubljana 250 land"
// ])