/*jshint esversion: 6 */

var express = require('express');

var app = express();

var port = 5000;

app.use(express.static('public'));
app.use(express.static('src/views'));


app.get('/books',function(req,res){
    "use strict";
    res.send('Hello world');
});

app.listen(port,function(err){
    "use strict";
    console.log('running server on port ' + port)
});