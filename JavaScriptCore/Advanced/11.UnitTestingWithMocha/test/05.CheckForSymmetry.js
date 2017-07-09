/*jshint esversion: 6 */
function isSymmetric(arr) {
    if (!Array.isArray(arr))
        return false; // Non-arrays are non-symmetric
    let reversed = arr.slice(0).reverse(); // Clone and reverse
    let equal = (JSON.stringify(arr) == JSON.stringify(reversed));
    return equal;
}
let expect = require('chai').expect;

describe("Testing \"isSymmetric\"", function () {
    it('Should return false if non-array is provided',function () {
        expect(isSymmetric(1,2,3,2,1)).to.equal(false,"Object is not a an array!");
    });
    it('Should return false for non symmetric array',()=>{
        "use strict";
        expect(isSymmetric([1,2])).to.be.false;
    })
    it('Should return true for symmetric array',function () {
        expect(isSymmetric([1,2,2,1])).to.equal(true,"Symmetry not evaluated properly fr symmetric array")
    });
    it('Should return false for non-symmetric array',function () {
        expect(isSymmetric([1,1,3,4])).to.equal(false,'Symmetry not evaluated properly for non-symmetric array')
    });
    it('Should return true for empty array', function () {
        expect(isSymmetric([])).to.equal(true,'Empty array should be symmetric');
    });
    it('Should return true for symmetric array of different types',()=>{
        "use strict";
        expect(isSymmetric([1,"kur",'a','a',"kur",1])).to.equal(true, 'Symmetric array of different types not properly evaluated')
    });
    it('Should return true for [1]',()=>{
        "use strict";
        expect(isSymmetric([1])).to.equal(true,'Symmetry not properly evaluated for single element array')
    });
    it('Should be symmetric for uneven amount of elements',()=>{
        "use strict";
        expect(isSymmetric([1,2,3,2,1])).to.be.true;
    })
    it('Should return false for different types', ()=>{
        "use strict";
        expect(isSymmetric('1',2,3,3,2,1)).to.be.false;
    })
});