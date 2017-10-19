$(function () {
    let dayCount = $('input[name="rentDays"]');
    dayCount.change(calcTotalSum);

    function calcTotalSum() {
        let priceParagraph = $('.price').text();
        let pricePerDay = Number(priceParagraph.substr(priceParagraph.lastIndexOf(':') + 1));
        let days = Number(dayCount.val());

        let finalSumParagraph = $("#finalSum");
        let finalSum = pricePerDay * days;
        finalSumParagraph.text(`Total price: ${finalSum} ЗИМБАБВСКИ ДОЛАРИ БРАТ`)

        let hiddenFinalSum = $('input[name="totalPrice"]').val(finalSum); 
    }

})