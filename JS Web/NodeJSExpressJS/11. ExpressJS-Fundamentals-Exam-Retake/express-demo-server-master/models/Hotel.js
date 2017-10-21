const mongoose = require('mongoose');
const ObjectId = mongoose.Schema.ObjectId;

const hotelSchema = new mongoose.Schema({
    title: { type: String, required: true },
    description: { type: String, required: true },
    location: { type: String, required: true },
    imageUrl: { type: String, required: true },
    createdOn: {type: Date, required: true},
    creator: {type: ObjectId, ref: 'User'},
    comments: [{ type: ObjectId, ref: 'Comment' }]
});

const Hotel = mongoose.model('Hotel', hotelSchema);


module.exports = Hotel;
