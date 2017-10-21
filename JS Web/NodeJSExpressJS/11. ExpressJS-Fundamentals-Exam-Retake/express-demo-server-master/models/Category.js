const mongoose = require('mongoose');
const ObjectId = mongoose.Schema.ObjectId;

const categorySchema = new mongoose.Schema({
    name: { type: String, required: true },
    comments: [{ type: ObjectId, ref: 'Hotel' }]
});

const Category = mongoose.model('Category', categorySchema);


module.exports = Category;
