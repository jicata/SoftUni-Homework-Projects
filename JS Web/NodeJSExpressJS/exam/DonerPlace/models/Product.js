const mongoose = require('mongoose');

const productSchema = new mongoose.Schema({
    category: { type: String, required: true, validate: [categoryValidator, 'Category must be beef, chicken or lamb'] },
    size: { type: Number, requried: true, validate: [sizeValidator, 'Size must be between 17 and 24 cm'] },
    imageUrl: { type: String, required: true },
    toppings: [{ type: String }]
});

function sizeValidator(value) {
    let size = Number(value);
    if (size < 17 || size > 24) {
        return false;
    }
    return true;
}

function categoryValidator(value) {
    let result = value.match(/^(Chicken|Beef|Lamb)$/);
    return result;
}

function toppingsValidator(values) {
    let pattern = /^(pickle|tomato|onion|lettuce|hot\ssauce|extra\ssauce)$/;
    for (let value of values) {
        let match = value.match(/^(pickle|tomato|onion|lettuce|hot\ssauce|extra\ssauce)$/);
        if (!match) {
            return false;
        }
    }
    return true;
}

const Product = mongoose.model('Product', productSchema);

module.exports = Product;
