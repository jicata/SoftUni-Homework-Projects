const planner = require('../data/planner');

module.exports = {
    getCurrent: (req, res) => {
        const user = req.user.email;
        const today = new Date();
        const year = today.getFullYear();
        const month = today.getMonth() + 1;
        const result = planner.getByMonth(user, year, month);
        result.expenses = planner.getExpenses(user, year, month);

        res.status(200).json(result);
    },
    getMonth: (req, res) => {
        const user = req.user.email;
        const year = req.params.year;
        const month = req.params.month;
        const result = planner.getByMonth(user, year, month);
        result.expenses = planner.getExpenses(user, year, month);

        res.status(200).json(result);
    },
}