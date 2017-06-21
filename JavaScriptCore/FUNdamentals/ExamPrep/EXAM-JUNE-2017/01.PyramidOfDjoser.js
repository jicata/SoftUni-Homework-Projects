/*jshint esversion: 6 */
function pyramid(a,b) {
    "use strict";
    let stone = 0;
    let lapis = 0;
    let marble = 0;
    let gold = 0;


    let totalHeight = 0;
    let increment = Number(b);
    let base = Number(a);
    let steps = 1;
    // console.log(increment);
    // console.log(base);

    for (let i = base; i > 0; i -= 2) {
        let totalStepPerimeter = i * i;
        let stoneChunk = 0;
        if (i == 1 || i == 2) {
            gold +=totalStepPerimeter * increment;
            totalHeight+=increment;
            break;

        }
        else if (steps % 5 == 0) {
            stoneChunk = (i-2) * (i-2);
            let lapisChunk = totalStepPerimeter - stoneChunk;
            stone+=stoneChunk * increment;
            lapis+=lapisChunk * increment;
        }
        else{
            stoneChunk = (i-2)*(i-2);
            let marbleChunk = totalStepPerimeter - stoneChunk;
            stone += stoneChunk * increment;
            marble += marbleChunk * increment;
        }
       totalHeight+=increment;
        steps++;
    }
    console.log(`Stone required: ${Math.ceil(stone)}`);
    console.log(`Marble required: ${Math.ceil(marble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapis)}`);
    console.log(`Gold required: ${Math.ceil(gold)}`);
    console.log(`Final pyramid height: ${Math.floor(totalHeight)}`);
}
pyramid(23,0.5);