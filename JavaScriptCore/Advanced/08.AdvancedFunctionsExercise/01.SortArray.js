/*jshint esversion: 6 */
function sortArray(array, orderBy) {
    if(orderBy == 'asc'){
        return array.sort((a,b)=> a > b ? 1 : -1 )
    }
    else{
        return array.sort((a,b)=> a > b ? -1 : 1)
    }

}
let kur =sortArray([14, 7, 17, 6, 8], 'asc');
console.log(kur);