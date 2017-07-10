/*jshint esversion: 6 */
let sharedObject = {
    name: null,
    income: null,
    changeName: function (name) {
        if (name.length === 0) {
            return;
        }
        this.name = name;
        let newName = $('#name');
        newName.val(this.name);
    },
    changeIncome: function (income) {
        if (!Number.isInteger(income) || income <= 0) {
            return;
        }
        this.income = income;
        let newIncome = $('#income');
        newIncome.val(this.income);
    },
    updateName: function () {
        let newName = $('#name').val();
        if (newName.length === 0) {
            return;
        }
        this.name = newName;
    },
    updateIncome: function () {
        let newIncome = $('#income').val();
        if (isNaN(newIncome) || !Number.isInteger(Number(newIncome)) || Number(newIncome) <= 0) {
            return;
        }
        this.income = Number(newIncome);
    }
};
let expect = require('chai').expect;
//let jquery = require(`jQuery`);

describe('sharedObject', () => {
    "use strict";
    describe('changeName', () => {
        it('Name should stay null upon first time passing an empty string',()=>{
            sharedObject.changeName('');
            expect(sharedObject.name).to.be.null;
        });
        it('Name should stay null after passing a non-string',()=>{
            sharedObject.changeName([]);
            expect(sharedObject.name).to.be.null;
        });
        it('Name should stay not change after passing an empty string',()=>{
            sharedObject.changeName('Pesho');
            sharedObject.changeName('');
            expect(sharedObject.name).to.equal('Pesho');
        });
        it('Name should stay not change after passing an empty string',()=>{
            sharedObject.changeName('Pesho');
            sharedObject.changeName('');
            expect(sharedObject.name).to.equal('Pesho');
        })
    })
    describe('changeIncome',()=>{
        it('Income should stay null after passing 0',()=>{
            sharedObject.changeIncome(0);
            expect(sharedObject.income).to.be.null;
        })
        it('Income should stay null after passing less than 0',()=>{
            sharedObject.changeIncome(-1);
            expect(sharedObject.income).to.be.null;
        })
        it('Income should be 5 after passing 5',()=>{
            sharedObject.changeIncome(5)
            expect(sharedObject.income).to.equal(5);
        })
    })
})