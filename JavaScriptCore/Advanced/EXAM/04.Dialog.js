/*jshint esversion: 6 */
class Dialog {
    constructor(message, callback) {
        this.message = message;
        this.callback = callback;
        this.boxHtml = this.createBox();
    }

    addInput(label, name, type) {
        this.label = label;
        this.name = name;
        this.type = type;

        let button = this.boxHtml.find('button')[0];
        let labelElement = $(`<label>${label}</label>`);
        let input = ($(`<input name="${name}" type="${type}">`));
        labelElement.insertBefore(button);
        input.insertBefore(button);


    }

    createBox() {
        return $(`<div class="overlay">`)
            .append($(`<div class="dialog">`)
                .append($(`<p>${this.message}</p>`))
                .append($(`<button>OK</button>`).click(this.doMagic.bind(this, this.callback)))
                .append($(`<button>Cancel</button>`).click(this.removeFromDom)));
    }

    doMagic(callback,e) {
        let inputs = $(e.target).parent().parent().find(`input`).toArray().map(e => e);
        let returnObject ={};
        for(let input of inputs){
            returnObject[input.name] = input.value;
        }
        callback(returnObject)
        let maikataNaMaikataNaMaikata = $(e.target).parent().parent();
        maikataNaMaikataNaMaikata.remove();

    }

    removeFromDom(e) {
        let maikataNaMaikataNaMaikata = $(e.target).parent().parent();
        maikataNaMaikataNaMaikata.remove();
    }

    render() {
        $("body").append($(this.boxHtml));

    }

}