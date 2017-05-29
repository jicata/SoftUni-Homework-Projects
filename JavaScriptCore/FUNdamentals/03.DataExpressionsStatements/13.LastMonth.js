/*jshint esversion: 6 */
function lastMonth([day, month, year]) {
    day = Number(day);
    month = Number(month)-1;
    year = Number(year);
    let date = new Date(year,month,0);
   // date.setDate(date.getDate());
   // console.log(date.getMonth());
    console.log(date.getDate());
}
lastMonth(['13','12','2004']);