const host = 'http://localhost:5000/';

async function register(name, email, password) {
    const res = await fetch(host + 'auth/signup', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            name,
            email,
            password
        })
    });
    return await res.json();
}

async function login(email, password) {
    const res = await fetch(host + 'auth/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            email,
            password
        })
    });
    return await res.json();
}

function isAuthed(){
    return localStorage.authToken ? true : false
}

async function addExpense(expense) {
    const res = await fetch(host + 'plan/expense/', {
        method: 'POST',
        headers: {
            'Authorization': 'bearer ' + localStorage.authToken,
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(expense)
    });
    return await res.json();
}

async function getMonthlyBalance(year = 'current', month) {
    let url = host + `monthly/${year}${month ? "/" + month : ''}`
    const res = await fetch(url, {
        method: 'GET',
        headers: {
            'Authorization': 'bearer ' + localStorage.authToken,
            'Content-Type': 'application/json'
        }
    });
    return await res.json();
}

async function deleteExpense(expenseId) {
    const res = await fetch(host + `plan/expense/${expenseId}`, {
        method: 'DELETE',
        headers: {
            'Authorization': 'bearer ' + localStorage.authToken,
            'Content-Type': 'application/json'
        }
    });
    return await res.json();
}

async function updateMonthlyPlan(newPlan) {
    const res = await fetch(host + `plan/`, {
        method: 'POST',
        headers: {
            'Authorization': 'bearer ' + localStorage.authToken,
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newPlan)
    });
    return await res.json();
}

async function getYearlyBalance() {
    const res = await fetch(host + 'yearly/current', {
        method: 'GET',
        headers: {
            'Authorization': 'bearer ' + localStorage.authToken,
            'Content-Type': 'application/json'
        }
    });
    return await res.json();
}

export { register, login, addExpense, getMonthlyBalance, deleteExpense, updateMonthlyPlan, getYearlyBalance, isAuthed };