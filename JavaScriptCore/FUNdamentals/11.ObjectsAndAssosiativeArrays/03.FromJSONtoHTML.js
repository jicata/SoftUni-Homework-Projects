/*jshint esversion: 6 */
function fromJSONToHTMLTable(input){
    let html = "<table>\n";
    let arr = JSON.parse(input);
    html += " <tr>";
    for (let key of Object.keys(arr[0])){
        html += `<th>${key}</th>`;
    }
    html += "</tr>\n";
    for (let obj of arr) {

        html+="<tr>";
       for(let key of Object.keys(obj)){
           if(isNaN(obj[key])){
               html+=`<td>${escapeHtml(obj[key])}</td>`;
           }
           else{
               html+=`<td>${obj[key]}</td>`;
           }

       }
       html+="</tr>\n";
    }

    function escapeHtml(unsafe) {
        return unsafe
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#39;");
    }

    return html + "</table>";


}
console.log(fromJSONToHTMLTable(['[{"Name":"Pesho","Age":20,"City":"Sofia"},{"Name":"Gosho","Age":18,"City":"Plovdiv"},{"Name":"Angel","Age":18,"City":"Veliko Tarnovo"}]']
));