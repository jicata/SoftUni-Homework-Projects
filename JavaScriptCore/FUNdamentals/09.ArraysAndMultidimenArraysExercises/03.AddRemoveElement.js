/*jshint esversion: 6 */
function addRemove(input) {
    let array = [];
    let nextNumber = 1;
    for(let i=0; i<input.length; i++){
        if(input[i] == "add"){
            array.push(nextNumber);
        }
        else{
            array.pop();
        }
        nextNumber++;
    }
    if(array.length == 0){
        console.log("Empty");
        return;
    }
    console.log(array.join("\n"));
}
//addRemove(["add","add","remove","add","add"]);
addRemove(["remove","remove","remove"]);