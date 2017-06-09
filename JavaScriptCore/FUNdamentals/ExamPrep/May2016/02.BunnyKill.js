/*jshint esversion: 6 */
function BUNNIES(data) {
    "use strict";
    let matrix = [];
    let dmgCounter = 0;
    let bunnyCounter = 0;
    let bombBunniesCoordinates = data.pop().split(" ");

    for (let row of data) {
        let matrixRow = row.split(" ").map(Number);
        matrix.push(matrixRow);
    }
    while (bombBunniesCoordinates.length > 0) {
        let coordinates = bombBunniesCoordinates.pop().split(",");
        let row = Number(coordinates[0]);
        let col = Number(coordinates[1]);
        if (matrix[row][col] != 0) {
            dmgCounter += matrix[row][col];
            bunnyCounter++;
            explode(row, col, matrix);
        }
    }
    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (matrix[row][col] != 0) {
                dmgCounter += matrix[row][col];
                bunnyCounter++;
            }
        }
    }
    console.log(dmgCounter);
    console.log(bunnyCounter);
    function explode(row, col, matrix) {
        let damage = matrix[row][col];
        if (row - 1 >= 0 && col - 1 >= 0) {
            matrix[row - 1][col - 1] = Math.max(0, matrix[row - 1][col - 1] - damage);
        }
        if (row - 1 >= 0) {
            matrix[row - 1][col] = Math.max(0, matrix[row - 1][col] - damage);
        }
        if (row - 1 >= 0 && col + 1 < matrix[row - 1].length) {
            matrix[row - 1][col + 1] = Math.max(0, matrix[row - 1][col + 1] - damage);
        }
        if (col - 1 >= 0) {
            matrix[row][col - 1] = Math.max(0, matrix[row][col - 1] - damage);
        }
        if (col + 1 < matrix[row].length) {
            matrix[row][col + 1] = Math.max(0, matrix[row][col + 1] - damage);
        }
        if (row + 1 < matrix.length && col - 1 >= 0) {
            matrix[row + 1][col - 1] = Math.max(0, matrix[row + 1][col - 1] - damage);
        }
        if (row + 1 < matrix.length) {
            matrix[row + 1][col] = Math.max(0, matrix[row + 1][col] - damage);
        }
        if (row + 1 < matrix.length && col + 1 < matrix[row + 1].length) {
            matrix[row + 1][col + 1] = Math.max(0, matrix[row + 1][col + 1] - damage);
        }
        matrix[row][col] = 0;
    }

}
BUNNIES(['5 10 15 20',
    '10 10 10 10',
    '10 15 10 10',
    '10 10 10 10',
    '2,2 0,1',]);

BUNNIES(['10 10 10',
    '10 10 10',
    '10 10 10',
    '0,0',])