/*jshint esversion: 6 */
function scoreToHtml(data) {
    let parsedJson = JSON.parse(data);
    console.log("<table>");
    console.log("<tr><th>name</th><th>score</th></tr>");
    for(let jsonObj of parsedJson){
        let name = escapeHtml(jsonObj.name);
        let score = jsonObj.score;

        let row = `<tr><td>${name}</td><td>${score}</td></tr>`;
        console.log(row);
    }
    console.log("</table>");
    function escapeHtml(unsafe) {
        return unsafe
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#39;");
    }
}


scoreToHtml('[{"name":"Pesho","score":479},{"name":"Gosho","score":205}]');