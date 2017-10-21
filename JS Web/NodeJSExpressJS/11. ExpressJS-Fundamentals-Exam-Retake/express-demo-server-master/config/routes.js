const controllers = require('../controllers');
const restrictedPages = require('./auth');

module.exports = app => {

    // User
    app.get('/', controllers.home.index);
    app.get('/about', restrictedPages.hasRole('Admin'), controllers.home.about);
    app.get('/register', controllers.user.registerGet);
    app.post('/register', controllers.user.registerPost);
    app.post('/logout', controllers.user.logout);
    app.get('/loginRegister', controllers.user.loginGet);
    app.post('/login', controllers.user.loginPost);
    app.get('/profile/:username', controllers.user.profile);

    // Hoetels
    app.get('/addHotel', controllers.hotel.addHotelGet);
    app.post('/addHotel', controllers.hotel.addHotelPost);
    app.get('/list', controllers.hotel.list);
    app.get('/details/:id', controllers.hotel.details);
    app.get('/remove/:id', controllers.hotel.remove);
    app.get('/edit/:id', controllers.hotel.editGet);
    app.post('/edit', controllers.hotel.editPost);

    // Comments
    app.post('/addComment/:id', controllers.comment.addComment);

    // Categories
    app.get('/addCategories', controllers.category.create)

    app.all('*', (req, res) => {
        res.status(404);
        res.send('404 Not Found');
        res.end();
    });
};