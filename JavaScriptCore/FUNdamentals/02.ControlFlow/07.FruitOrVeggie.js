function DetermineWhatKindOfCreatureDoWeHaveHere(fruitOrVeggie) {

    fruitOrVeggie = fruitOrVeggie[0];
    var fruits = ["banana", "apple", "kiwi", "cherry", "lemon", "grapes", "peach"];
    var veggies = ["tomato", "cucumber", "pepper", "onion", "garlic", "parsley"];
    var contains = function(array, item, type){
        for(i=0; i < array.length; i++){
            if(array[i] === item){
                return type;
            }
        }
        return "unknown";
    };
    var result = contains(fruits, fruitOrVeggie, "fruit");
    if(result==="unknown"){
        result = contains(veggies, fruitOrVeggie, "vegetable");
    }
    console.log(result)
}/**
 * Created by Maika on 17-Feb-17.
 */
DetermineWhatKindOfCreatureDoWeHaveHere("pizza");