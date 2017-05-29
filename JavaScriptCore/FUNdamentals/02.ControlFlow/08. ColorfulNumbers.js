function PrintColourfulNumbers(number) {
    number = Number(number[0]);
    console.log("<ul>");
    for(i =1; i<=number; i++){
        if(i%2>0){
            console.log("<li><span style='color:green'>"+i+"</span></li>")
        }
        else{
            console.log("<li><span style='color:blue'>"+i+"</span></li>")
        }
    }
    console.log("</ul>")
}/**
 * Created by Maika on 17-Feb-17.
 */
