const Product = require('mongoose').model('Product');

module.exports = {
    createGet: (req, res) => {
        res.render('products/create-product');
    },
    createPost: (req, res) => {
        let bodyObj = req.body;
        let toppings = bodyObj.toppings.split(',');

        let productObj = {
            category: bodyObj.category,
            size: bodyObj.size,
            imageUrl: bodyObj.imageUrl,
            toppings: toppings
        }

        Product.create(productObj)
            .then(product => {
                res.redirect('/');
            })
            .catch(err => {
                console.log(err);
                res.redirect('/');
            })

    }
};