/*jshint esversion: 6 */
function cutAndPrepareCrystal(input) {
    let minSize = Number(input[0]);
    var countOfOp = 0;
    let currentOp = "";
    let lastOp = "";
    let xray = false;
    let checkForOp = function (currentOp, countOfOp, lastOp, crystal) {
        if(lastOp==="") {
            lastOp = currentOp;
        }
        else if(currentOp!=lastOp){
            console.log(`${lastOp} x${countOfOp}`);
            crystal = Math.floor(crystal);
            countOfOp = 0;
            console.log("Transporting and washing");
        }
        return crystal;
    };

    let processCrystal = function (crystal) {
      while(crystal != minSize){
          if(crystal / 4 >= minSize){
              crystal/=4;
              currentOp = "Cut";
              crystal = checkForOp(currentOp,countOfOp,lastOp,crystal);
              if(lastOp!="" && currentOp!=lastOp){
                  countOfOp=1;
              }
              else{
                  countOfOp++;
              }
              lastOp = currentOp;
          }
          else if(crystal - crystal/5 >= minSize){
              crystal-=crystal/5;
              currentOp = "Lap";
              crystal =checkForOp(currentOp,countOfOp,lastOp,crystal);
              if(lastOp!="" && currentOp!=lastOp){
                  countOfOp=1;
              }
              else{
                  countOfOp++;
              }
              lastOp = currentOp;
          }
          else if(crystal - 20 >= minSize){
              crystal-=20;
              currentOp = "Grind";
              crystal =checkForOp(currentOp,countOfOp,lastOp,crystal);
              if(lastOp!="" && currentOp!=lastOp){
                  countOfOp=1;
              }
              else{
                  countOfOp++;
              }
              lastOp = currentOp;
          }
          else if(crystal - 2 >= minSize || (!xray && ((crystal-2)+1 == minSize))){
              crystal-=2;
              currentOp = "Etch";
              crystal =checkForOp(currentOp,countOfOp,lastOp,crystal);
              if(lastOp!="" && currentOp!=lastOp){
                  countOfOp=1;
              }
              else{
                  countOfOp++;
              }
              lastOp = currentOp;
          }
          else if(!xray){
              crystal+=1;
              currentOp = "X-ray";
              crystal =checkForOp(currentOp,countOfOp,lastOp,crystal);
              if(lastOp!="" && currentOp!=lastOp){
                  countOfOp=1;
              }
              else{
                  countOfOp++;
              }

              lastOp = currentOp;
              xray = true;
          }
          if(crystal == minSize){
              console.log(`${lastOp} x${countOfOp}`)
              if(lastOp!="X-ray"){
                  console.log("Transporting and washing");
              }
          }


      }
    };
    for(let i = 1; i<input.length; i++){
        console.log(`Processing chunk ${input[i]} microns`);
        processCrystal(Number(input[i]));
       // console.log(`${lastOp} x${countOfOp}`);
        lastOp = "";
        currentOp="";
        countOfOp = 0;
        console.log(`Finished crystal ${minSize} microns`);
    }

}
cutAndPrepareCrystal([1000, 4000, 8100]);
