/*jshint esversion: 6 */
function decodeTheStone(data) {
    "use strict";
    let alphabet = [" ", "A", "B", "C", "D", "E", "F", "G", "H",
        "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];

    let decodingMatrixLength = Number(data[0]);
    let decodingMatrix = [];
    let encodedMatrix = [];
    for (let i = 1; i <= decodingMatrixLength; i++) {
        decodingMatrix.push(data[i].split(" ").map(Number));
    }
    for (let i = decodingMatrixLength + 1; i < data.length; i++) {
        encodedMatrix.push(data[i].split(" ").map(Number));
    }
    let decodingRow = 0;
    let decodingCol = 0;
    let finalMessage = "";
    for (let row = 0; row < encodedMatrix.length; row++) {
        for (let col = 0; col < encodedMatrix[row].length; col++) {
            let decodedLetter = alphabet[(decodingMatrix[decodingRow][decodingCol] + encodedMatrix[row][col]) % 27];
            decodingCol++;
            if (decodingCol >= decodingMatrix[decodingRow].length) {
                decodingCol = 0;
            }
            finalMessage+=decodedLetter;
        }
        decodingRow++;
        decodingCol = 0;
        if (decodingRow >= decodingMatrixLength) {
            decodingRow = 0;
        }
    }
    console.log(finalMessage.trim());
}
