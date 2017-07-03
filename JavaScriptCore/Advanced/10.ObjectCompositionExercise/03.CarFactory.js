/*jshint esversion: 6 */
function carFactory(carRequirements) {
    "use strict";
    let engines = new Map([
        ['Small engine', {power: 90, volume: 1800}],
        ['Normal engine', {power: 120, volume: 2400}],
        ['Monster engine', {power: 200, volume: 3500}]
    ]);

    let carriages = new Map([
        ['hatchback', {type: 'hatchback'}],
        ['coupe', {type: 'coupe'}]
    ]);

    let requiredPower = carRequirements.power;
    let engine = {};
    if (requiredPower <= 90) {
        engine = engines.get('Small engine');
    }
    else if (requiredPower > 90 && requiredPower <= 120) {
        engine = engines.get('Normal engine');
    }
    else {
        engine = engines.get('Monster engine');
    }
    let carriage = carriages.get(carRequirements.carriage);
    carriage.color = carRequirements.color;
    let wheels = wheelRounder(carRequirements.wheelsize);
    let resultCar = {
        model: carRequirements.model,
        engine: engine,
        carriage: carriage,
        wheels: Array(4).fill(wheels)
    };
    return resultCar;

    function wheelRounder(wheelDiameter) {
        let resultingWheel = wheelDiameter;
        while (resultingWheel % 2 == 0) {
            resultingWheel--;
        }
        return resultingWheel;
    }
}
// let kur = carFactory({
//         model: 'VW Golf II',
//         power: 90,
//         color: 'blue',
//         carriage: 'hatchback',
//         wheelsize: 14
//     }
// );
//console.log(kur);