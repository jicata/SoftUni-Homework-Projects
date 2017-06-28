/*jshint esversion: 6 */
function aggregates(data) {
    
    function reduce(data, func){
        let result = data[0];
        for(let nextElement of data.slice(1)){
            result = func(result,nextElement);
        }
        return result;
    }

    console.log(`Sum = ` + reduce(data, (a, b) => a + b));
    console.log(`Min = ` + reduce(data, (a, b) => a < b ? a : b));
    console.log(`Max = ` + reduce(data, (a, b) => a > b ? a : b));
    console.log(`Product = ` + reduce(data, (a, b) => a * b));
    console.log(`Join = ` + reduce(data, (a, b) => a.toString() + b.toString()));

}
aggregates([1,2,3]);