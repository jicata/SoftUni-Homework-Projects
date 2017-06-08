/*jshint esversion: 6 */
function radicalMarketing(incomingData) {
    let persons = new Map();
    let log = new Map();
    for (let data of incomingData) {
        let detailedData = data.split("-");
        let firstPerson = detailedData[0];
        if (detailedData.length > 1) {
            let secondPerson = detailedData[1];
            if (persons.has(firstPerson) && persons.has(secondPerson) && firstPerson !== secondPerson) {
                let secondPersonSubscribers = persons.get(secondPerson);
                if(secondPersonSubscribers.indexOf(firstPerson)==-1){
                    secondPersonSubscribers.push(firstPerson);
                    persons.set(secondPerson, secondPersonSubscribers);
                    let amountOfSubscriptions = log.get(firstPerson);
                    log.set(firstPerson, ++amountOfSubscriptions);
                }

            }
        }
        else {
            if (!persons.has(firstPerson)) {
                persons.set(firstPerson, []);
                log.set(firstPerson, 0)
            }
        }
    }
    let sortedPersons = Array.from(persons).sort((a, b) => wallStreetSort(a, b));
    //console.log(sortedPersons);

    let sortedPersonsKeys = Array.from(sortedPersons.keys());
    for (let i = 0; i < sortedPersonsKeys.length - 1; i++) {
        let sortedPersonKeyOne = sortedPersons[i][0];
        let sortedPersonKeyTwo = sortedPersons[i+1][0];

        let sortedPersonValueOne = sortedPersons[i][1];
        let sortedPersonValueTwo = sortedPersons[i+1][1];

        let firstPersonSubscribersLength = sortedPersonValueOne.length;
        let secondPersonSubscribersLength = sortedPersonValueTwo.length;

        if (firstPersonSubscribersLength == secondPersonSubscribersLength) {
            let firstPersonTimesSubscribed = log.get(sortedPersonKeyOne);
            let secondPersonTimesSubscribed = log.get(sortedPersonKeyTwo)
                if (firstPersonTimesSubscribed > secondPersonTimesSubscribed) {
                    return printResult(sortedPersonKeyOne, sortedPersonValueOne);
                }
                else if (firstPersonTimesSubscribed < secondPersonTimesSubscribed) {
                    return printResult(sortedPersonKeyTwo, sortedPersonValueTwo);
                }
                if(i+2 < sortedPersonsKeys.length){
                    let nextPersonKey = sortedPersons[i+2][0];
                    let nextPersonValue = sortedPersons[i+2][1];

                    let nextPersonTimesSubscribed = log[nextPersonKey];
                    if(nextPersonValue.length == secondPersonSubscribersLength
                        && nextPersonTimesSubscribed >= secondPersonTimesSubscribed){
                        continue;
                    }
                }
                return printResult(sortedPersonKeyOne, sortedPersonValueOne);

        }
        else {
            if (firstPersonSubscribersLength > secondPersonSubscribersLength) {
                return printResult(sortedPersonKeyOne, sortedPersonValueOne);
            }
            else if (firstPersonSubscribersLength < secondPersonSubscribersLength){
                return printResult(sortedPersonKeyTwo, sortedPersonValueTwo);
            }

        }

    }

    function printResult(person,subscribers){
        console.log(person);
        for(let i = 0; i < subscribers.length; i++){
            console.log(`${i+1}. ${subscribers[i]}`);
        }
    }

    function wallStreetSort(a, b) {
        "use strict";
        if (a[1].length > b[1].length) {
            return -1;
        }
        if (a[1].length < b[1].length) {
            return 1;
        }
        return 0;
    }
}
// radicalMarketing([
//     'Z',
//     'O',
//     'R',
//     'D',
//     'Z-O',
//     'R-O',
//     'D-O',
//     'P',
//     'O-P',
//     'O-Z',
//     'R-Z',
//     'D-Z']);