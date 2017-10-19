const express = require('express');
const handlebars = require('express-handlebars');
const cookieParser = require('cookie-parser');
const bodyParser = require('body-parser');
const session = require('express-session');
const passport = require('passport');
const fileUpload = require('express-fileupload');
const path = require('path');
const fs = require('fs');

module.exports = app => {
    app.engine('.hbs', handlebars({
        defaultLayout: 'main',
        extname: '.hbs'
    }));

    app.use(cookieParser());
    app.use(fileUpload());
    app.use(bodyParser.urlencoded({extended: true}));
    app.use(session({
        secret: '123456',
        resave: false,
        saveUninitialized: false
    }));
    app.use(passport.initialize());
    app.use(passport.session());

    app.use((req, res, next) => {
        if (req.user) {
            res.locals.currentUser = req.user;
        }
        next();
    });

    app.set('view engine', '.hbs');

    app.use(express.static('./static'));
    app.use('/static', express.static('./static'));
    app.use('/modules',express.static('node_modules'))
};