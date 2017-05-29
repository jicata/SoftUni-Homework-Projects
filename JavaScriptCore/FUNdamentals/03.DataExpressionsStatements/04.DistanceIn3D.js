function DistanceIn3D(coordinates) {
    var x1 = Number(coordinates[0]);
    var y1 = Number(coordinates[1]);
    var z1 = Number(coordinates[2]);
    var x2 = Number(coordinates[3]);
    var y2 = Number(coordinates[4]);
    var z2 = Number(coordinates[5]);
    var distance = Math.sqrt(Math.pow(x1-x2,2) + Math.pow(y1-y2,2) + Math.pow(z1-z2,2));
    console.log(distance)

}