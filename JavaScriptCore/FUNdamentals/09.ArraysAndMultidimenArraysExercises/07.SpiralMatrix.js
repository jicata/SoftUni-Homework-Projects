/*jshint esversion: 6 */
function spiralMatrix(input) {
    let dimensions = input[0].split(" ").map(Number);
    let rows = dimensions[0];
    let cols = dimensions[1];
    let direction = "right";
    let startRow = 0;
    let startCol = 0;
    let offset = 0;

    let matrix = [];
    for(let row = 0;row<rows;row++){
        matrix.push([]);
    }
    let counter = 1;
    while(counter<=rows*cols){
        if(direction == "right"){
            for(let col = startCol; col < cols-offset; col++){
                matrix[startRow][col] = counter;
                counter++;
            }
            direction ="down";
            startRow++;
            startCol = cols - (1+offset);
        }
        if(direction == "down"){
            for(let row = startRow;row < rows - offset;row++){
                matrix[row][startCol] = counter;
                counter++;
            }
            direction = "left";
            startCol--;
            startRow = rows - (1+offset);
        }
        if(direction == "left"){
            for(let col = startCol; col >= (0+offset); col-- ){
                matrix[startRow][col] = counter;
                counter++;
            }
            direction = "up";
            startRow--;
            startCol = 0+offset;

        }
        if(direction =="up"){
            offset++;
            for(let row = startRow; row >=(0+offset);row-- ){
                matrix[row][startCol] = counter;
                counter++;
            }
            startRow = 0+offset;
            startCol = 0+offset;
            direction = "right";
        }
    }
    for(let row = 0; row<rows;row++){
        console.log(matrix[row].join(" "));
    }
}
spiralMatrix(["5 5"]);