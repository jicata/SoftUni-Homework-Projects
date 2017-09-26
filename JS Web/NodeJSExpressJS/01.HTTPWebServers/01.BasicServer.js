/*jshint esversion: 6 */
const http = require('http');

http.createServer((req,res)=>{
    "use strict";
    res.write('kur  za bila');
    res.end();
}).listen(1337);
console.log(" it's doing things");