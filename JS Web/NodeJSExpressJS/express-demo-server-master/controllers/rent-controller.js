const Car = require('mongoose').model('Car');
const User = require('mongoose').model('User');

module.exports = {
    rentCar: (req, res) => {
        let userId = req.user.id;
        let carId = req.body.id;

        Car.findByIdAndUpdate(carId, { rented: true })
            .then(car => {
                User.findById(userId, (err, user) => {
                    user.carList.push(car);
                    user.save();
                    res.redirect('/rents');
                })
            })
    },
    rents: (req, res) => {
        let currentUserId = req.user.id;

        User.findById(currentUserId)
            .populate('carList')
            .then(user => {
                res.render('rent/myRents', { cars: user.carList });
            })
    }
}