/*jshint esversion: 6 */
function sortedList() {
    let list = {
        collection: [],
        size: 0,
        sort: function () {
            this.collection = this.collection.sort(function (a, b) {
                return a - b;
            })
        },
        add: function (elemenent) {
            this.collection.push(elemenent);
            this.size++;
            this.sort();
        },
        remove: function (index) {
            if (this.size > 0 && (index >= 0 && index < this.size)) {
                this.collection.splice(index, 1);
                this.sort();
                this.size--;
            }
        },
        get: function (index) {
            if (this.size > 0 && (index >= 0 && index < this.size)) {
                return this.collection[index];
            }
        }
    };
    return list;
}
// let kur = sortedList();
// kur.add(5);
// kur.add(2);
// kur.add(6);
// kur.remove(1);
// kur.remove(1);
// kur.remove(0);
// kur.add(5);
//console.log(kur.collection);