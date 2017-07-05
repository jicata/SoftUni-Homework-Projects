/*jshint esversion: 6 */
function trackEm() {
    return {
        selector: undefined,
        id: 0,
        bugs: new Map,
        report: function (author, description, reproducible, severity) {
            let newBug = {
                ID: this.id++,
                author: author,
                description: description,
                reproducible: reproducible,
                severity: severity,
                status: 'Open'
            };
            this.bugs.set(newBug.ID, newBug);
            this.output(this.selector);
        },
        setStatus: function (id, newStatus) {
            let bug = this.bugs.get(id);
            bug.status = newStatus;
            this.bugs.set(id, bug);
            this.output(this.selector);
        },
        remove: function (id) {
            this.bugs.delete(id);
            this.output(this.selector);
        },
        sort: function (sortingParam) {
            let kur = [...this.bugs.entries()];
            kur.sort(function (a, b) {
                let sortingResult = 0;
                if(sortingParam == 'author'){
                    sortingResult = a[1][sortingParam].localeCompare(b[1][sortingParam]);
                }
                else{
                    sortingResult = a[1][sortingParam] - b[1][sortingParam];
                }
                if (sortingResult != 0) {
                    return sortingResult
                }
                return a[0] - b[0];
            });
            for(let [key,value] of kur){
                this.bugs.delete(key);
            }
            this.bugs = new Map(kur);
            this.output(this.selector);

        },
        output: function (selector) {
            $(selector).empty();
            this.selector = selector;
            for (let [id, bug] of this.bugs) {
                $(`<div id="report_${id}" class="report"></div>`)
                    .append($(`<div class="body"></div>`)
                        .append($(`<p>${bug.description}</p>`)))
                    .append($(`<div class="title"></div>`)
                        .append($(`<span class="author">Submitted by: ${bug.author}</span>`))
                        .append($(`<span class="status">${bug.status} | ${bug.severity}</span>`)))
                    .appendTo($(selector));
            }
        }
    }
}
