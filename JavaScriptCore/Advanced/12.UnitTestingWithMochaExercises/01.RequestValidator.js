/*jshint esversion: 6 */
function validateRequest(request) {
    const errorMessage = `Invalid request header: `;
    if (request.method == undefined) {
        throw Error(`${errorMessage}Invalid Method`);
    }
    else {
        let methodPattern = /^(GET|POST|DELETE|CONNECT)$/g;
        let methodMatch = methodPattern.exec(request.method);
        if (!methodMatch) {
            throw Error(`${errorMessage}Invalid Method`);
        }
    }
    if (request.uri == undefined || request.uri.length == 0) {
        throw Error(`${errorMessage}Invalid URI`);
    }
    else {
        let uriPattern = /^([*a-zA-Z0-9.]+)$/g;
        let uriMatch = uriPattern.exec(request.uri);
        if (!uriMatch) {
            throw Error(`${errorMessage}Invalid URI`);
        }
    }
    if (request.version == undefined) {
        throw Error(`${errorMessage}Invalid Version`);
    }
    else {
        let versionPattern = /^(HTTP\/0\.9|HTTP\/1\.0|HTTP\/1\.1|HTTP\/2\.0)$/g;
        let versionMatch = versionPattern.exec(request.version);
        if (!versionMatch) {
            throw Error(`${errorMessage}Invalid Version`);
        }
    }
    if (request.message == undefined) {
        throw Error(`${errorMessage}Invalid Message`);
    }
    else {
        let messagePattern = /^([^<>\\&'"]*)$/g;
        let messageMatch = messagePattern.exec(request.message);
        if (!messageMatch && request.message.length > 0) {
            throw Error(`${errorMessage}Invalid Message`);
        }
    }
    return request;
}
// let kur =validateRe)quest({
//     method: 'POST',
//     uri: 'home.bash',
//     message: 'rm -rf /*'
// });
//
// console.log(kur);