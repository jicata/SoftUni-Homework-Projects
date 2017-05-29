/*jshint esversion: 6 */
function maxElementInMatrix(input) {
    let matrix = input.map(row=>row.split(' ').map(Number));
    let maxNum = Number.NEGATIVE_INFINITY;
    matrix.forEach(
        r=> r.forEach(
            c=>maxNum = Math.max(c, maxNum)));
    console.log(maxNum);
}
maxElementInMatrix(['3 5 7 12',
    '-1 4 33 2',
    '8 3 0 4']);
