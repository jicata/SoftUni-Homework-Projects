/*jshint esversion: 6 */
function printMultiplicationTable(n) {
    n = Number(n);
    console.log("<table border=\"1\">");
    for(i=0; i<=n;i++){
        let line = "<tr>";
        if(i==0){
            for(j=0;j<=n; j++){
                line += j == 0 ? "<th>x</th>" : `<th>${j}</th>`;
            }
        }
        else{
            for(j=0;j<=n; j++){
                if(j==0){
                    line+=`<th>${i}</th>`;
                }
                else{

                    line+=`<td>${i*j}</td>`
                    }
                }
            }
        line+="</tr>";
        console.log(line);
        }

    console.log("</table>");
    }
printMultiplicationTable(["5"]);