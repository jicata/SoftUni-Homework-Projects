/*jshint esversion: 6 */
function rgbToHexColor(red, green, blue) {
    if (!Number.isInteger(red) || (red < 0) || (red > 255))
        return undefined; // Red value is invalid
    if (!Number.isInteger(green) || (green < 0) || (green > 255))
        return undefined; // Green value is invalid
    if (!Number.isInteger(blue) || (blue < 0) || (blue > 255))
        return undefined; // Blue value is invalid
    return "#" +
        ("0" + red.toString(16).toUpperCase()).slice(-2) +
        ("0" + green.toString(16).toUpperCase()).slice(-2) +
        ("0" + blue.toString(16).toUpperCase()).slice(-2);
}

let expect = require('chai').expect;

describe("Testing \"RGBtoHex\"", function () {
    it('Should return undefined if invalid vlaue is provided',function () {
        expect(rgbToHexColor(-1,200,200)).to.be.undefined
    });
    it('Should return #FF1493 for (255,20,147)',()=>{
        "use strict";
        expect(rgbToHexColor(255,20,147)).to.equal('#FF1493','Incorrect conversion with correct values');
    })
    it('Should return undefined if argument is of incorrect type',()=>{
        "use strict";
        expect(rgbToHexColor('255','20', 147)).to.be.undefined
    })
    it('Should ret')

});