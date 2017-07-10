/*jshint esversion: 6 */
function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}

let expect = require('chai').expect;
describe('lookUpChar',()=>{
    "use strict";
    it('should return undefined with passed object',()=>{
        expect(lookupChar({kur:'kur'},1)).to.be.undefined;
    })
    it('should return undefined with passed array',()=>{
        expect(lookupChar([],1)).to.be.undefined;
    })
    it('should return undefined with float',()=>{
        expect(lookupChar('ruk',1.1)).to.be.undefined;
    })
    it('should return undefined with string as index',()=>{
        expect(lookupChar('ruk','1')).to.be.undefined;
    })
    it('should return incorrect index with neagtive index',()=>{
        expect(lookupChar('ruk',-1)).to.equal('Incorrect index');
    })
    it('should return incorrect index with too big index',()=>{
        expect(lookupChar('ruk',4)).to.equal('Incorrect index');
    })
    it('should return correct char with proper parameters',()=>{
        expect(lookupChar('ruk',1)).to.equal('u');
    })
    it('should return correct char with proper parameters',()=>{
        expect(lookupChar('ruk',2)).to.equal('k');
    })
    it('should return correct char with proper parameters',()=>{
        expect(lookupChar('rukk',3)).to.equal('k');
    })
})
