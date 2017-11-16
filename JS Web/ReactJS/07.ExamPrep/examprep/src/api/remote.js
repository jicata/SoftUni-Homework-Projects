const hostUrl = "http://localhost:5000/";

async function register(name, email, password) {
    let payload = { name, email, password };
    const response = await fetch(hostUrl + "auth/signup", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(payload)
    })
    return response.json();
}

async function login(email, password) {
    const response = await fetch(hostUrl + "auth/login", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ email, password })
    })
    return response.json();
}

async function fetchPage(pageNumber) {
    const response = await fetch(hostUrl + "furniture/all?page=" + pageNumber)
    return response.json();
}

async function fetchDetails(furnitureId) {
    const response = await fetch(hostUrl + "furniture/details/" + furnitureId)
    return response.json();
}

async function fetchSearchPage(query, page) {
    const response = await fetch(hostUrl + `furniture/all/page=${page}&search=${query}`)
    return response.json();
}

async function fetchStats() {
    const response = await fetch(hostUrl + `stats`)
    return response.json();
}

export { register, login, fetchPage, fetchDetails, fetchSearchPage, fetchStats }