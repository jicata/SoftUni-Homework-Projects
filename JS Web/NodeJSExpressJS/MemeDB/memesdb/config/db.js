const mongoose = require('mongoose');

let connection = 'mongodb://localhost:27017/memedb';

mongoose.Promise =global.Promise;

// module.exports = (() => {
//     mongoose.createConnection(connection, {
//         useMongoClient: true
//     })
//     console.log('mongo is up');
// })();

module.exports = (() =>{
    mongoose.connect(connection);
    console.log('sexesss');
})();