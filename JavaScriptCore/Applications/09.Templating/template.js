$(() => {
    renderCatTemplate();
    async function renderCatTemplate() {
        let context = window.cats;
        let source = (await $.get("catTemplate.hbs"));
        let template = Handlebars.compile(source);
        let html = template({cats: context});
        $("#allCats").html(html);
        $(".btn").click(renderStatusCode)

        function renderStatusCode(e) {
            let btn = $(e.target);
            let nextElement = $(e.target).next();
            let visiblity = nextElement.css('display');
            if(visiblity == 'none'){
                nextElement.attr('style','');
                btn.text('Hide status code');
            }
            else{
                nextElement.css('display','none');
                btn.text('Show status code');
            }
        }
    }
});
