const Car = require('mongoose').model('Car');
const User = require('mongoose').model('User');
module.exports = {
    addCarGet: (req, res) => {
        res.render('cars/add');
    },
    addCarPost: (req, res) => {
        if (!req.files) {
            return res.status(400).send('No files were uploaded.');
        }
        let image = req.files.image;
        let destination = `/static/images/${image.name}`;
        image.mv(destination, (err) => {
            if (err) {
                console.log(err);
                return res.status(500).send(err);
            }
            let carObj = {
                name: req.body['model'],
                price: req.body['price'],
                image: destination,
                addedOn: Date.now()
            }
            Car.create(carObj)
                .then(car => {
                    res.render('cars/add', { status: true });
                })
                .catch(err => {
                    console.log('failed to add car due to ' + err);
                    res.render('cars/add', { error: true });
                })
        })
    },
    allCars: (req, res) => {
        let queryPage = Number(req.query.page);
        let nameQuery = { '$regex': '.*' };
        if (req.query.name) {
            nameQuery = { '$regex': req.query.name };
        }
        let nextPage = queryPage + 1;
        let prevPage = queryPage - 1;

        Car.find({})
            .where('name', nameQuery)
            .where('rented').equals(false)
            .sort('-addedOn')
            .skip(queryPage * 10)
            .limit(10)
            .then((cars) => {
                if (prevPage < 0) {
                    prevPage = 0;
                }
                if (cars.length < 10) {
                    nextPage = undefined
                }
                let pages = {
                    nextPage,
                    prevPage
                }
                res.render('cars/all', { cars: cars, pages: pages })
            })
    },
    details: (req, res) => {
        let carId = req.params.id;
        Car.findById(carId).then((car) => {
            if (!car) {
                res.render('home/index');
            }
            console.log(car.image);
            res.render('cars/details', { car: car });
        })
    },
    edit: (req, res) => {
        let carId = req.params.id;
        Car.findById(carId)
            .then(car => {
                res.render('cars/edit', { car: car })
            })
    },
    editPost: (req, res) => {
        let carId = req.body.id;
        Car.findById(carId, (err, car) => {
                let imagePath = car.image;
                if (req.files) {
                    image = req.files.image;
                    let destination = `/static/images/${image.name}`;
                    imagePath = destination;
                    image.mv(destination, (err) => {
                        if (err) {
                            console.log(err);
                            return res.status(500).send(err);
                        }
                    })
                }
                let carObj = {
                    name: req.body['model'],
                    price: req.body['price'],
                    rented: req.body.rented
                };
                car.name = carObj.name;
                car.price = carObj.price;
                if(carObj.rented){
                    car.rented = true;
                }else{
                    car.rented = false;
                }
                car.image = imagePath;
                car.save();
                
            })
        console.log(req.body);
    }
};