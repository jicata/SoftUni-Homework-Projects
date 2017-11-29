import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl, ValidatorFn } from '@angular/forms';

import { Customer } from './customer';


function ratingRange(min: number, max: number): ValidatorFn {
    return (c: AbstractControl): { [key: string]: boolean } | null => {
        if (c.value != undefined && (isNaN(c.value) || c.value < min || c.value > max)) {
            return { 'range': true };
        }
        return null;
    }
}

function emailMatcher(c:AbstractControl){
    let emailControl = c.get('email');
    let emailConfirmControl = c.get('confirmEmail');
    if(emailControl.pristine || emailConfirmControl.pristine){
        return null;
    }
    if(emailControl.value === emailConfirmControl.value){
        return null;
    }
    return {'match': true};
}


@Component({
    selector: 'my-signup',
    templateUrl: './app/customers/customer.component.html'
})
export class CustomerComponent implements OnInit {
    customerForm: FormGroup;
    customer: Customer = new Customer();

    constructor(private fb: FormBuilder) {

    }

    ngOnInit(): void {
        this.customerForm = this.fb.group({
            firstName: ['', [Validators.required, Validators.minLength(3)]],
            lastName: ['', [Validators.required, Validators.maxLength(50)]],
            emailGroup: this.fb.group({
                email: ['', [Validators.required, Validators.pattern("[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+")]],
                confirmEmail: ['', Validators.required],
            },{validator:emailMatcher}),  
            phone: '',
            notification: 'email',
            rating: ['', ratingRange(1,5)],
            sendCatalog: (true)
        });

        this.customerForm.get('notification').valueChanges
            .subscribe(value=>this.setNotification(value));
    }

    populateTestData(): void {
        this.customerForm.setValue({
            firstName: 'kurvi',
            lastName: 'belo',
            email: 'kurvi@belo.com',
            sendCatalog: true
        })
    }

    save() {
        console.log(this.customerForm);
        console.log('Saved: ' + JSON.stringify(this.customerForm.value));
    }

    setNotification(notifyVia: string): void {
        const phoneControl = this.customerForm.get('phone');
        switch (notifyVia) {
            case 'text':
                phoneControl.setValidators(Validators.required);
                break;
            default:
                phoneControl.clearValidators();
        }
        phoneControl.updateValueAndValidity();
    }
}
