/*jshint esversion: 6 */
function storeCatalogue(data) {
    let storeMap = new Map();
    for(let item of data){
        let firstLetter = item[0].toLowerCase();
        let itemsAtLetter = [];
        if(storeMap.has(firstLetter)){
            itemsAtLetter = storeMap.get(firstLetter);
            itemsAtLetter.push(item);
            storeMap.set(firstLetter,itemsAtLetter);
        }
        else{
            itemsAtLetter.push(item);
            storeMap.set(firstLetter,itemsAtLetter);
        }
    }
    let sortedMap= new Map([...storeMap.entries()].sort());
    for(let mapKey of sortedMap.keys()){
        let sortedValues = sortedMap.get(mapKey).sort();
        console.log(mapKey.toUpperCase());
        for(let mapValue of sortedValues){
            let mapValueEdited = mapValue.substr(1,mapValue.indexOf(":")-2)
                                + mapValue.substr(mapValue.indexOf(":"));
            console.log(`   ${mapValue[0].toUpperCase()+mapValueEdited}`)
        }
    }
}





storeCatalogue(['Appricot : 20.4',
'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10',
]);