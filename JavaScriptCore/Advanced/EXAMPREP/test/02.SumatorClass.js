/*jshint esversion: 6 */
class Sumator {
    constructor() {
        this.data = [];
    }

    add(item) {
        this.data.push(item);
    }

    sumNums() {
        let sum = 0;
        for (let item of this.data)
            if (typeof (item) === 'number')
                sum += item;
        return sum;
    }

    removeByFilter(filterFunc) {
        this.data = this.data.filter(x => !filterFunc(x));
    }

    toString() {
        if (this.data.length > 0)
            return this.data.join(", ");
        else
            return '(empty)';
    }
}

let expect = require('chai').expect;
let assert = require('chai').assert;

describe('Sumator', () => {
    "use strict";
    let sumator = new Sumator();

    it('should be an objet of type Sumator',()=>{
        expect(sumator instanceof Sumator).to.equal(true);
    })

    it('should return empty array with no elements', () => {
        expect(sumator.data.length).to.equal(0);
    });

    it('should return empty message on empty data', () => {
        expect(sumator.toString()).to.equal('(empty)');
    });

    it('should have two elements after two add ops', () => {
        sumator.add('kur');
        sumator.add('kur be');
        expect(sumator.data.length).to.equal(2);
    })

    it('toString with two elements should return proper string', () => {
        sumator = new Sumator();
        sumator.add('kur');
        sumator.add('kur be');
        expect(sumator.toString()).to.equal('kur, kur be');
    })

    it('sum with no data should return 0',()=>{
        sumator = new Sumator();
       expect(sumator.sumNums()).to.equal(0);
    });

    it('sum with only string data should return 0',()=>{
        sumator = new Sumator();
        sumator.add('kur');
        sumator.add('kur be');
        expect(sumator.sumNums()).to.equal(0);
    });

    it('sum with 5 and 3 should return 8',()=>{
        sumator = new Sumator();
        sumator.add(5);
        sumator.add(3);
        expect(sumator.sumNums()).to.equal(8);
    });

    it('removeByFilter should remove every non string',()=>{
        sumator = new Sumator();
        sumator.add(5);
        sumator.add('kur');
        sumator.add('kur be');
        sumator.add(3);

        sumator.removeByFilter((x) => typeof x !== 'number');
        expect(sumator.data.length).to.equal(2);
        expect(sumator.sumNums()).to.equal(8);
        expect(typeof sumator.data[1]).to.equal('number');
    })

    it('removeByFilter should throw with bad function',()=>{
        sumator = new Sumator();
        sumator.add(5);
        sumator.add('kur');
        sumator.add('kur be');
        sumator.add(3);

        assert.throws(sumator.removeByFilter(x=>Number(x)*2));

    })
})