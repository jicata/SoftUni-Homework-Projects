let Comment = require('mongoose').model('Comment');
let Hotel = require('mongoose').model('Hotel');
let User = require('mongoose').model('User');


module.exports = {
    addComment: (req, res) => {
        let hotelId = req.params.id;
        let currentUserId = req.user.id;
        let modelObj = req.body;

        let commentObj = {
            title: modelObj.title,
            content: modelObj.comment,
            createdOn: Date.now(),
            author: currentUserId,
            hotel: hotelId
        }

        Comment.create(commentObj)
            .then(comment => {
                Hotel.findById(hotelId)
                    .then(hotel => {
                        hotel.comments.push(comment._id);
                        hotel.save();
                        User.findById(currentUserId)
                            .then(user => {
                                user.comments.push(comment._id);
                                user.save();
                                res.redirect('/details/' + hotelId)
                            })
                    })
            })

    }
}