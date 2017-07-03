/*jshint esversion: 6 */
(function extenstions() {
    Array.prototype.last = function () {
        return this[this.length - 1]
    };
    Array.prototype.skip = function (n) {
        return this.slice(n)
    };
    Array.prototype.take = function (n) {
        return this.slice(0, n)
    };
    Array.prototype.sum = function () {
        "use strict";
        let result = 0;
        for (let i = 0; i < this.length; i++) {
            result += this[i];
        }
        return result;
    };
    Array.prototype.average = function () {
        "use strict";
        let totalSum = this.sum();
        return totalSum / this.length;
    }
})()
// let testArr = [1, 2, 3];
// console.log(testArr.skip(1));