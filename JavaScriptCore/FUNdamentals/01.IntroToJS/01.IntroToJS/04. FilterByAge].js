
function FilterByAge(minumAgeAndPersons){
    var minimumAge = Number(minumAgeAndPersons[0]);
    var persons = [];
    for(i=1; i<minumAgeAndPersons.length;i+=2)
    {
        var person ={
            name:minumAgeAndPersons[i],
            age:Number(minumAgeAndPersons[i+1])
        };
        persons.push(person);
    }
    for(i=0;i<persons.length;i++){
        if(persons[i].age >= minimumAge){
            console.log(persons[i]);
        }
    }
}
FilterByAge(['12', 'Ivan', '15', 'Asen', '9']);