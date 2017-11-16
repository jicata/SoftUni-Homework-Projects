async function register(name, email, password){
    let payload = {name, email, password};
    const response = await fetch("http://localhost:5000/auth/signup", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body : JSON.stringify(payload)
    })
    return response.json();
}

async function login(email, password){
    const response =  await fetch("http://localhost:5000/auth/login", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body : JSON.stringify({email, password})
    })
    return response.json();
}

export {register, login}