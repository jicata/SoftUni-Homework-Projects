/*jshint esversion: 6 */
function increment(elementId) {
    let targetElement = $(elementId);

    let textArea = $(`<textarea class="counter" disabled="disabled">0</textarea>`);
    let incrementBtn = $(`<button class="btn" id="incrementBtn">Increment</button>`).click(incrementValue);
    let addBtn = $(`<button class="btn" id="addBtn">Add</button>`).click(add);
    let resultList = $(`<ul class="results"></ul>`);

    $(targetElement)
        .append(textArea)
        .append(incrementBtn)
        .append(addBtn)
        .append(resultList);


    function add() {
        let textareaVal = $('textarea.counter').val();
        $(`<li>${textareaVal}</li>`).appendTo($(`ul.results`));
    }

    function incrementValue() {
        let previousValue = Number($('textarea.counter').val());
        $('textarea.counter').val(++previousValue);
    }

}