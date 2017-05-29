/*jshint esversion: 6 */
function diagonalAttack(input) {
    let matrix = input.map(r=>r.split(" ").map(Number));

    let set = new Set();
    let mainDiagonal = 0;
    let mainCount = 0;
    let secondaryDiagonal =0;
    let secondaryCount = 1;
    for(let row = 0; row< matrix.length; row++){
        mainDiagonal += matrix[row][mainCount];
        secondaryDiagonal += matrix[row][matrix[row].length - secondaryCount];
        set.add(`${row}${mainCount}`);
        set.add(`${row}${matrix[row].length - secondaryCount}`);
        mainCount++;
        secondaryCount++;
    }
    let equality = mainDiagonal == secondaryDiagonal

    for(let row = 0;row<matrix.length;row++){
        for(let col = 0; col<matrix[row].length;col++){
            if(!set.has(`${row}${col}`) && equality){
                matrix[row][col] = mainDiagonal;
            }
        }
        console.log(matrix[row].join(" "))
    }
}
diagonalAttack(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
);