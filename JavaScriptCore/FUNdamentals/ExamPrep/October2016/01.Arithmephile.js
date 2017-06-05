/**
 * Created by Administrator on 5.6.2017 г..
 */
function funnyPunnyJoke(data){
    let numbers = data.map(Number);
    const lowerBound = 0;
    const upperBound = 10;

    let maxResult = Number.MIN_SAFE_INTEGER;
   for(let i = 0; i < numbers.length; i++){
       let number = numbers[i];
       if(number >= lowerBound && number < upperBound){
           let jumpForward = i + number;
           let result = 1;
           for(let j = i + 1; j <= jumpForward; j++){
               result *= numbers[j];
           }
           if(result > maxResult){
               maxResult = result;
           }
       }
   }
   console.log(maxResult);
}
// funnyPunnyJoke(['100',
//     '200',
//     '2',
//     '3',
//     '2',
//     '3',
//     '2',
//     '1',
//     '1']);

