/*jshint esversion: 6 */
function summable() {
    let selector1;
    let selector2;
    let resultSelector;

    function init(selectorOne, selectorTwo, resultSelectorThree) {
        selector1 = $(selectorOne);
        selector2 = $(selectorTwo);
        resultSelector = $(resultSelectorThree);
    }

    function add() {
        let valueOne = selector1.val();
        let valueTwo = selector2.val();
       // $(selector2).val(Number(valueOne) + Number(valueTwo));
        $(resultSelector).val(Number(valueOne) + Number(valueTwo));
    }

    function subtract() {
        let valueOne = selector1.val();
        let valueTwo = selector2.val();
       // $(selector2).val(Number(valueTwo) - Number(valueOne));
        $(resultSelector).val(Number(valueOne) - (valueTwo));
    }

    return {init,add,subtract}
}