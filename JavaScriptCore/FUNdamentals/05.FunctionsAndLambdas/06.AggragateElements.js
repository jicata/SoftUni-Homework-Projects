/*jshint esversion: 6 */
function aggregateElements(input) {
    let elements = input.map(Number);
    let aggragate = function (elements,index, func) {
        let val = index;
        for (let i = 0; i < elements.length; i++) {
            val = func(val, elements[i]);
        }
        console.log(val);
    }

    aggragate(elements,0, (a,b)=>a+b);
    aggragate(elements,0,(a,b)=>a + 1/b);
    aggragate(elements,'', (a,b)=>a+b);

}
aggregateElements([10,20,30]);