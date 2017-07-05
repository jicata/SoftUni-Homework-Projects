/*jshint esversion: 6 */
function domHighlighter(selector) {
    let $target=$(selector).children();
    while($target.length) {
        $target=$target.children();
    }
    let end=$target.end();
    $(end[0]).addClass('highlight');
    let container=$(selector);
    while(end[0]!=container[0]) {
        end=$(end[0]).parent();
        end.addClass('highlight');
    }
    // let element = $(selector).children().sort((a,b)=>sortChildren(a,b))[0];
    // while(element){
    //     $(element).addClass('highlight');
    //     element = $(element).children().sort((a,b)=>sortChildren(a,b))[0]
    // }
    // $(element).addClass('highlight');
    //
    // function sortChildren(a,b) {
    //     let aChildren = $(a).children();
    //     let bChildren = $(b).children();
    //     if(aChildren == undefined && bChildren == undefined){
    //         return 0;
    //     }
    //     if(aChildren == undefined && bChildren != undefined){
    //         return -1;
    //     }
    //     if(aChildren != undefined && bChildren == undefined){
    //         return 1;
    //     }
    //     return bChildren.length - aChildren.length;
    // }
}