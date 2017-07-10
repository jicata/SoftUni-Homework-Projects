/*jshint esversion: 6 */
let mathEnforcer = {
    addFive: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};
let expect = require('chai').expect;
describe('mathEnforcer',()=>{
    "use strict";
    describe('addFive',()=>{
        it('should return undefined if passed a string',()=>{
            expect(mathEnforcer.addFive('9')).to.be.undefined;
        });
        it('should return undefined if passed an array',()=>{
            expect(mathEnforcer.addFive([])).to.be.undefined;
        });
        it('should return 14.1 if passed a float',()=>{
            expect(mathEnforcer.addFive(9.1)).closeTo(14,14.5,15);
        });
        it(`should return 0 if passed negative 5`,()=>{
            expect(mathEnforcer.addFive(-5)).to.equal(0);
        })
    });
    describe('subtractTen',()=>{
        it('should return undefined if passed a string',()=>{
            expect(mathEnforcer.subtractTen('9')).to.be.undefined;
        })
        it('should return undefined if passed an array',()=>{
            expect(mathEnforcer.subtractTen([])).to.be.undefined;
        })
        it('should return -1 ~ if passed a float',()=>{
            expect(mathEnforcer.subtractTen(10.1)).closeTo(0,1);
        })
        it(`should return -15 if passed negative 5`,()=>{
            expect(mathEnforcer.subtractTen(-5)).to.equal(-15);
        })
    })
    describe('sum',()=>{
        it('should return undefined if passed a string',()=>{
            expect(mathEnforcer.sum('9',[])).to.be.undefined;
        })
        it('should return undefined if passed an array',()=>{
            expect(mathEnforcer.sum([],9)).to.be.undefined;
        })
        it('should return 2 if passed 1 and 1',()=>{
            expect(mathEnforcer.sum(1,1)).closeTo(2,1);
        })
        it('should return close to 10 if passed 5.5 and 4.3',()=>{
            expect(mathEnforcer.sum(5.5,4.3)).closeTo(9,10);
        })
        it(`should return -15 if passed negative 5 and negative 10`,()=>{
            expect(mathEnforcer.sum(-5, -10)).to.equal(-15);
        })
    })
});