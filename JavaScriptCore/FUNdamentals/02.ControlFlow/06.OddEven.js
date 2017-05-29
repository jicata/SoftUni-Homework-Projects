function OddEven(number) {
    var number = Number(number);
    if(number % 1 !== 0) {
        console.log("invalid")
    }
    else if(number % 2 === 0){
        console.log("even");
    }
    else{
        console.log("odd");
    }
}/**
 * Created by Maika on 17-Feb-17.
 */
OddEven(0);