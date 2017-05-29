function NextDayCalculator(date) {
    var year = Number(date[0]);
    var month = Number(date[1])-1;
    var day = Number(date[2]);
    var oldDate = new Date(year,month,day);
    //console.log(oldDate);
    oldDate.setDate(oldDate.getDate() +1);
    //console.log(oldDate.getUTCFullYear() + "-" +(oldDate.getUTCMonth()+1)+ "-" +oldDate.getUTCDate());
    console.log(oldDate.getFullYear() + "-" +(oldDate.getMonth()+1)+ "-" +oldDate.getDate());
    //console.log(oldDate.toISOString())
}

NextDayCalculator(['2016', '9', '30']);