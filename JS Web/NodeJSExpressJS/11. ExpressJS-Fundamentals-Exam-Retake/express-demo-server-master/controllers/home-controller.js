let Hotel = require('mongoose').model('Hotel');

module.exports = {
    index: (req, res) => {
        Hotel.find({})
            .then(hotels => {
                res.render('home/index', {hotels});
            })      
    },
    about: (req, res) => {
        res.render('home/about');
    }
};