/*jshint esversion: 6 */
function lowestPriceInCity(input) {
    let productsByCities = new Map();
    let products = new Map();
    for(let i = 0; i < input.length;i++){
        let inputDetails = input[i].split("|");
        let city = inputDetails[0];
        let product = inputDetails[1];
        products.set(product,`${Number.POSITIVE_INFINITY} ("")`);
        let price = Number(inputDetails[2]);

        if(!productsByCities.has(city)){
            let productsPrice = new Map();
            productsPrice.set(product,price);
            productsByCities.set(city,productsPrice);
        }
        else {
            productsByCities.get(city).set(product, price);
        }
    }
    for(let [city,product] of productsByCities){
        for(let [productName,price] of product){
            let priceSoFar = Number(products.get(productName).split(' ')[0]);
            if(priceSoFar > price){
                priceSoFar = price;
                products.set(productName,`${price} (${city.trim()})`);
            }
        }
    }
    products.forEach((k,v)=>console.log(`${v.trim()} -> ${k.replace(",","").trim()}`));

}
// lowestPriceInCity(["Sample Town | Sample Product | 1000", "Sample Town | Orange | 2", "Sample Town | Peach | 1",
// "Sofia | Orange | 3","Sofia | Peach | 2","New York | Sample Product | 1000.1","New York | Burger | 10"]);