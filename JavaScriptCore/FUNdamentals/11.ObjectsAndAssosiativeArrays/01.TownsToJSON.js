/*jshint esversion: 6 */
function townsToJson(data){
    "use strict";
    data.shift();
    let arrangedInformation = [];
    for(let i = 0; i < data.length; i++){
        let townInfo = data[i].split('|').filter(String);
        let townName = townInfo[0].trim();
        let townLatitude = Number(townInfo[1].trim());
        let townLongitude = Number(townInfo[2].trim());

        let townObject ={
            "Town" : townName,
            "Latitude":townLatitude,
            "Longitude":townLongitude
        };
        arrangedInformation[i] = townObject;

    }
    console.log(JSON.stringify(arrangedInformation));
}
townsToJson(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']);