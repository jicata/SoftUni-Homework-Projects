/*jshint esversion: 6 */
function sortBy2(input) {
    function compare(a, b) {
        if (a.length < b.length) {
            return -1;
        }
        else if (b.length < a.length) {
            return 1;
        }
        else{
            if(a < b){
                return -1;
            }
            else if(a > b){
                return 1;
            }
            else{
                return 0;
            }
        }

    }
    input.sort(compare).forEach(e=>console.log(e));
}
sortBy2(["Isaac", "Theodor","Jack","Harrison","George"]);
