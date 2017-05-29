function PrintChessBoard(dimensions) {
    dimensions = Number(dimensions[0]);
    console.log("<div class=\"chessboard\">");
    for(i=0;i < dimensions;i++){
        console.log("<div>")
        for(j=0; j<dimensions;j++){
            if(i%2==0)
            {
                if(j%2==0){
                    console.log("<span class=\"black\"></span>");
                }
                else{
                    console.log("<span class=\"white\"></span>");
                }
            }
            else{
                if(j%2!=0){
                    console.log("<span class=\"black\"></span>");
                }
                else{
                    console.log("<span class=\"white\"></span>");
                }
            }

        }
        console.log("</div>")
    }
    console.log("</div>")
}
PrintChessBoard([3]);