function CaclNeededBoxesForBittles(beersAndBoxes) {
    var bottles = Number(beersAndBoxes[0]);
    var boxCapcity = Number(beersAndBoxes[1]);
    var totalBoxestoBeUsed = Math.ceil(bottles / boxCapcity);
    console.log(totalBoxestoBeUsed);
    
}
CaclNeededBoxesForBittles([15,7]);