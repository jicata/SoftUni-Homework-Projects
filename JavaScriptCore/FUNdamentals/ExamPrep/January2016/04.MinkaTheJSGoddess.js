/*jshint esversion: 6 */
function minka(data) {
    "use strict";
    let tasksMap = new Map();
    for (let i = 0; i < data.length; i++) {
        let taskDetails = data[i].split(" & ");
        let problemName = taskDetails[0];
        let problemType = taskDetails[1];
        let taskNumber = `Task ${Number(taskDetails[2])}`;
        let score = Number(taskDetails[3]);
        let linesOfCode = Number(taskDetails[4]);

        let problemObject = {
            name: problemName,
            type: problemType,
            score: score,
            linesOfCode: linesOfCode
        };
        let problems = [];
        if (!tasksMap.has(taskNumber)) {
            problems.push(problemObject);
            tasksMap.set(taskNumber,problems);
            continue;
        }
        problems = tasksMap.get(taskNumber);
        problems.push(problemObject);
        tasksMap.set(taskNumber,problems);
    }

    let sortedTaskMap = Array.from(tasksMap).sort((a,b)=>outerSort(a,b));
    let result = {};
    for(let [task,problems] of sortedTaskMap){
        problems = problems.sort(function (a,b) {
            return a.name.localeCompare(b.name);
        });
        let averageScore= 0;
        let linesOfCode = 0;

        let resultObject = {
                tasks:[],
                average:0,
                lines:0
        };
        for(let problem of problems){
            let problemJson = {
                name:problem.name,
                type:problem.type
            };
            averageScore +=problem.score;
            linesOfCode +=problem.linesOfCode;
            resultObject.tasks.push(problemJson);
        }
        averageScore = averageScore / problems.length;
        resultObject.average = parseFloat(averageScore.toFixed(2));
        resultObject.lines = linesOfCode;
        result[task] = resultObject;
    }
    console.log(JSON.stringify(result));

    function outerSort(a,b){
        let problemsA = a[1];
        let problemsB = b[1];

        let totalScoreForA = 0;
        let totalLinesOfCodeForA =0;
        let totalScoreForB = 0;
        let totalLinesOfCodeForB =0;

        for(let problem of problemsA){
            totalScoreForA+=problem.score;
            totalLinesOfCodeForA+=problem.linesOfCode;
        }
        for(let problem of problemsB){
            totalScoreForB+=problem.score;
            totalLinesOfCodeForB+=problem.linesOfCode;
        }

        let averageScoresA = totalScoreForA / problemsA.length;
        let averageScoresB = totalScoreForB/problemsB.length;

        if(averageScoresA > averageScoresB){
            return -1;
        }
        if(averageScoresA < averageScoresB){
            return 1;
        }

        if(totalLinesOfCodeForA > totalLinesOfCodeForB){
            return 1;
        }
        if(totalLinesOfCodeForA < totalLinesOfCodeForB){
            return -1;
        }
        return 0;
    }
}
// minka(["Array Matcher & strings & 4 & 100 & 38",
//     "Magic Wand & draw & 3 & 100 & 15",
//     "Dream Item & loops & 2 & 88 & 80",
//     "Knight Path & bits & 5 & 100 & 65",
//     "Basket Battle & conditionals & 2 & 100 & 120",
//     "Torrent Pirate & calculations & 1 & 100 & 20",
//     "Encrypted Matrix & nested loops & 4 & 90 & 52",
//     "Game of bits & bits & 5 &  100 & 18",
//     "Fit box in box & conditionals & 1 & 100 & 95",
//     "Disk & draw & 3 & 90 & 15",
//     "Poker Straight & nested loops & 4 & 40 & 57",
//     "Friend Bits & bits & 5 & 100 & 81"]);