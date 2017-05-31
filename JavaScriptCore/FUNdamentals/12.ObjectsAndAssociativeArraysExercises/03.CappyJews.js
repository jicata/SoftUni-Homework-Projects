/*jshint esversion: 6 */
function cappyJuice(juices) {
    let juiceMap = new Map();
    let juiceOrder = [];
    for(let itemAndQuantity of juices){
        let juiceData = itemAndQuantity.split("=>").filter(String);

        let juiceType = juiceData[0];
        let juiceQuantity = Number(juiceData[1]);
        if(juiceMap.has(juiceType)){
            let oldQuantity = juiceMap.get(juiceType);
            let newQuantity = oldQuantity+juiceQuantity;
            juiceMap.set(juiceType, newQuantity);
        }
        else{
            juiceMap.set(juiceType, juiceQuantity);
        }
        if(juiceOrder.indexOf(juiceType) == -1 && juiceMap.get(juiceType) >= 1000){
            juiceOrder.push(juiceType);
        }
    }
    for(let juiceKey of juiceOrder){
        console.log(`${juiceKey}=> ${Math.floor(juiceMap.get(juiceKey) / 1000)}`)
    }
}
cappyJuice(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']);