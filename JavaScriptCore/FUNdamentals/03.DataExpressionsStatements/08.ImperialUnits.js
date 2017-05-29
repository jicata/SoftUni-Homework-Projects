function ImperialToImperial(inches) {
    let inchesAsNumber = Number(inches);
    let foot = Math.floor(inchesAsNumber / 12);
    inchesAsNumber %= 12;
    console.log(foot + "'-" +inchesAsNumber +"\"");
}
ImperialToImperial('11');