import { Component, OnInit } from '@angular/core'
import { IProduct } from './product';
import { ProductService } from './product.service';

@Component({
    selector: 'pm-products',
    templateUrl: './product-list.component.html',
    styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {   
    pageTitle: string = 'Product List';
    imageWidth: number = 50;
    imageMargin: number = 2;
    displayImages: boolean = false;
    _listFilter: string;
    errorMessage:string;

    get listFilter(): string {
        return this._listFilter
    }
    set listFilter(value: string) {
        this._listFilter = value;
        this.filteredProducts = this._listFilter
            ? this.filterProducts(this._listFilter)
            : this.products;
    }

    filteredProducts: IProduct[];
    products: IProduct[];

    constructor(private productService: ProductService) {

    }

    ngOnInit(): void {
        this.productService.getProducts()
            .subscribe(data=>{
                this.products = data
                this.filteredProducts = this.products;
            },
            error=>this.errorMessage = error);
        
    }

    toggleImage(): void {
        this.displayImages = !this.displayImages
    }

    filterProducts(filter: string): IProduct[] {
        filter = filter.toLocaleLowerCase();
        return this.filteredProducts
            .filter(product => product.productName.toLocaleLowerCase()
                .indexOf(filter) !== -1);
    }
    onRatingClicked(message: string): void{
        this.pageTitle = ' Product list: ' + message;
    }
}