function CalcVat(arrayOfNumbers) {
    var sum = 0;
    for(i=0; i<arrayOfNumbers.length; i++)
    {
        sum+= Number(arrayOfNumbers[i]);
    }
    var vat = 0.2 * sum;
    var total = sum + vat;
    console.log("sum = " + sum);
    console.log("VAT = " + vat);
    console.log("total = " + sum*1.2);
}

CalcVat(['99.9999', '99.9999','99.9999','99.9999','99.9999','99.9999','99.9999','99.9999']);