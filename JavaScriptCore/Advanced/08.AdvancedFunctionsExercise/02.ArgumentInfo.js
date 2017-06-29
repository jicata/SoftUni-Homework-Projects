/*jshint esversion: 6 */
function argumentInfo(){
    "use strict";
    let map = new Map();
    for(let i = 0; i < arguments.length; i++){
        let obj = arguments[i];
        let type = typeof obj;
        console.log(`${type}: ${obj}`);
        if(map.has(type)){
            let oldVal = map.get(type)+1;
            map.set(type,oldVal);
        }
        else{
            map.set(type,1);
        }
    }
    let sortedMap = Array.from(map).sort((a,b) => b[1] - a[1]);
    sortedMap.forEach((a)=>console.log(`${a[0]} = ${a[1]}`));
}
//argumentInfo('cat', 42, function () { console.log('Hello world!'); });