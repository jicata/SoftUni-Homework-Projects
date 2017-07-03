/*jshint esversion: 6 */
function workItWorkIt(worker) {
    let arbeiter = worker;
    if(arbeiter.handsShaking){
        let requiredAmount = (arbeiter.weight * 0.1) * arbeiter.experience;
        arbeiter.bloodAlcoholLevel += requiredAmount;
        arbeiter.handsShaking = false;
    }
    return arbeiter;
}
let result = workItWorkIt({ weight: 120,
    experience: 20,
    bloodAlcoholLevel: 200,
    handsShaking: true }
);
console.log(result);