/*jshint esversion: 6 */
function splitIt(input) {
    let stringToSplit = input[0];
        let rgx = new RegExp(/("[\w\s,;:\.]+")/g);
    let result = stringToSplit.split(/[\s,;().]/g);
   for(let i=0;i < result.length;i++){
       if(result[i].length>0){

            console.log(result[i]);
       }
   }
}
splitIt(['let sum = 1 + 2;if(sum > 2){\tconsole.log(sum);}']);