/*jshint esversion: 6 */
function createCalculator() {
    let value = 0;
    return {
        add: function(num) { value += Number(num); },
        subtract: function(num) { value -= Number(num); },
        get: function() { return value; }
    }
}

let expect = require('chai').expect;

describe("Testing \"createCalculator\"", function () {
    it('Should increment value upon add with number',function () {
        let calculator = createCalculator();
        calculator.add(5);
        expect(calculator.get()).to.equal(5);
    });
    it('Should increment value upon add with string',function () {
        let calculator = createCalculator();
        calculator.add('5');
        expect(calculator.get()).to.equal(5);
    });
    it('Should decrement upon subtract with number',function () {
        let calculator = createCalculator();
        calculator.subtract(5);
        expect(calculator.get()).to.equal(-5);
    });
    it('Should increment value upon add with string',function () {
        let calculator = createCalculator();
        calculator.subtract('5');
        expect(calculator.get()).to.equal(-5);
    });
    it('Attempt to modify internal value should not change it',function () {
        let calculator = createCalculator();
        calculator.value = 5;
        expect(calculator.get()).to.equal(0);
    });

});