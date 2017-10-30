const controllers = require('../controllers');
const restrictedPages = require('./auth');

module.exports = app => {
    app.get('/', controllers.home.index);
    app.get('/about', restrictedPages.hasRole('Admin'), controllers.home.about);
    app.get('/register', controllers.user.registerGet);
    app.post('/register', controllers.user.registerPost);
    app.post('/logout', controllers.user.logout);
    app.get('/login', controllers.user.loginGet);
    app.post('/login', controllers.user.loginPost);

    // Products
    app.get('/createProduct', restrictedPages.hasRole('Admin'), controllers.product.createGet);
    app.post('/createProduct', restrictedPages.hasRole('Admin'), controllers.product.createPost);

    // Orders
    app.get('/createOrder/:id', restrictedPages.isAuthed, controllers.order.createOrder);
    app.post('/checkout/:id', restrictedPages.isAuthed, controllers.order.checkout);
    app.get('/orderDetails/:id', restrictedPages.isAuthed, controllers.order.orderDetails);
    app.get('/listOrders', restrictedPages.isAuthed, controllers.order.listOrders);
    app.post('/editOrders', restrictedPages.hasRole('Admin'), controllers.order.editOrders);
    app.get('/allOrders', restrictedPages.hasRole('Admin'), controllers.order.allOrders);


    app.all('*', (req, res) => {
        res.status(404);
        res.send('404 Not Found');
        res.end();
    });
};