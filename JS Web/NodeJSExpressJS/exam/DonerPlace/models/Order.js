const mongoose = require('mongoose');
const ObjectId = mongoose.Schema.ObjectId;

const orderSchema = new mongoose.Schema({
    creator: { type: ObjectId, ref: 'User', required: true },
    product: { type: ObjectId, ref: 'Product', required: true },
    createdOn: {type: String, required: true},
    toppings: [{type: String, required: true}],
    status: {type: String, required: true}
});

const Order = mongoose.model('Order', orderSchema);

module.exports = Order;
