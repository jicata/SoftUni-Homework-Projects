/*jshint esversion: 6 */
function playingCards(cards) {
    function doEt(cardInfo) {
        let cardPattern = /^([2-9]|[JQKA]|10)([SHDC])$/g;

        let cardMatch = cardPattern.exec(cardInfo);
        if (!cardMatch) {
            throw new Error(`Invalid card: ${cardInfo}`);
        }
        let face = cardMatch[1];
        let suit = cardMatch[2];
        let card = {
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
                        hexOfSuit = '\u2663';
                        break;
                }
                return `${this.face}${hexOfSuit}`;
            }
        };
        return card;
    }

    let storedCards = [];
    for (let i = 0; i < cards.length; i++) {
        try {
            let resultingCard = doEt(cards[i]);
            storedCards.push(resultingCard);
        }
        catch (e) {
            console.log(`Invalid card: ${cards[i]}`);
            return;
        }
    }
    let result = "";
    storedCards.forEach((element) => {
        result += `${element.toString()} `
    });
    console.log(result.trim());
}
//console.log(playingCards(['5S', '3D', 'QD', '1C']));