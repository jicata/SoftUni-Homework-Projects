const mongoose = require('mongoose');

let connection = 'mongodb://localhost/memedb';

mongoose.Promise = global.Promise;

module.exports = (() => {
    mongoose.createConnection(connection, {
        useMongoClient: true
    })
    console.log('mongo is up');
})();