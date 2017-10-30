const Product = require('mongoose').model('Product');
const Order = require('mongoose').model('Order');
const User = require('mongoose').model('User');

module.exports = {
    createOrder: (req, res) => {
        let donerId = req.params.id;
        Product.findById(donerId)
            .then(doner => {
                res.render('orders/customize-order', { doner });
            })
            .catch(err => {
                console.log(err);
                res.redirect('/');
            })
    },
    checkout: (req, res) => {
        let currentUserId = req.user.id;
        let dateOfCreation = formatDate(new Date(Date.now()));
        let productId = req.body.product_id;
        let toppings = [];
        for (let topping in req.body) {
            if (topping !== 'product_id') {
                toppings.push(topping)
            }
        }
        let orderModel = {
            creator: currentUserId,
            product: productId,
            createdOn: dateOfCreation,
            toppings: toppings,
            status: 'Pending'
        }
        Order.create(orderModel)
            .then(order => {
                User.findById(currentUserId)
                    .then(user => {
                        user.orders.push(order._id);
                        user.save();
                        res.redirect('/orderDetails/' + order._id);
                    })
            })
            .catch(err => {
                console.log(err);
                res.redirect('/');
            })
    },
    orderDetails: (req, res) => {
        let orderId = req.params.id;
        Order.findById(orderId)
            .populate('product')
            .then(order => {
                let doner = order.product;
                order = defineStatus(order, 'current');
                res.render('orders/order-details', { order, doner });
            })
            .catch(err => {
                console.log(err);
                res.redirect('/');
            })
    },
    listOrders: (req, res) => {
        let userId = req.user.id;
        Order.find({ 'creator': userId })
            .populate('product')
            .then(orders => {
                for (let order of orders) {
                    order = defineStatus(order, 'selected');
                }
                console.log(orders);
                res.render('orders/order-status', { orders: orders })
            })
            .catch(err => {
                console.log(err);
                res.redirect('/');
            })
    },
    allOrders: (req, res) => {
        Order.find({})
            .populate('product')
            .then(orders => {
                for (let order of orders) {
                    order = defineStatus(order, 'selected');
                }
                res.render('orders/all-orders', { orders });
            })
            .catch(err => {
                console.log(err);
                res.redirect('/');
            })
    },
    editOrders: (req, res) => {
        let postParams = req.body;
        for (let id in postParams) {
            let status = postParams[id];
            Order.findByIdAndUpdate(id, { 'status': status })
                .then(order => {
                    order.save();
                })
                .catch(err => {
                    console.log(err);
                    res.redirect('/');
                })
        }
        res.redirect('/allOrders');
    }
};

function defineStatus(order, classToAttach) {
    switch (order.status) {
        case 'Pending':
            order.Pending = classToAttach;
            break;
        case 'In progress':
            order.InProgress = classToAttach;
            break;
        case 'In transit':
            order.InTransit = classToAttach;
            break;
        case 'Delivered':
            order.Delivered = classToAttach;
            break;
        default:
            throw new Error('Bravo kiro');
    }
    return order;
}

//str8 up copy paste from SO
function formatDate(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = hours >= 12 ? 'pm' : 'am';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ' ' + ampm;
    return date.getMonth() + 1 + "/" + date.getDate() + "/" + date.getFullYear() + "  " + strTime;
}