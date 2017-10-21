const mongoose = require('mongoose');
let ObjectId = mongoose.Schema.ObjectId;

const commentSchema = new mongoose.Schema({
    title: { type: String, required: true },
    content: {type: String, required: true},
    createdOn: { type: Date, required: true },
    author: { type: ObjectId, ref: 'User' },
    hotel: { type: ObjectId, ref: 'Hotel' }
});

const Comment = mongoose.model('Comment', commentSchema);


module.exports = Comment;
