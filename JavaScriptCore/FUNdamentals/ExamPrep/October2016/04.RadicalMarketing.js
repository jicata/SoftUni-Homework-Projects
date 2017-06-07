/*jshint esversion: 6 */
function radicalMarketing(incomingData) {
    let persons = new Map();
    for(let data of incomingData){
        let detailedData = data.split("-");
        let entryPerson = detailedData[0];
        if(detailedData.length > 1){
            let subscribedTo = detailedData[1];
            if(persons.has(entryPerson) && persons.has(subscribedTo) && entryPerson!==subscribedTo){
                let personInfo = persons.get(subscribedTo);
                personInfo.subscribers.push(entryPerson);
                persons.set(subscribedTo,personInfo);
                let subscriberInfo = persons.get(entryPerson);
                subscriberInfo.count++;
                persons.set(entryPerson,subscriberInfo);

            }
        }
        else{
            if(!persons.has(entryPerson)){
                persons.set(entryPerson, {subscribers:[], count:0});
            }
        }
    }


    let sortedPersons = Array.from(persons).sort((a,b) => wallStreetSort(a,b));
    console.log(sortedPersons);
   let sortedPerson = sortedPersons[0];
   console.log(sortedPerson[0]);
   for(let i = 0 ; i < sortedPerson.subscribers.length; i ++){
       console.log(`${i}. ${sortedPerson.subscribers[i]}`);
   }

    function wallStreetSort(a,b){
        "use strict";
        if(a[1].subscribers.length > b[1].subscribers.length){
            return -1;
        }
        if(a[1].subscribers.length < b[1].subscribers.length){
            return 1;
        }
        if(a[1].count > b[1].count){
            return 1;
        }
        if(a[1].count < b[1].count){
            return -1;
        }
        return 0;
    }
}
radicalMarketing([
    'A',
'B',
'C',
'D',
'A-B',
'B-A',
'C-A',
'D-A',]);