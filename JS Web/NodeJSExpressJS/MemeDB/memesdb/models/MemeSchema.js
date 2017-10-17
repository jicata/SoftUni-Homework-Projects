const mongoose = require('mongoose');

let ObjectId = mongoose.Types.Schema.ObjectId;

let meme  = new mongoose.Schema({
    name: {type: String, required:false},
    dateOfCreation: {type: Date, default: Date.now()},
    memeTitle:[{type:String, require: true}],
})

module.exports = mongoose.model('Meme', meme);