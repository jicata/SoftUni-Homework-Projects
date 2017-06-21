/*jshint esversion: 6 */

function extractParenthesis(elementId) {
    let text = document.getElementById(elementId).textContent;
   // let text = elementId;
    let parenthesisPattern = /\(([^)]+)\)/g;
    let result = [];
    let match = parenthesisPattern.exec(text);
    while(match!=null){
        result.push(match[1]);
        match = parenthesisPattern.exec(text);
    }
    let realresult = result.join("; ");
    return realresult;
}
//extractParenthesis("This is some text. (this must be extracted). Some more text. (some more extract)");