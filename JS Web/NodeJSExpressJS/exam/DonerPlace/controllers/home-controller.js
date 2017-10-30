let Product = require('mongoose').model('Product');

module.exports = {
    index: (req, res) => {
        Product.find({})
            .then(products => {
                let beef = products.filter(p => p.category == 'Beef');
                let chicken = products.filter(p => p.category == 'Chicken');
                let lamb = products.filter(p => p.category == 'Lamb');
                let productsByCategory = {
                    chicken,
                    beef,
                    lamb
                }
                res.render('home/index', { products: productsByCategory });
            })
            .catch(err => {
                console.log(err);
                res.redirect('/');
            })
    },
    about: (req, res) => {
        res.render('home/about');
    }
};