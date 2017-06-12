/*jshint esversion: 6 */
function calcExamResults(data) {
    "use strict";
    let examPointsModifier = 0.2;
    let minimumPointsForExcellentScore = 80;
    let minimumExamThreshold = 100;

    if(data[data.length-1] ==" "){
        data.pop();
    }
    let courseName = data.pop();
    let totalStudentsInCourse = 0;
    let totalExamPointsInCourse = 0;
    let coursesStudents = new Map();
    for (let i = 0; i < data.length; i++) {
        let studentDetails = data[i].split(/\s+/g).filter(function (n) {
            return n!=undefined && n!=null && n!=" ";
        });
        let studentName = studentDetails[0].trim();
        let course = studentDetails[1].trim();
        let examPoints = Number(studentDetails[2].trim());
        let bonusPoints = Number(studentDetails[3].trim());

        let examPointsConverted = examPoints * examPointsModifier;
        let totalPoints = examPointsConverted + bonusPoints;
        let grade = ((totalPoints / minimumPointsForExcellentScore) * 4) + 2;
        if(grade >= 6){
            grade = parseFloat(6.00);
        }

        let student = {name: studentName, coursePoints: totalPoints, grade: grade, examPoints: examPoints};
        if(examPoints >= minimumExamThreshold){
            console.log(`${student.name}: Exam - "${course}"; Points - ${parseFloat(totalPoints.toFixed(2))}; Grade - ${grade.toFixed(2)}`);
        }
        else{
            console.log(`${student.name} failed at "${course}"`)
        }

        if(course == courseName){
            totalStudentsInCourse++;
            totalExamPointsInCourse+=examPoints;
        }
    }
    console.log(`"${courseName}" average points -> ${parseFloat((totalExamPointsInCourse/totalStudentsInCourse).toFixed(2))}`);
}
// calcExamResults(["Pesho C#-Advanced 100 3",
//     "Gosho Java-Basics 157 3",
//     "Tosho HTML&CSS 317 12",
//     "Minka C#-Advanced 57 15",
//     "Stanka C#-Advanced 157 15",
//     "Kircho C#-Advanced 300 0",
//     "Niki C#-Advanced 400 10",
//     "C#-Advanced"]);

// calcExamResults(["   EDUU    JS-Basics                317          15",
//     "RoYaL        HTML5        121         10",
//     "ApovBerger      OOP   0    10",
//     "Stamat OOP   190 10",
//     "MINKA OOP   230 10",
//     "OOP"]);