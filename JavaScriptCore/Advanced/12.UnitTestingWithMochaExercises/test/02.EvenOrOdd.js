/*jshint esversion: 6 */
function isOddOrEven(string) {
    if (typeof(string) !== 'string') {
        return undefined;
    }
    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}

let expect = require('chai').expect;

describe('IsEvenOrOdd',()=>{
    "use strict";
    it('should return undefined with passed object',()=>{
        expect(isOddOrEven({kur:'kur'})).to.be.undefined;
    })

    it('should return undefined with passed array',()=>{
        expect(isOddOrEven([1])).to.be.undefined;
    })

    it('should return undefined with passed number',()=>{
        expect(isOddOrEven(38)).to.be.undefined;
    })
    it('should return odd with passed string with odd lenght',()=>{
        expect(isOddOrEven('maluk')).to.equal('odd');
    })
    it('should return odd with passed odd string',()=>{
        expect(isOddOrEven('382')).to.equal('odd');
    })
    it('should return evn with passed even string',()=>{
        expect(isOddOrEven('3822')).to.equal('even');
    })
    it('should return evn with passed even string',()=>{
        expect(isOddOrEven('chep')).to.equal('even');
    })
    it('should return evn with passed even string',()=>{
        expect(isOddOrEven('ala bala portokala')).to.equal('even');
    })
    it('should return evn with passed empty string',()=>{
        expect(isOddOrEven('')).to.equal('even');
    })
})