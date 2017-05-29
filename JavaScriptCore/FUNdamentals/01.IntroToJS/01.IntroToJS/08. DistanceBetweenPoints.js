function CalcDistanceBetweenTwoPts(coordinates) {
    x1 = Number(coordinates[0]);
    y1 = Number(coordinates[1]);
    x2 = Number(coordinates[2]);
    y2 = Number(coordinates[3]);
    var a = x1 -x2;
    var b = y1 - y2;

    var dist = Math.sqrt(a*a+b*b);
    console.log(dist);
}

CalcDistanceBetweenTwoPts(['2.34', '15.66', '-13.55', '-2.9985']);