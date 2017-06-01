/*jshint esversion: 6 */
function username(data) {
    "use strict";
    let usernames = new Set();
    for(let username of data){
        usernames.add(username);
    }

    usernames = Array.from(usernames).sort((us1,us2) => sortFunction(us1,us2));
    for(let sortedName of usernames){
        console.log(sortedName);
    }

    function sortFunction(us1,us2){
        let lenghtComparison = us1.length - us2.length;
        if(lenghtComparison !==0){
            return lenghtComparison;
        }
        if(us1 > us2){
            return 1;
        }
        if(us1<us2){
            return -1;
        }
        return 0;
    }
}
username(['Ashton',
    'Kutcher',
    'Ariel',
    'Lilly',
    'Keyden',
    'Aizen',
    'Billy',
    'Braston']);