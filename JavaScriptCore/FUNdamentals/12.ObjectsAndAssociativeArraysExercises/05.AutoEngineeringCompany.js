/*jshint esversion: 6 */
function autoComp(data) {
    let carStorage = new Map();
    for(let dataRow of data){
        let dataRowSplit = dataRow.split('|').filter(String);
        let carBrand = dataRowSplit[0];
        let carModel = dataRowSplit[1];
        let producedCars = Number(dataRowSplit[2]);
        let innerMap = new Map();
        if(carStorage.has(carBrand)){
            if(carStorage.get(carBrand).has(carModel)){
                let oldCarsProduced = carStorage.get(carBrand).get(carModel);
                innerMap = carStorage.get(carBrand);
                innerMap.set(carModel, oldCarsProduced + producedCars);
                carStorage.set(carBrand, innerMap);
            }
            else{
                innerMap = carStorage.get(carBrand);
                innerMap.set(carModel, producedCars);
                carStorage.set(carBrand,innerMap);
            }
        }
        else{
            innerMap.set(carModel, producedCars);
            carStorage.set(carBrand, innerMap);
        }
    }
    for(let [carBrand, innerMap] of carStorage.entries()){
        console.log(carBrand.trim());
        for(let [carModel, carsProduced] of innerMap.entries()){
            console.log("###" +carModel.trim() +" -> " + carsProduced)
        }
    }
}