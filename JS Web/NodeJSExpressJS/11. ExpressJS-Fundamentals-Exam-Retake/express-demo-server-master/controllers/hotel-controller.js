let Hotel = require('mongoose').model('Hotel');
let User = require('mongoose').model('User');

module.exports = {
    addHotelGet: (req, res) => {
        res.render('hotels/generateHotel')
    },
    addHotelPost: (req, res) => {
        let modelObj = req.body;
        let userId = req.user.id;

        let hotelObj = {
            title: modelObj.title,
            description: modelObj.description,
            location: modelObj.location,
            imageUrl: modelObj.image,
            creator: userId,
            createdOn: Date.now()
        };
        Hotel.create(hotelObj)
            .then(hotel => {
                User.findById(userId)
                    .then(user => {
                        user.hotels.push(hotel._id);
                        user.save();
                        res.redirect('/');
                    })
            })
    },
    list: (req, res) => {
        let pageQuery = Number(req.query.page);
        let limit = 2;

        Hotel.count({})
            .then(hotelCount => {
                let maxPages = Math.ceil(hotelCount / limit)

                let nextPage = Math.min(maxPages, pageQuery + 1);
                let prevPage = Math.max(0, pageQuery - 1);

                let pages = {
                    nextPage,
                    prevPage
                }

                Hotel.find({})
                    .sort('-createdOn')
                    .skip(pageQuery * limit)
                    .limit(limit)
                    .then(hotels => {
                        res.render('hotels/hotelList', { hotels, pages });
                    })
                    .catch(err => {
                        console.log(err);
                    })
            })


    },
    details: (req, res) => {
        let hotelId = req.params.id;
        Hotel.findById(hotelId)
            .populate({
                path: 'comments',
                populate: { path: 'author' }
            })
            .then(hotel => {
                hotel.comments = hotel.comments.sort((a, b) => a.createdOn < b.createdOn);
                console.log(hotel.comments);
                res.render(
                    'hotels/details',
                    {
                        selectedHotel: hotel,
                        comments: hotel.comments
                    });
            })
    },
    remove: (req, res) => {
        let hotelId = req.params.id;
        Hotel.findByIdAndRemove(hotelId)
            .then(hotel => {
                res.redirect('/list?page=0');
            })
    },
    editGet: (req, res) => {
        let hotelId = req.params.id;
        Hotel.findById(hotelId)
            .then(hotel => {
                res.render('hotels/edit', { hotel });
            })
    },
    editPost: (req, res) => {
        let hotelId = req.body.id;
        let bodyObj = req.body;
        let updatedObject = {
            title: bodyObj.title,
            location: bodyObj.location,
            imageUrl: bodyObj.image,
            description: bodyObj.description
        }
        Hotel.findByIdAndUpdate(hotelId, updatedObject, (err, hotel) => {
            res.redirect('/details/'+hotelId);
        })
    }
}