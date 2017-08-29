/*jshint esversion: 6 */
class Contact {
    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
        this._online = false;
        this.id = '';
    }

    get online() {
        return this._online;
    }

    set online(value) {
        this._online = value;
        if(this.id){
            let titleDiv = $(`#${this.id}`).find(`div:contains("${this.firstName} ${this.lastName}")`);

            titleDiv.toggleClass('online');
        }
    }

    render(id) {
        this.id = id;
        let divClass = 'title';
        if (this._online) {
            divClass = "title online";
        }
        $(`<article>`)
            .append($(`<div class="${divClass}">${this.firstName} ${this.lastName}</div>`)
                .append($(`<button>&#8505;</button>`).click(this.toggleInfo)))
            .append($(`<div class="info" style="display:none">`)
                .append($(`<span>&phone; ${this.phone}</span>`))
                .append($(`<span>&#9993; ${this.email}</span>`)))
            .appendTo($(`#${id}`));
    }

    toggleInfo() {
        let infoDiv = $(this).parent().next();
        if (infoDiv.attr('style')) {
            infoDiv.show();
            infoDiv.removeAttr('style');
        }
        else {
            infoDiv.hide();
            infoDiv.css('display','none');
        }
    }


}