/*jshint esversion: 6 */
function matchAndMultiply(input) {
    let stringToSplit = input[0];
    function replacer(match, p1,p2,p3,offset,string) {
        let result = Number(p2) * Number(p3);
        return result;
    }
    stringToSplit = stringToSplit.replace(/((-?\d+)(?:\s*?)\*(?:\s*?)(-?\d+.?\d+))+/g, replacer);
    console.log(stringToSplit);
}
matchAndMultiply(["My bill is: 4 * 2.50 (beer); 12* 1.50 (kepab); 1  *4.50 (salad); 2  * -0.5 (deposit)."]);