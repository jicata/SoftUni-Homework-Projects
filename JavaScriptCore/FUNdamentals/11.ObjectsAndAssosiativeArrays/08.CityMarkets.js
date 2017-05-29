/*jshint esversion: 6 */
function nestedMaps(input) {
    let outerMap = new Map();
    for(let i = 0; i < input.length; i++){
        let values = input[i].split('->');
        let city = values[0];
        let product = values[1];

        let priceAndAmount = values[2].split(":");
        let totalValue = Number(priceAndAmount[0]) * Number(priceAndAmount[1]);

        let innerMap = new Map();
        if(!outerMap.has(city)){

            innerMap.set(product,totalValue);
            outerMap.set(city,innerMap);
        }
        else{
            outerMap.get(city).set(product,totalValue);
        }
    }
    for(let key of outerMap.keys()){
        console.log(`Town - ${key}`)
        for(let [innerKey,value] of outerMap.get(key).entries()){
            console.log("$$$"+innerKey.trim()+" : " +value);
        }
    }
}
// nestedMaps(["Sofia -> Laptops HP -> 200 : 2000", "Sofia -> Raspberry -> 200000 : 1500", "Sofia -> Audi Q7 -> 200 : 100000",
//     "Montana -> Portokals -> 200000 : 1", "Montana -> Qgodas -> 20000 : 0.2", "Montana -> Chereshas -> 1000 : 0.3"]);