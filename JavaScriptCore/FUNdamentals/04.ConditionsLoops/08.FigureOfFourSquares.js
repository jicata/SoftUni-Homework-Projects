/*jshint esversion: 6 */
function figureOfFourSquares([num]) {
    let number = Number(num);
    let colLength = (2*number)-1;
    if(number%2==0){
        for(var row =0;row<number-1; row++){
            let printRow="";

            for(var col=0;col<colLength; col++){
                if(row == 0 || row == Math.ceil(number/2)-1 || row == number-2)
                {
                    if(col==0 || col==Math.floor(colLength/2) || col==colLength-1){
                        printRow+="+";
                    }
                    else{
                        printRow+='-';
                    }

                }
                else{
                    if(col==0 || col==Math.floor(colLength/2) || col==colLength-1){
                        printRow+="|";
                    }
                    else{
                        printRow+=' ';
                    }
                }

            }
            console.log(printRow);
        }
    }

    else{
        for(var row =0;row<number; row++){
            let printRow="";

            for(var col=0;col<colLength; col++){
                if(row == 0 || row == Math.ceil(number/2)-1 || row == number-1)
                {
                    if(col==0 || col==Math.floor(colLength/2) || col==colLength-1){
                        printRow+="+";
                    }
                    else{
                        printRow+='-';
                    }

                }
                else{
                    if(col==0 || col==Math.floor(colLength/2) || col==colLength-1){
                        printRow+="|";
                    }
                    else{
                        printRow+=' ';
                    }
                }

            }
            console.log(printRow);
        }
    }
}

figureOfFourSquares([7]);
