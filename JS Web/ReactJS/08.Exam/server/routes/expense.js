const planner = require('../data/planner');

module.exports = {
    postExpense: (req, res) => {
        const expense = req.body;

        const validationResult = validateExpense(expense);
        if (!validationResult.success) {
            return res.status(200).json({
                success: false,
                message: validationResult.message,
                errors: validationResult.errors
            });
        }

        const result = planner.createExpense(req.user.email, expense);

        console.log('Expense saved.');
        res.status(200).json({
            success: true,
            message: 'Expense saved successfuly.',
            expense: result
        });
    },
    deleteExpense: (req, res) => {
        const user = req.user.email;
        const id = req.params.id;

        if (!planner.deleteExpense(user, id)) {
            return res.status(400).json({
                success: false,
                message: "Expense ID not found: " + id,
                errors: { id: "Expense ID not found: " + id }
            });
        }
        console.log("Expense deleted.");
        res.status(200).json({
            success: true,
            message: 'Expense deleted successfuly.',
            expense: id
        });
    },
}

function validateExpense(expense) {
    const errors = {};
    let isFormValid = true;
    let message = '';

    if (expense.year !== parseInt(expense.year)) {
        isFormValid = false;
        errors.year = 'Year must be a number.';
    }

    if (expense.month !== parseInt(expense.month)) {
        isFormValid = false;
        errors.month = 'Month must be a number.';
    }

    if (expense.date !== parseInt(expense.date)) {
        isFormValid = false;
        errors.date = 'Date must be a number.';
    }

    if (expense.month < 1 || expense.month > 12) {
        isFormValid = false;
        errors.month = 'Month must be an integer between 1 and 12.';
    }

    if (expense.date < 1 || expense.date > 31) {
        isFormValid = false;
        errors.date = 'Date must be an integer between 1 and 31.';
    }

    if (typeof expense.name !== 'string' || expense.length < 1) {
        isFormValid = false;
        errors.name = 'Name must be at least 1 characters long.';
    }

    if (typeof expense.category !== 'string' || expense.category < 1) {
        isFormValid = false;
        errors.category = 'Category must be at least 1 characters long.';
    }

    if (expense.amount !== parseFloat(expense.amount)) {
        isFormValid = false;
        errors.amount = 'Amount must be a number.';
    }

    if (!isFormValid) {
        message = 'Check the form for errors.';
    }

    return {
        success: isFormValid,
        message,
        errors
    };
}