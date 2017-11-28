const nextId = require('./genId');

const plans = {};
const expenses = {};

const planner = {
    createPlan: (user, plan) => {
        if (!plans[user]) {
            plans[user] = {};
        }
        const userPlans = plans[user];
        if (!userPlans[plan.year]) {
            userPlans[plan.year] = {};
        }

        const newPlan = {
            income: plan.income,
            budget: plan.budget
        };

        userPlans[plan.year][plan.month] = newPlan;
        return newPlan;
    },
    all: (user, year) => {
        const result = emptyPlan();
        const userPlans = Object.assign(emptyUser(year), plans[user]);

        for (let month in userPlans[year]) {
            const budget = userPlans[year][month].budget;
            const expenses = planner.getExpenses(user, year, month);
            const balance = budget - expenses.reduce((total, current) => total + current.amount, 0);
            result[month] = {
                budget,
                balance
            }
        }

        return result;
    },
    getByMonth: (user, year, month) => {
        const userPlans = emptyUser(year);
        Object.assign(userPlans[year], plans[user][year]);
        return userPlans[year][month];
    },
    createExpense: (user, expense) => {
        if (!expenses[user]) {
            expenses[user] = {};
        }
        const userExpenses = expenses[user];

        let id = nextId();
        // Make sure new ID does not match existing value
        while (userExpenses[id]) {
            id = nextId();
        }

        const newExpense = {
            id,
            year: expense.year,
            month: expense.month,
            date: expense.date,
            creationTime: Date.now(),
            name: expense.name,
            amount: expense.amount,
            category: expense.category
        };

        userExpenses[id] = newExpense;
        return newExpense;
    },
    getExpenses: (user, year, month) => {
        const userExpenses = expenses[user];
        if (!userExpenses) {
            return [];
        }

        return Object
            .keys(userExpenses)
            .map(key => userExpenses[key])
            .filter(e => e.year == year && e.month == month)
            .sort((a, b) => a.creationTime - b.creationTime)
            .sort((a, b) => a.date - b.date);
    },
    deleteExpense: (user, id) => {
        const userExpenses = expenses[user];
        if (!userExpenses) {
            return false;
        }
        if (!userExpenses[id]) {
            return false;
        }
        delete userExpenses[id];
        return true;
    }
};

function emptyUser(year) {
    return {
        [year]: {
            "1": { budget: 0, income: 0 },
            "2": { budget: 0, income: 0 },
            "3": { budget: 0, income: 0 },
            "4": { budget: 0, income: 0 },
            "5": { budget: 0, income: 0 },
            "6": { budget: 0, income: 0 },
            "7": { budget: 0, income: 0 },
            "8": { budget: 0, income: 0 },
            "9": { budget: 0, income: 0 },
            "10": { budget: 0, income: 0 },
            "11": { budget: 0, income: 0 },
            "12": { budget: 0, income: 0 }
        }
    };
}

function emptyPlan() {
    return {
        "1": { budget: 0, balance: 0 },
        "2": { budget: 0, balance: 0 },
        "3": { budget: 0, balance: 0 },
        "4": { budget: 0, balance: 0 },
        "5": { budget: 0, balance: 0 },
        "6": { budget: 0, balance: 0 },
        "7": { budget: 0, balance: 0 },
        "8": { budget: 0, balance: 0 },
        "9": { budget: 0, balance: 0 },
        "10": { budget: 0, balance: 0 },
        "11": { budget: 0, balance: 0 },
        "12": { budget: 0, balance: 0 },
    };
}

module.exports = planner;