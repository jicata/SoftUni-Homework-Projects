/*jshint esversion: 6 */
function biggestOfThreeNumbers([firstNum, secondNum, thirdNum]) {
    let nums = [firstNum, secondNum, thirdNum] = [firstNum, secondNum, thirdNum].map(Number);
    let maxNum = -Math.min();
    for(i=0;i <nums.length; i++){
        if(nums[i] >= maxNum){
            maxNum = nums[i];
        }
    }
    //let otherMaxNum = Math.max.apply(Math, nums);
    //console.log(otherMaxNum);
    console.log(maxNum);

}
biggestOfThreeNumbers([5,-2,7]);