/*jshint esversion: 6 */
function extensibleObject() {
    let myObj = {
        __proto__: {},
        extend: function (anotherObject) {
            "use strict";
            let objectProps = Object.keys(anotherObject);
            for(let key of objectProps){
                let typeOfProperty = typeof anotherObject[key];
                if(typeOfProperty =='function'){
                    this.__proto__[key] = anotherObject[key];
                }
                else{
                    this[key] = anotherObject[key];
                }
            }
        }
    };
    return myObj;
}
let kur = extensibleObject();
kur.extend({
    color: 'red',
    kur: function () {
    }
});
console.log(kur.__proto__);
