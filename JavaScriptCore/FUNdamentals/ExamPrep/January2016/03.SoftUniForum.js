/*jshint esversion: 6 */
function softUniForum(data){
    "use strict";
    if(data[data.length-1]==""){
        data.pop();
    }
    let text= "";
    let bannedUsers = data.pop().split(" ");
    for(let piece of data){
        text+=`${piece}|`;
    }
    let replacerCode = [];
    let codeBlockPattern = /<code>(.*?)<\/code>/g;
    let match = codeBlockPattern.exec(text);
    while(match!=null){
        let codeBlock = match[1];
        let replacer = Array(codeBlock.length).join("@");
        text = text.replace(codeBlock,replacer);
        replacerCode.push({replacer:replacer,code:codeBlock});

        match = codeBlockPattern.exec(text);
    }

    let bannedPattern = "#(";
    for(let i = 0; i < bannedUsers.length; i++){
        bannedPattern+=`${bannedUsers[i]}|`;
    }
    bannedPattern = bannedPattern.substr(0,bannedPattern.length-1);
    bannedPattern +=")";
    let bannedExpression = new RegExp(bannedPattern);

    let bannedMatch = bannedExpression.exec(text);
    while(bannedMatch!=null){
        let bannedUser = `#${bannedMatch[1]}`;
        text = text.replace(bannedUser,Array(bannedUser.length).join("*"));
        bannedMatch = bannedExpression.exec(text);
    }

    let userNamePattern = /#([a-zA-Z][a-zA-Z0-9-_]+[a-zA-Z0-9])\b/g;
    let usernameMatch = userNamePattern.exec(text);

    while(usernameMatch!=null){
        let username= `#${usernameMatch[1]}`;
        let replacer = `<a href="/users/profile/show/${usernameMatch[1]}">${usernameMatch[1]}</a>`;
        text = text.replace(username,replacer);
        usernameMatch = userNamePattern.exec(text);
    }
    for(let replacers of replacerCode){
        text = text.replace(replacers.replacer,replacers.code)
    }
    for(let res of text.split("|")){
        console.log(res);
    }
}
// softUniForum(["#RoYaL: I'm not sure what you mean,",
//     "but I am confident that I've written",
//     "everything correctly. Ask #iordan_93",
// "and #pesho if you don't believe me",
// "<code>",
// "#trying to print stuff",
// "print(\"yoo\")",
// "</code>",
// "pesho gosho"]);

// softUniForum(["<code>",
//     "#gosho",
//     "#pesho",
//         "#madafaka",
//     "</code>",
//     "#1nval1d says yoo and I had to reply, so I",
//     "typed 'yoo muthafucka' and then",
//     "#another_invalid_ said gz gg gj so I had to go incognito",
//     "and changed my user name to:",
//     "#Make_me_a_LINK!",
//         "the code in question is:",
//     "<code>",
//     "Console.WriteLine(\"#nimoa\")\;",
//     "</code>",
//     "Make_me_a_LINK"]);