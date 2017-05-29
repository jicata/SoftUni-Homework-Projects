/*jshint esversion: 6 */
function equalNeighbours(input) {
    let matrix = input.map(r=>r.split(" "));
    let visited = new Set();
    let totalPairCount = 0;
    for(let row = 0; row < matrix.length;row++){
        for(let col = 0; col<matrix[row].length; col++){
            let currentNum = matrix[row][col];
            if(row > 0 && matrix[row-1][col] == currentNum && !visited.has(`${row-1},${col}`)){
                totalPairCount++;
                visited.add(`${row},${col}`);
               // visited.add(`${row-1},${col}`);
            }
            if(row < matrix.length -1 && matrix[row+1][col] == currentNum && !visited.has(`${row+1},${col}`)){
                totalPairCount++;
                visited.add(`${row},${col}`);
                //visited.add(`${row+1},${col}`);
            }
            if(col < matrix[row].length-1 && matrix[row][col+1] == currentNum && !visited.has(`${row},${col+1}`)){
                totalPairCount++;
                visited.add(`${row},${col}`);
                //visited.add(`${row},${col+1}`);
            }
            if(col > 0 && matrix[row][col-1] == currentNum && !visited.has(`${row},${col-1}`)){
                totalPairCount++;
                visited.add(`${row},${col}`);
                //visited.add(`${row},${col-1}`);
            }
        }
    }
    console.log(totalPairCount);
}
