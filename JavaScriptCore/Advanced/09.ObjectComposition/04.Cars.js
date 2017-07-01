/*jshint esversion: 6 */
//good luck understanding the code below in the future, future me :)
function creator(commands) {
    "use strict";
    let objects = new Map();
    let processor = function objectProcessor(command) {
        let commandTokens = command.split(' ');
        let name = commandTokens[1];
        if (commandTokens[0] == 'create') {
            if (commandTokens.length == 2) {
                let createdObject = {};
                objects.set(name, createdObject);
            }
            else {
                let discoveredObject = objects.get(commandTokens[3]);
                let newObject = Object.create(discoveredObject);
                objects.set(name, newObject);
            }
        }
        else if (commandTokens[0] == 'set') {
            let existingObject = objects.get(name);
            existingObject[commandTokens[2]] = commandTokens[3];
            objects.set(name, existingObject);
        }
        else {
            let objectToPrint = objects.get(name);
            let objectProperties = [];
            for(let property in objectToPrint){
                    objectProperties.push(`${property}:${objectToPrint[property]}`);

            }
            console.log(objectProperties.join(", "));

        }
    };
    for(let command of commands){
        processor(command);
    }
}
// let kur = creator(['create c1',
//     'create c2 inherit c1',
//     'set c1 color red',
//     'set c2 model new',
//     'print c1',
//     'print c2']
// );