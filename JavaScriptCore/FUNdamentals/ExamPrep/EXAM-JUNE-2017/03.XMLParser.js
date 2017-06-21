/*jshint esversion: 6 */
function XMLParser(singleStringInputViktore) {
    let attributePattern = /^<message(\s+?(([a-z]+)="([a-zA-Z0-9\s.]+)")\s*?)(>)*/;
    let messagePattern = /^<message\s*(?:.)*>(([\s\S])*?)<\/message>$/gm;

    let localizedText = singleStringInputViktore;

    let validMessage = messagePattern.exec(singleStringInputViktore);
    if(validMessage == null){
        return "Invalid message format";
    }

    let sender = "";
    let recipient = "";
    let reachedEndOfTag = false;
    let expr = new RegExp(attributePattern);
    let attributeMatch = expr.exec(localizedText);
    while(attributeMatch!=null){
        let attributeKey = attributeMatch[3];
        if(attributeKey == "to"){
            recipient = attributeMatch[4];
        }
        if(attributeKey == "from"){
            sender = attributeMatch[4];
        }
        if(attributeMatch[5]!=undefined){
            reachedEndOfTag = true;
        }
        localizedText = localizedText.replace(attributeMatch[2],"");
        attributeMatch = expr.exec(localizedText);
    }
    if(!reachedEndOfTag){
        return "Invalid format";
    }
    else if(recipient=="" || sender==""){
       return "Missing attributes";
    }

    let messageBody = validMessage[1].split("\n");
    let html = `<article>\n`;
    html+=` <div>From: <span class="sender">${sender}</span></div>\n`;
    html+=` <div>To: <span class="recipient">${recipient}</span></div>\n`;
    html+=` <div>\n`;
    for(let paragraph of messageBody){
        html+=`  <p>${paragraph}</p>\n`;
    }
    html+=` </div>\n`;
    html+=`</article>`;
    console.log(html)

}
//XMLParser("<message to=\"Bob\" from=\"Alice\" timestamp=\"1497254092\">Hey man,\\nwhat's up?</message>");
//XMLParser("<message to=\"Edward\" secret=\"true\">VGhpcyBpcyBhIHRlc3Q</message>");
// XMLParser(`<message to="Bob" from="Alice" timestamp="1497254114">Same old, same old
// Let's go out for a beer</message>`)