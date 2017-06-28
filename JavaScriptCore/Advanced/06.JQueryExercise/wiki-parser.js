/*jshint esversion: 6 */
function wikiParser(elementId) {
    let textForParsing = $(elementId).text().split('\n').map(function (a) {
        return a.trim();
    }).filter(String);
    console.log(textForParsing);
    let italicsPattern = /(?:''([a-zA-Z0-9\s]+)'')/g
    let strongPattern = /(?:'''([a-zA-Z0-9\s]+)''')/g
    let headingOnePattern = /(?:=([a-zA-Z0-9\s]+)=)/g;
    let headingTwoPattern = /(?:==([a-zA-Z0-9\s]+)==)/g;
    let headingThreePattern = /(?:===([a-zA-Z0-9\s]+)===)/g;
    let simpleLinkPattern = /(?:\[\[([a-zA-Z0-9\s]+)\]\])/g;
    let linkWithTextPattern = /(?:\[\[([a-zA-Z0-9\s]+)\|([a-zA-Z0-9\s]+)\]\])/g;

    for (let i = 0; i < textForParsing.length; i++) {
        let result = textForParsing[i]
            .replace(strongPattern, (match, grp1) => `<b>${grp1}</b>`)
            .replace(italicsPattern, (match, grp1) => `<i>${grp1}</i>`)
            .replace(headingThreePattern, (match, grp1) => `<h3>${grp1}</h3>`)
            .replace(headingTwoPattern, (match, grp1) => `<h2>${grp1}</h2>`)
            .replace(headingOnePattern, (match, grp1) => `<h1>${grp1}</h1>`)
            .replace(linkWithTextPattern, (match, grp1,grp2) => `<a href="/wiki/${grp1}">${grp2}</a>`)
            .replace(simpleLinkPattern, (match, grp1) => `<a href="/wiki/${grp1}">${grp1}</a>`);
        $(elementId).append(result);
    }
}