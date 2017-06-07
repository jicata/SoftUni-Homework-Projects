/*jshint esversion: 6 */
function spyMasterIntensifies(encodeMessages){
    "use strict";
    let specialKey = encodeMessages.shift();
    let legitPattern = `(^|\\s)([${specialKey.toLowerCase()}${specialKey.toUpperCase()}]{${specialKey.length}}\\s+)([A-Z!%$#]{8,})([\\s.,]|$)`;
    let messageRegex = new RegExp(legitPattern,'g');
    for(let line of encodeMessages){
        let text = line.replace(messageRegex, function (match, gr1, gr2, gr3,gr4){
            gr3 = gr3
                .replace(/!/g,'1')
                .replace(/%/g, '2')
                .replace(/\#/g,'3')
                .replace(/\$/g,'4')
                .replace(/[A-Z]/g,x=>x.toLowerCase());
            return gr1+gr2+gr3+gr4
        });
    console.log(text);
    }
}
// spyMasterIntensifies(['specialKey',
//     'In this text the specialKey HELLOWORLD! is correct, but',
//     'the following specialKey $HelloWorl#d and spEcIaLKEy HOLLOWORLD1 are not, while',
//     'SpeCIaLkeY   SOM%%ETH$IN and SPECIALKEY ##$$##$$ are!']);
