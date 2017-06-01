/*jshint esversion: 6 */
function airport(data) {
    let planes = [];
    let townPlane = new Map();

    for (let airplaneInfo of data) {
        let airplaneDetails = airplaneInfo.split(' ');

        let planeId = airplaneDetails[0];
        let town = airplaneDetails[1];
        let passengers = Number(airplaneDetails[2]);
        let action = airplaneDetails[3];

        let indexOfPlane = planes.indexOf(planeId);
        if (indexOfPlane == -1 && action == 'land') {
            planes.push(planeId);
        }
        else {
            if (action == "depart") {
                planes.splice(indexOfPlane, 1);
            }
        }

        if (!townPlane.has(town) && action == "land") {
            let plane = {
                id: planeId,
                passengers: passengers,
                action: action
            };
            townPlane.set(town, new Set());


        }
    }
}
airport([
    "Boeing474 Madrid 300 land",
    "AirForceOne WashingtonDC 178 land",
    "Airbus London 265 depart",
    "ATR72 WashingtonDC 272 land",
    "ATR72 Madrid 135 depart"
])