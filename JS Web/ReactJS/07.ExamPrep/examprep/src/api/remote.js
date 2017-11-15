async function register(name, email, password){
    let payload = {name, email, password};
    console.log(payload)
    return await fetch("http://localhost:5000/auth/signup", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body : JSON.stringify(payload)
    })
}

async function login(email, password){
    return await fetch("http://localhost:5000/auth/login", {
        method: "POST",
        body : JSON.stringify({email, password})
    })
}

export {register, login}