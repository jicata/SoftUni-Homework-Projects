/*jshint esversion: 6 */
function phoebbinacci(n) {
    let firstNumber = 0;
    let secondNumber = 1;
    let sequence = [1];
    for(let i = 2; i<=n;i++){
        let nextNumberInSequence = firstNumber + secondNumber;
        firstNumber = secondNumber;
        secondNumber = nextNumberInSequence;
        sequence.push(nextNumberInSequence);
   }
   return sequence;
}
//console.log(phoebbinacci(15));