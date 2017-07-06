/*jshint esversion: 6 */
function sum(arr) {
    let sum = 0;
    for (num of arr)
        sum += Number(num);
    return sum;
}

let expect = require('chai').expect;

describe("Testing for the very first time with Mocha in particular", function () {
    it('with real numbers should return sum',function () {
        expect(sum([1,2])).to.equal(3,"1+2 != 3");
    });

    it('with real numbers should return sum',function () {
        expect(sum([1,2])).to.equal(3,"1+2 != 3");
    });
    it('with real numbers should return sum',function () {
        expect(sum([1,2])).to.equal(3,"1+2 != 3");
    })
});