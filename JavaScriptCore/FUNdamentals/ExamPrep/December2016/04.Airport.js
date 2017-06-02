/*jshint esversion: 6 */
function airport(data) {
    let planes = new Map();
    let townsPlanes = new Map();

    for (let airplaneInfo of data) {
        let airplaneDetails = airplaneInfo.split(' ');

        let planeId = airplaneDetails[0].trim();
        let town = airplaneDetails[1].trim();
        let passengers = Number(airplaneDetails[2]);
        let action = airplaneDetails[3].trim();

        let planeInfo = {
            passengers: passengers,
            action: action
        };

        if (validatePlane(planeId, planes, action)) {
            planes.set(planeId,action);
            if (!townsPlanes.has(town)) {
                let planesInTown = new Map();
                planesInTown.set(planeId, planeInfo);
                townsPlanes.set(town, planesInTown);
            }
            else {
                planesInTown = townsPlanes.get(town);
                let existingPlane = planesInTown.get(planeId)

                if(typeof existingPlane !== 'undefined'){
                    
                }
                planesInTown.set(planeId, planeInfo);
                townsPlanes.set(town, planesInTown);
            }
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
    console.log("Planes left:");
    for(let [plane,action] of planes){
        if(action!='depart'){
            console.log(`- ${plane}`)
        }
    }
    for(let [town,planes] of townsPlanes){
        console.log(town);
    }
    //console.log(planes);
    console.log(townsPlanes);
}
airport([
    "Boeing474 Madrid 300 land",
    "AirForceOne WashingtonDC 178 land",
    "Airbus London 265 depart",
    "ATR72 WashingtonDC 272 land",
    "ATR72 Madrid 135 depart"
])