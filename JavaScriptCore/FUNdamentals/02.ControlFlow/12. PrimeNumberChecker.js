function CheckIfNumIsPrime(number) {
    number = Number(number[0]);
    for(i=2; i<=Math.sqrt(number);i++){
        if(number % i == 0){
            console.log("false");
            return;
        }
    }
    if(number>1){
        console.log("true");
        return;
    }
    console.log("false");

}
CheckIfNumIsPrime(['81']);