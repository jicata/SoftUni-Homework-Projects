/*jshint esversion: 6 */
function diagonalSums(input) {
    let matrix = input.map(r=>r.split(" ").map(Number));
    let mainDiagonal = 0;
    let mainCount = 0;
    let secondaryDiagonal =0;
    let secondaryCount = 1;
    for(let row = 0; row< matrix.length; row++){
        // for(let col = 0; col < matrix[row].length; col++){
        //     printRow+=matrix[row][col]+" ";
        // }
        mainDiagonal += matrix[row][mainCount];
        secondaryDiagonal += matrix[row][matrix[row].length - secondaryCount];
        mainCount++;
        secondaryCount++;
    }
    console.log(mainDiagonal + " " + secondaryDiagonal);
}
diagonalSums(['3 5 17',
    '-1 7 14',
    '1 -8 89']
);