var express = require('express');
var router = express.Router();

var tags = require('../models/GenreSchema');

/* GET users listing. */
router.get('/', function(req, res, next) {
  let allTags = [];
  let allTagsProjection = tags
  .find({})
  .exec(function(err,data){
    for(let kur of data){
      allTags.push(kur);
    }
    res.render('addMeme',{tags:allTags})
  });
  
 
}).post('/', (req, res, next) => {
  let memeFfile = req.files.meme;
  memeFfile.mv("../belo.jpg");
})

module.exports = router;
