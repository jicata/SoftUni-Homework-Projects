function Rounding([number, precision]) {
    var afterDecPoint = number.toString().split('.')[1].length;
    //[number, precision] = [number, precision].map(Number);
    if(afterDecPoint < precision){
        console.log(number);
    }
    else{
        console.log(number.toFixed(precision));
    }
}
Rounding([10.5, 3]);