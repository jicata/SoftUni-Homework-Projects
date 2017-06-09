/*jshint esversion: 6 */
function ajaxValidator(requests) {
    "use strict";
    let methodPattern = /Method: (GET|POST|DELETE|PUT)/;
    let credentialsPattern = /Credentials: (Basic|Bearer)\s([a-zA-Z0-9]+)$/;
    let contentPattern = /Content:\s([a-zA-Z0-9.]+)$/;
    let hashDecodePattern = /(?:([0-9]+)([a-zA-Z]+))/g;

    requests.pop();

    let hashCode = requests.pop();
    let validHashes = [];
    let hashMatch = hashDecodePattern.exec(hashCode);
    while (hashMatch != null) {
        let letter = hashMatch[2];
        let amountOfTimes = hashMatch[1];
        let asd = [letter,amountOfTimes];
        validHashes.push(asd);
        hashMatch = hashDecodePattern.exec(hashCode);
    }
//console.log(validHashes);
    for (let i = 0; i < requests.length; i += 3) {
        let requestMethod = requests[i];
        let requestCredentials = requests[i + 1];
        let requestContent = requests[i + 2];

        let methodMatch = methodPattern.exec(requestMethod);
        let credentialsMatch = credentialsPattern.exec(requestCredentials);
        let contentMatch = contentPattern.exec(requestContent);
        if (methodMatch == null || credentialsMatch == null || contentMatch == null) {
            console.log("Response-Code:400");
            continue;
        }

        let credentials = credentialsMatch[2];
        let method = methodMatch[1];
        let authorizationType = credentialsMatch[1];

        let validCredentials = false;
        for (let [letter, occurrences] of validHashes) {
            if (credentials.split(letter).length - 1 == occurrences) {
                validCredentials = true;
                break;
            }
        }


        if (authorizationType == 'Basic' && method != 'GET') {
            console.log(`Response-Method:${method}&Code:401`);
            continue;
        }
        if (!validCredentials) {
            console.log(`Response-Method:${method}&Code:403`)
            continue;
        }
        console.log(`Response-Method:${method}&Code:200&Header:${credentials}`)
    }


}
ajaxValidator(["Method: GET",
    "Credentials: Bearer asd918721jsdbhjslkfqwkqiuwjoxXJIdahefJAB",
    "Content: users.asd.1782452.278asd",
    "Method: POST",
    "Credentials: Basic 028591u3jtndkgwndsdkfjwelfqkjwporjqebhas",
    "Content: Johnathan",
    "2q"]);

// ajaxValidator(["Method: PUT",
//     "Credentials: Bearer as9133jsdbhjslkfqwkqiuwjoxXJIdahefJAB",
//     "Content: users.asd/1782452$278///**asd123",
//     "Method: POST",
//     "Credentials: Bearer 028591u3jtndkgwndskfjwelfqkjwporjqebhas",
//     "Content: Johnathan",
//     "Method: DELETE",
//     "Credentials: Bearer 05366u3jtndkgwndssfsfgeryerrrrrryjihvx",
//     "Content: This.is.a.sample.content",
//     "2e5g"])