const numberOperations = require('./numberOperations');
const {expect, assert} = require('chai');

describe("Tests for numberOperations", () => {
    describe("Tests for powNumber", () =>{
        it("Should return correct result", () => {
            expect(numberOperations.powNumber(3)).to.equal(9);
            expect(numberOperations.powNumber(1)).to.equal(1);
        });
     });
    describe("Tests for numberChecker", () =>{
        it("Should throw if input is NaN", () => {
            expect(() => numberOperations.numberChecker('k' / 2)).to.throw();
        });
        it("Should pass if input is number", () => {
            expect(() => numberOperations.numberChecker(2)).to.not.throw();
            expect(() => numberOperations.numberChecker(-2)).to.not.throw();
            expect(() => numberOperations.numberChecker(0)).to.not.throw();
            expect(() => numberOperations.numberChecker(0.2)).to.not.throw();
            expect(() => numberOperations.numberChecker(-0.2)).to.not.throw();
        });
        it("Should return correct message when the number < 100", () => {
            let expected = 'The number is lower than 100!';
            expect(numberOperations.numberChecker(2)).to.equal(expected);
            expect(numberOperations.numberChecker(-2)).to.equal(expected);
            expect(numberOperations.numberChecker(0)).to.equal(expected);
            expect(numberOperations.numberChecker(0.2)).to.equal(expected);
            expect(numberOperations.numberChecker(-0.2)).to.equal(expected);
        });
        it("Should return correct message when the number >= 100", () => {
            let expected = 'The number is greater or equal to 100!';
            expect(numberOperations.numberChecker(100)).to.equal(expected);
            expect(numberOperations.numberChecker(1500)).to.equal(expected);
            expect(numberOperations.numberChecker(200.56)).to.equal(expected);
        });
     });
     describe("Tests for sumArrays", () =>{
        let arr1 = [1,2,3,4,5];
        let arr2 = [1,2,3];

        it("Should return correct arrray when the first array is longer", () => {
            expect(numberOperations.sumArrays(arr1, arr2)).to.eql([2, 4, 6, 4, 5]);
            expect(numberOperations.sumArrays(arr2, arr1)).to.eql([2, 4, 6, 4, 5]);
        });
        it("Should return correct arrray when the second array is longer", () => {
            expect(numberOperations.sumArrays(arr1, arr2)).to.eql([2, 4, 6, 4, 5]);
            expect(numberOperations.sumArrays(arr2, arr1)).to.eql([2, 4, 6, 4, 5]);
        });
        it("Should return correct arrray when both have same length", () => {
            expect(numberOperations.sumArrays(arr1, arr1)).to.eql([2, 4, 6, 8, 10]);
        });
     });
});
