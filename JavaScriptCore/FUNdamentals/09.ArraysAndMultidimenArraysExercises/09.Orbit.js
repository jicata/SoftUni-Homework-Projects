/*jshint esversion: 6 */
function orbit(input) {
    let dimensions = input[0].split(" ").map(Number);
    let startPos = input[1].split(" ").map(Number);

    let rows = dimensions[0];
    let cols = dimensions[1];
    let startRow = startPos[0];
    let startCol = startPos[1];

    let matrix = [];
    for(let i = 0; i < rows;i++){
        matrix.push([]);
    }

    let currentNum = 1;
    matrix[startRow][startCol] = currentNum;
    currentNum++;

    let visited = new Set();
    let current = [];
    let temp = [];
    visited.add(`${startRow} ${startCol}`);
    current.push(`${startRow} ${startCol}`);

    while(current.length > 0){
        for(let i = 0; i < current.length; i++){
            let currentPositions = current[i].split(" ").map(Number);
            let currentRow = currentPositions[0];
            let currentCol = currentPositions[1];
            if(currentRow -1 >=0 && currentCol-1 >= 0 && !visited.has(`${currentRow-1} ${currentCol-1}`)){
                matrix[currentRow-1][currentCol-1] = currentNum;
                visited.add(`${currentRow-1} ${currentCol-1}`);
                temp.push(`${currentRow-1} ${currentCol-1}`);
            }
            if(currentRow-1 >= 0 && !visited.has(`${currentRow-1} ${currentCol}`)){
                matrix[currentRow-1][currentCol] = currentNum;
                visited.add(`${currentRow-1} ${currentCol}`);
                temp.push(`${currentRow-1} ${currentCol}`);
            }
            if(currentRow -1 >= 0 && currentCol+1 < cols && !visited.has(`${currentRow-1} ${currentCol+1}`)){
                matrix[currentRow-1][currentCol+1] = currentNum;
                visited.add(`${currentRow-1} ${currentCol+1}`);
                temp.push(`${currentRow-1} ${currentCol+1}`);
            }
            if(currentCol-1 >= 0 && !visited.has(`${currentRow} ${currentCol-1}`)){
                matrix[currentRow][currentCol-1] = currentNum;
                visited.add(`${currentRow} ${currentCol-1}`);
                temp.push(`${currentRow} ${currentCol-1}`);
            }
            if(currentCol+1 <cols && !visited.has(`${currentRow} ${currentCol+1}`)){
                matrix[currentRow][currentCol+1] = currentNum;
                visited.add(`${currentRow} ${currentCol+1}`);
                temp.push(`${currentRow} ${currentCol+1}`);
            }
            if(currentRow +1 < rows && currentCol-1 >= 0 && !visited.has(`${currentRow+1} ${currentCol-1}`)){
                matrix[currentRow+1][currentCol-1] = currentNum;
                visited.add(`${currentRow+1} ${currentCol-1}`);
                temp.push(`${currentRow+1} ${currentCol-1}`);
            }
            if(currentRow +1 < rows  && !visited.has(`${currentRow+1} ${currentCol}`)){
                matrix[currentRow+1][currentCol] = currentNum;
                visited.add(`${currentRow+1} ${currentCol}`);
                temp.push(`${currentRow+1} ${currentCol}`);
            }
            if(currentRow +1 < rows && currentCol+1 < cols && !visited.has(`${currentRow+1} ${currentCol+1}`)){
                matrix[currentRow+1][currentCol+1] = currentNum;
                visited.add(`${currentRow+1} ${currentCol+1}`);
                temp.push(`${currentRow+1} ${currentCol+1}`);
            }
        }
        currentNum++;
        current = temp;
        temp = [];
    }
    for(let row = 0; row < rows; row++){
        console.log(matrix[row].join(" "));
    }
}
orbit(["5 5","2 2"]);