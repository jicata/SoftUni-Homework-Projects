/*jshint esversion: 6 */

class StringBuilder {
    constructor(string) {
        if (string !== undefined) {
            StringBuilder._vrfyParam(string);
            this._stringArray = Array.from(string);
        } else {
            this._stringArray = [];
        }
    }

    append(string) {
        StringBuilder._vrfyParam(string);
        for(let i = 0; i < string.length; i++) {
            this._stringArray.push(string[i]);
        }
    }

    prepend(string) {
        StringBuilder._vrfyParam(string);
        for(let i = string.length - 1; i >= 0; i--) {
            this._stringArray.unshift(string[i]);
        }
    }

    insertAt(string, startIndex) {
        StringBuilder._vrfyParam(string);
        this._stringArray.splice(startIndex, 0, ...string);
    }

    remove(startIndex, length) {
        this._stringArray.splice(startIndex, length);
    }

    static _vrfyParam(param) {
        if (typeof param !== 'string') throw new TypeError('Argument must be string');
    }

    toString() {
        return this._stringArray.join('');
    }
}


let expect = require('chai').expect;

describe('StringBuilder', () => {
    "use strict";
    let builder;
    beforeEach(function() {
        builder = new StringBuilder();
    });

    //has stuff

    it('has all properties', function () {
        expect(builder.hasOwnProperty('_stringArray')).to.equal(true, "Missing data property");
    });

    it('has functions attached to prototype', function () {
        expect(Object.getPrototypeOf(builder).hasOwnProperty('append')).to.equal(true, "Missing add function");
        expect(Object.getPrototypeOf(builder).hasOwnProperty('prepend')).to.equal(true, "Missing sumNums function");
        expect(Object.getPrototypeOf(builder).hasOwnProperty('insertAt')).to.equal(true, "Missing removeByFilter function");
        expect(Object.getPrototypeOf(builder).hasOwnProperty('remove')).to.equal(true, "Missing toString function");
        expect(Object.getPrototypeOf(builder).hasOwnProperty('toString')).to.equal(true, "Missing toString function");
       // expect(Object.getPrototypeOf(builder).hasOwnProperty('_vrfyParam')).to.equal(true, "Missing toString function");
        expect(typeof StringBuilder._vrfyParam).to.equal('function');
    });

    it('should be an object of type StringBuilder',()=>{
        expect(builder instanceof StringBuilder).to.equal(true);
    });

    it('array should be own properta', ()=>{
        expect(builder.hasOwnProperty('_stringArray')).to.equal(true);
    })

    //remove

    it(`remove with switched indeces should do nothing`,()=>{
        builder = new StringBuilder('mnogo_text');
        builder.remove(10,3);
        expect(builder._stringArray.join('')).to.equal('mnogo_text');
    })

    it('remove with negative index should return unchanged string',()=>{
        builder = new StringBuilder('mnogo_text');
        builder.remove(4,-1);
        expect(builder._stringArray.join('')).to.equal('mnogo_text');
    })

    it('remove from start to end should return empty string',()=>{
        builder = new StringBuilder('mnogo_text');
        builder.remove(0,builder._stringArray.length);
        expect(builder._stringArray.join('')).to.equal('');
    });

    it('inner array length should decrease when removing elements',()=>{
        builder = new StringBuilder('kur');
        expect(builder._stringArray.length).to.equal(3);
        builder.remove(0,3);
        expect(builder._stringArray.length).to.equal(0);
    })

    it('remove with out of range length should remove to the end',()=>{
        builder = new StringBuilder('klesqsal');
        builder.remove(4,123098);
        expect(builder._stringArray.join('')).to.equal('kles');
    })

    it('remove with valid length should remove correctly',()=>{
            builder = new StringBuilder('klesqsal');
            builder.remove(4,4);
            expect(builder._stringArray.join('')).to.equal('kles');
    })

    it('remove on empty builder should return empty builder',()=>{
        builder.remove(5,5);
        expect(builder._stringArray.join('')).to.equal('');
    })

    //insert at

    it('insertAt with non-string should throw',()=>{
        let firstArgument = 5;
        expect(()=> builder.insertAt(firstArgument,0)).to.throw(TypeError, /Argument must be string/);
    })

    it('insert at 0 index should insert with no previous string should create new array',()=>{
        builder.insertAt('orabapotava',1);
        expect(builder._stringArray.join('')).to.equal('orabapotava');
    })

    it('insert at index should insert string at given index',()=>{
        builder = new StringBuilder('kur');
        builder.insertAt('orabapotava',1);
        expect(builder._stringArray.join('')).to.equal('korabapotavaur');
    })

    it(`insert at non-existing location should leave unchanged`,()=>{
        builder.insertAt('',-500);
        expect(builder._stringArray.join('')).to.equal('');
    })

    //prepend

    it('prepend should throw if non string is passed',()=>{
        let firstArgument = 'kur';
        let secondArgument = 5;
        builder.append(firstArgument);
        expect(builder._stringArray.join('')).to.equal(firstArgument);
        expect(()=> builder.append(secondArgument)).to.throw(TypeError, /Argument must be string/);
    });

    it('prepend should add string at the start of the array',()=>{
        let firstArgument = 'kur';
        let secondArgument = 'sliva';
        builder.prepend(firstArgument);
        expect(builder._stringArray.join('')).to.equal(firstArgument);
        builder.prepend(secondArgument);
        expect(builder._stringArray.join('')).to.equal(secondArgument+firstArgument);
    })

    it('prepend should do nothing when empty string is paased', ()=>{
        builder.prepend('');
        expect(builder._stringArray.length).to.equal(0);
    })

    // append

    it('append should throw if non string is passed',()=>{
        let firstArgument = 'kur';
        let secondArgument = 5;
        builder.append(firstArgument);
        expect(builder._stringArray.join('')).to.equal(firstArgument);
        expect(()=> builder.append(secondArgument)).to.throw(TypeError, /Argument must be string/);
    })

    it('append should add string at the end of the array',()=>{
        let firstArgument = 'kur';
        let secondArgument = 'sliva';
        builder.append(firstArgument);
        expect(builder._stringArray.join('')).to.equal(firstArgument);
        builder.append(secondArgument);
        expect(builder._stringArray.join('')).to.equal(firstArgument+secondArgument);
        expect(builder._stringArray.join('')).to.equal(builder.toString());
    });

    // initializing

    it('should throw if initialized with number',()=>{
        expect(() => builder = new StringBuilder(5)).to.throw(TypeError, /Argument must be string/);
    });

    it('initializing object with kur should make inner array 3 chars long',()=>{
        builder = new StringBuilder('kur');
        expect(builder._stringArray.length).to.equal(3);
    })

    it('inner array length should increase with adding elements',()=>{
        builder = new StringBuilder('kur');
        expect(builder._stringArray.length).to.equal(3);
        builder.append('ata');
        expect(builder._stringArray.length).to.equal(6);
        builder.insertAt('v',3);
        expect(builder._stringArray.length).to.equal(7);
    })

    it('initialized with new should return object',()=>{
        expect(builder).to.not.be.equal(undefined);
    });

    it('initialized should contain _stringArray property',()=>{
        expect(builder._stringArray).to.not.be.equal(undefined);
    });

    it('initialized with no arguments should have empty array',()=>{
        expect(builder._stringArray.length).to.equal(0);
        expect(Array.isArray(builder._stringArray)).to.equal(true);
    });

    it('initialized with no arguments, toString should return empty string',()=>{
        expect(builder._stringArray.join('')).to.equal('');
    });

    it('initialized with empty string, toString should return empty string',()=>{
        expect(builder.toString()).to.equal('');
    });

    it('initialized with regular string, toString should return same string',()=>{
        let builder = new StringBuilder('kur we');
        expect(builder.toString()).to.equal('kur we');
    })

    it('toString should return all elements joined by empty string',()=>{
        let arg1 = 'ebasi';
        let arg2 = 'tiq testowe';
        let arg3 = 'SA BRUTALNI';
        builder.append(arg1);
        builder.prepend(arg2);
        builder.insertAt(arg3,4);
        let joinedArray  = builder._stringArray.join('');
        expect(builder.toString()).to.equal(joinedArray);
    })
});