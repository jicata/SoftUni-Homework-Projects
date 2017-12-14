import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl, ValidatorFn } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IProduct } from './product';
import { ProductService } from './product.service';

function rangeValidator(min: number, max: number): ValidatorFn {
  return (c: AbstractControl): { [key: string]: boolean } | null => {
    if (c.value && (isNaN(c.value) || c.value < min || c.value > max)) {
      return { 'range': true };
    }
    return null;
  }
}

@Component({
  selector: 'pm-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  pageTitle: string = "Create Product"
  productForm: FormGroup
  productId: string;
  errorMessages: {}

  product: IProduct;
  private validationMessages = {
    required: 'Field is required',
    range: 'Input is not in the allowed range',
    pattern: 'Please enter valid input',
    match: 'Input fields must match'
  }

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService ) {
    this.errorMessages = {};
  }

  ngOnInit() {
    this.route.params.subscribe(
      params => {
        console.log(params['id']);
      }
    )
    this.productId ='kur';
    this.productForm = this.fb.group({
      productName: ['', [Validators.required]],
      productCode: ['', [Validators.required]],
      description: [''],
      price: ['', [Validators.required, rangeValidator(0, 10000)]],
      starRating: ['', [Validators.required, rangeValidator(0, 5)]],
      imageUrl: ['', [Validators.required]],
      productId: [this.productId]
    })

    this.subscribeAllFormControlsToErrorMessage(this.productForm);
  }

  subscribeAllFormControlsToErrorMessage(form: FormGroup): void {
    for (let item in form.controls) {
      let control = form.controls[item];
      if ((control as FormGroup).controls) {
        this.subscribeAllFormControlsToErrorMessage((control as FormGroup));
      }
      control.valueChanges.debounceTime(1001).subscribe(value =>
        this.setMessage(control, item));
    }
  }

  setMessage(c: AbstractControl, name: string): void {
    this.errorMessages[name] = ''
    if ((c.touched || c.dirty) && c.errors) {
      this.errorMessages[name] = Object.keys(c.errors).map(key =>
        this.validationMessages[key]).join(' ');
    }
  }

  productSubmit(){
    //console.log(this.productForm.value);
    let formValues = this.productForm.value;
    let product = Object.assign({}, this.product, formValues);
    product.releaseDate = Date.now();
    if(product.productId){
      
    }else{
      this.productService.createProduct(product);
    }

  }
}