const testNumbers = require('./testNumbers');
const {expect, assert} = require('chai');

describe("Tests for testNumbers", () => {
    describe("Tests for sumNumbers function", () =>{
        it("Should return correct result when correct positive input", () => {
            expect(testNumbers.sumNumbers(1, 2)).to.equal('3.00');
            expect(testNumbers.sumNumbers(1.56, 2)).to.equal('3.56');
            expect(testNumbers.sumNumbers(1.56, 2.30)).to.equal('3.86');
        });
        it("Should return correct result when correct positive + negative input", () => {
            expect(testNumbers.sumNumbers(-1, -2)).to.equal('-3.00');
            expect(testNumbers.sumNumbers(1, -2)).to.equal('-1.00');
            expect(testNumbers.sumNumbers(-1.56, 2)).to.equal('0.44');
            expect(testNumbers.sumNumbers(-1.56, -2.30)).to.equal('-3.86');
        });
        it("Should return undefined  when one ore both args are not Number", () => {
            expect(testNumbers.sumNumbers('A', -2)).to.equal(undefined);
            expect(testNumbers.sumNumbers('false', 'true')).to.equal(undefined);
            expect(testNumbers.sumNumbers(2, 'notnum')).to.equal(undefined);
            expect(testNumbers.sumNumbers({name:'name'}, 5)).to.equal(undefined);
        });
     });
    describe("Tests for numberChecker function", () =>{
        it("Should throw when NaN is passed", () => {
            expect(()=> testNumbers.numberChecker( 'h')).to.throw();
            expect(()=> testNumbers.numberChecker( 'h'/2)).to.throw();
            expect(()=> testNumbers.numberChecker( {})).to.throw();
        });
        it("Should return correct result for even and odd numbers", () => {
            expect(testNumbers.numberChecker(2)).to.equal('The number is even!');
            expect(testNumbers.numberChecker(-2)).to.equal('The number is even!');
            expect(testNumbers.numberChecker(0)).to.equal('The number is even!');
            expect(testNumbers.numberChecker(1)).to.equal( 'The number is odd!');
            expect(testNumbers.numberChecker(-101)).to.equal( 'The number is odd!');
        });
    });
    describe("Tests for averageSumArray function", () =>{
        it("Should return correct result when correct array is passed", () => {
            expect(testNumbers.averageSumArray([1, 2, 3])).to.equal(2);
            expect(testNumbers.averageSumArray([-1, 7, -3])).to.equal(1);
            expect(testNumbers.averageSumArray([1, -7, 3])).to.equal(-1);
            expect(testNumbers.averageSumArray([1.5, 2, -3.5])).to.equal(0);
            expect(testNumbers.averageSumArray([1.5, 8, -3.5])).to.equal(2);
            expect(testNumbers.averageSumArray([-1, 8])).to.equal(3.5);
        });
    });
});
