/*jshint esversion: 6 */
function playingCards(face, suit) {
    let facePattern = /^([2-9]|[JQKA]|10)$/g;
    let suitPattern = /^([SHDC])$/g;

    let suitMatch = suitPattern.exec(suit);
    let faceMatch = facePattern.exec(face);

    if (!suitMatch || !faceMatch) {
        throw new Error("Error");
    }
    return {
        face: face,
        suit: suit,
        toString: function () {
            let hexOfSuit = "";
            switch (this.suit) {
                case "S":
                    hexOfSuit = '\u2660';
                    break;
                case "H":
                    hexOfSuit = '\u2665';
                    break;
                case "D" :
                    hexOfSuit = '\u2666';
                    break;
                case "C" :
                    hexOfSuit = '\2663';
                    break;
            }
            return `${this.face}${hexOfSuit}`;
        }
    }
}
//console.log('' + playingCards('1', 'C'));