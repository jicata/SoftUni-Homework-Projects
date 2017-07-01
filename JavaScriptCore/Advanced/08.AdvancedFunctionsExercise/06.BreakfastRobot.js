/*jshint esversion: 6 */
function laSolucion() {
    let ingredientsByQtny = new Map([
        ['protein', 0],
        ['carbohydrate', 0],
        ['fat', 0],
        ['flavour', 0]
    ]);

    let recipesByIngredients = new Map([
        ['apple', {carbohydrate: 1, flavour: 2}],
        ['coke', {carbohydrate: 10, flavour: 20}],
        ['burger', {carbohydrate: 5, fat: 7, flavour: 3}],
        ['omlet', {protein: 5, fat: 1, flavour: 1}],
        ['cheverme', {protein: 10, carbohydrate: 10, fat: 10, flavour: 10}]
    ]);

    return function (incomingRequest) {
        "use strict";
        let requestDetails = incomingRequest.split(" ");
        if (requestDetails.length > 1) {
            switch (requestDetails[0]) {
                case 'restock':
                    return restock(requestDetails[1], requestDetails[2]);
                    break;
                case 'prepare':
                    return prepare(requestDetails[1], requestDetails[2]);
                    break;
            }
        }
        else {
            let result = "";
            Array.from(ingredientsByQtny).forEach(x => result += `${x[0]}=${x[1]} `);
            return result.trim();
        }
        function restock(microelement, quantity) {
            let previousQuantity = ingredientsByQtny.get(microelement);
            ingredientsByQtny.set(microelement, previousQuantity + Number(quantity));
            return 'Success';
        }

        function prepare(recipe, quantity) {
            let ingredientsForRecipe = recipesByIngredients.get(recipe);
            for (let property in ingredientsForRecipe) {
                let availableIngredients = ingredientsByQtny.get(property);
                let requiredIngredients = ingredientsForRecipe[property] * quantity;
                if (availableIngredients < requiredIngredients) {
                    return `Error: not enough ${property} in stock`;
                }
            }
            for (let ingredientInRecipe in ingredientsForRecipe) {
                let availableIngredients = ingredientsByQtny.get(ingredientInRecipe);
                let requiredIngredients = ingredientsForRecipe[ingredientInRecipe] * quantity;
                ingredientsByQtny.set(ingredientInRecipe, (availableIngredients - requiredIngredients));
            }

            return 'Success'
        }
    }
}

let kur = laSolucion();
console.log(kur('restock protein 100'));
console.log(kur('restock carbohydrate 100'));
console.log(kur('restock fat 100'));
console.log(kur('restock flavour 100'));
console.log(kur('report'));
console.log(kur('prepare omlet 2'));
console.log(kur('report'));
