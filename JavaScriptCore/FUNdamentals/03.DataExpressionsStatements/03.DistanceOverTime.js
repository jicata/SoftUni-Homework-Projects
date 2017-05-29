function DistanceOverTime(units) {
    var v1 = Number(units[0]);
    var v2 = Number(units[1]);
    var t = Number(units[2])/3600;
    var d1 =v1 * t;
    var d2 = v2 * t;
    var distance = Math.abs(d1-d2);
    console.log(distance*1000);

}
DistanceOverTime([5, -5, 40]);