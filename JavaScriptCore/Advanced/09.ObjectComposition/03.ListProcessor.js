/*jshint esversion: 6 */
function listProcessor(arrCommands) {
    let text = [];
    let processor = function processor(command) {
        let commandTokens = command.split(' ');
        switch (commandTokens[0]) {
            case 'add':
                text.push(commandTokens[1]);
                break;
            case 'remove':
                text = text.filter((e) => e !== commandTokens[1]);
                break;
            case 'print':
                console.log(text.join(","));
                break;

        }
    };
    for(let command of arrCommands){
        processor(command);
    }
}