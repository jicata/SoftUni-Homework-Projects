const planner = require('../data/planner');

module.exports = {
    postPlan: (req, res) => {
        const plan = req.body;

        const validationResult = validatePlan(plan);
        if (!validationResult.success) {
            return res.status(200).json({
                success: false,
                message: validationResult.message,
                errors: validationResult.errors
            });
        }

        const result = planner.createPlan(req.user.email, plan);

        console.log('Plan saved.');
        res.status(200).json({
            success: true,
            message: 'Plan saved successfuly.',
            plan: result
        });
    }
}

function validatePlan(plan) {
    const errors = {};
    let isFormValid = true;
    let message = '';

    if (plan.year !== parseInt(plan.year)) {
        isFormValid = false;
        errors.year = 'Year must be a number.';
    }

    if (plan.month !== parseInt(plan.month)) {
        isFormValid = false;
        errors.month = 'Month must be a number.';
    }

    if (plan.month < 1 || plan.month > 12) {
        isFormValid = false;
        errors.month = 'Month must be an integer between 1 and 12.';
    }

    if (plan.income !== parseFloat(plan.income)) {
        isFormValid = false;
        errors.income = 'Income must be a number.';
    }

    if (plan.budget !== parseFloat(plan.budget)) {
        isFormValid = false;
        errors.budget = 'Budget must be a number.';
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