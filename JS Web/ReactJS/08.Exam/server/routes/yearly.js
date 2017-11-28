const planner = require('../data/planner');

module.exports = {
    getCurrent: (req, res) => {
        const user = req.user.email;
        const year = (new Date()).getFullYear();
        const result = planner.all(user, year);

        res.status(200).json(result);
    },
    getYear: (req, res) => {
        const user = req.user.email;
        const year = req.params.year;
        const result = planner.all(user, year);

        res.status(200).json(result);
    },
}