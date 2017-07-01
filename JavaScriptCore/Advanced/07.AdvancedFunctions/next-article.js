/*jshint esversion: 6 */
function getArticleGenerator(articles) {
    let itemsToAttach = articles;
    return function () {
        if (itemsToAttach.length > 0) {
            let text = itemsToAttach.shift();
            let article = $(`<article>`);
            article.append($(`<p>${text}</p>`));
            $(`#content`).append(article);
        }
    };
}
