const mongoose = require('mongoose');

let ObjectId = mongoose.Schema.ObjectId;

const carSchema = new mongoose.Schema({
    name: {type: mongoose.Schema.Types.String, required: true},
    price: {type: mongoose.Schema.Types.Number, required: true},
    image: {type: mongoose.Schema.Types.String, required: true},
    owner: {type: ObjectId},
    rented: {type: Boolean, default: false},
    addedOn: {type: Date, required: true}
});

const Car = mongoose.model('Car', carSchema);

module.exports = Car;