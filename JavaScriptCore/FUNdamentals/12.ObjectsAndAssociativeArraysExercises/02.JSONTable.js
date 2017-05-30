/**
 * Created by Administrator on 30.5.2017 г..
 */
function JSONTab(data){

    let html = "<table>\n";
    for(let dataRow of data){
        let jsonObj = JSON.parse(dataRow);
        html+=`<tr>\n<td>${escapeHtml(jsonObj["name"])}</td>\n<td>${escapeHtml(jsonObj.position)}</td>\n<td>${jsonObj.salary}</td>\n</tr>\n`
    }
    html+="</table>";

    function escapeHtml(unsafe) {
        return unsafe
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#39;");
    }
    console.log(html);
}
JSONTab(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}'
]);