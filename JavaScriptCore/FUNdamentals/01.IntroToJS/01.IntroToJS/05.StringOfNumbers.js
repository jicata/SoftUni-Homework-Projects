function StringOfNumbers(number) {
    var upperBound = Number(number);
    var numberString ="1";
    for(i=2;i<=upperBound;i++){
        numberString+=i;
    }
    console.log(numberString);
}
StringOfNumbers(11);