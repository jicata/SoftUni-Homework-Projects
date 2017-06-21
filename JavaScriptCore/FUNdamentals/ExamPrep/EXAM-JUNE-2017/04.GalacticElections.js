/*jshint esversion: 6 */
function panGalacticGargleBlaster(data) {
    "use strict";
    let votesBySystem = new Map();
    let systemsByCandidate = new Map();
    let votesByCandidate = new Map();

    for (let info of data) {
        let systemName = info.system;
        let candidate = info.candidate;
        let votes = Number(info.votes);

        if (!votesBySystem.has(systemName)) {
            let innerCandidateVotes = new Map();
            innerCandidateVotes.set(candidate, votes);
            votesBySystem.set(systemName, innerCandidateVotes);
        }
        else if (votesBySystem.has(systemName)) {
            let innerCandidateVotes = votesBySystem.get(systemName).get(candidate);
            if (innerCandidateVotes == undefined) {
                innerCandidateVotes = votesBySystem.get(systemName);
                innerCandidateVotes.set(candidate, votes);
                votesBySystem.set(systemName, innerCandidateVotes);
            }
            else {
                innerCandidateVotes = votesBySystem.get(systemName).get(candidate) + votes;
                let innerMap = votesBySystem.get(systemName);
                innerMap.set(candidate, innerCandidateVotes);
                votesBySystem.set(systemName, innerMap);
            }
        }
        if (!systemsByCandidate.has(candidate)) {
            systemsByCandidate.set(candidate, new Map());
            votesByCandidate.set(candidate, 0);
        }
    }

    let totalVotes = 0;
    for (let [system, details] of votesBySystem) {
        let topCandidate = "";
        let topVotes = 0;
        let allVotesPerSystem = 0;
        for (let [candidate, votes] of details) {
            if (votes > topVotes) {
                topCandidate = candidate;
                topVotes = votes;
            }
            allVotesPerSystem += votes;
        }
        totalVotes +=allVotesPerSystem;
        let systemsWonByCandidate = systemsByCandidate.get(topCandidate);
        systemsWonByCandidate.set(system, allVotesPerSystem);
        systemsByCandidate.set(topCandidate, systemsWonByCandidate);

        let votesForCandidate = votesByCandidate.get(topCandidate);
        votesForCandidate += allVotesPerSystem;
        votesByCandidate.set(topCandidate, votesForCandidate);
    }

    let sortedCandidatesByVotes = Array.from(votesByCandidate).sort((a, b) => sortCandidates(a, b));

    let winner = sortedCandidatesByVotes[0][0];
    let winnerVotes = sortedCandidatesByVotes[0][1];

    if (winnerVotes == totalVotes) {
        console.log(`${winner} wins with ${totalVotes} votes`);
        console.log(`${winner} wins unopposed!`);
        return;
    }

    let runnerUp = sortedCandidatesByVotes[1][0];
    let runnerUpVotes = sortedCandidatesByVotes[1][1];
    if(winnerVotes <= totalVotes/2){
        let winnerPercentage = Math.floor((winnerVotes / totalVotes) * 100);
        let runnerUpPercentage = Math.floor((runnerUpVotes / totalVotes) * 100);
        console.log(`Runoff between ${winner} with ${winnerPercentage}% and ${runnerUp} with ${runnerUpPercentage}%`);
    }

    else{
        console.log(`${winner} wins with ${votesByCandidate.get(winner)} votes`);
        console.log(`Runner up: ${runnerUp}`);
        let runnerUpWonSystems = Array.from(systemsByCandidate.get(runnerUp)).sort((a,b)=>sortSystem(a,b));
        for(let [system, votes] of runnerUpWonSystems){
            console.log(`${system}: ${votes}`);
        }
    }

    function sortSystem(a,b) {
        let votesOfA = a[1];
        let votesOfB = b[1];
        if(votesOfA > votesOfB){
            return -1;
        }
        if(votesOfA < votesOfB){
            return 1;
        }
        return 0;
    }
    function sortCandidates(a, b) {
        if (a[1] > b[1]) {
            return -1;
        }
        else if (a[1] < b[1]) {
            return 1;
        }
        return 0;
    }

 }
// panGalacticGargleBlaster([{system: 'Theta', candidate: 'Flying Shrimp', votes: 10},
//     {system: 'Sigma', candidate: 'Space Cow', votes: 200},
//     {system: 'Sigma', candidate: 'Flying Shrimp', votes: 120},
//     {system: 'Tau', candidate: 'Space Cow', votes: 15},
//     {system: 'Sigma', candidate: 'Space Cow', votes: 60},
//     {system: 'Tau', candidate: 'Flying Shrimp', votes: 150}]
// );

// panGalacticGargleBlaster([ { system: 'Theta', candidate: 'Kim Jong Andromeda', votes: 10 },
//     { system: 'Tau',   candidate: 'Kim Jong Andromeda', votes: 200 },
//     { system: 'Tau',   candidate: 'Flying Shrimp',      votes: 150 } ]
// );

// panGalacticGargleBlaster([ { system: 'Tau',     candidate: 'Flying Shrimp', votes: 150 },
//     { system: 'Tau',     candidate: 'Space Cow',     votes: 100 },
//     { system: 'Theta',   candidate: 'Space Cow',     votes: 10 },
//     { system: 'Sigma',   candidate: 'Space Cow',     votes: 200 },
//     { system: 'Sigma',   candidate: 'Flying Shrimp', votes: 75 },
//     { system: 'Omicron', candidate: 'Flying Shrimp', votes: 50 },
//     { system: 'Omicron', candidate: 'Octocat',       votes: 75 } ]
// );