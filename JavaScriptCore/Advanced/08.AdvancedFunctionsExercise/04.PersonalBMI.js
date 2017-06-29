/*jshint esversion: 6 */
function areYouFatMrFattyMcFattersonQuestionMarkQuestionMark(nameParam, ageParam, weightParam, heightParam) {

    let heightInMeters = heightParam/100;
    let bmi = weightParam / (heightInMeters * heightInMeters);
    let status;
    if (bmi < 18.5) {
        status = 'underweight';
    }
    else if (bmi >= 18.5 && bmi < 25) {
        status = 'normal';
    }
    else if (bmi >= 25 && bmi < 30) {
        status = `overweight`;
    }
    else {
        status = `obese`;
    }
    let result = {
        name: nameParam,
        personalInfo: {
            age: Math.round(ageParam),
            weight: Math.round(weightParam),
            height: Math.round(heightParam),
        },
        BMI: Math.round(bmi),
        status: status
    }

    Object.assign(result, status == 'obese' ? {recommendation: 'admission required'} : null)
    return result;

}

// let kur = areYouFatMrFattyMcFattersonQuestionMarkQuestionMark("Honey Boo Boo", 9, 57, 137);
//     console.log(kur);

// let kur = {
//     name: 'Honey Boo Boo',
//     personalInfo: {age: 9, weight: 57, height: 137},
//     BMI: 30,
//     status: 'obese', recommendation: 'admission required'
// }