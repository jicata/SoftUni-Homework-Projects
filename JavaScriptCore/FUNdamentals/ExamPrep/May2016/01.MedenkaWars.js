/*jshint esversion: 6 */
function medenkaWars(medenkas) {
    "use strict";
    const damagePerMedenka = 60;
    let damageByCombatants = new Map();
    damageByCombatants.set("Vitkor", 0);
    damageByCombatants.set("Naskor", 0);

    let lastWhiteDamage = 0;
    let lastBlackDamage = 0;

    let whiteCounter = 1;
    let blackCounter = 1;

    for (let i = 0; i < medenkas.length; i++) {
        let lineOfMedenka = medenkas[i].split(" ");
        let amountOfMedenka = Number(lineOfMedenka[0]);
        let colourOfMedenka = lineOfMedenka[1];

        let medenkaDmg = amountOfMedenka * damagePerMedenka;
        if (colourOfMedenka == 'white') {
            let vitkorDmg = damageByCombatants.get("Vitkor");
            if(medenkaDmg == lastWhiteDamage){
                whiteCounter++;
            }
            if (whiteCounter == 2) {
                medenkaDmg*=2.75;
                vitkorDmg += medenkaDmg;
                whiteCounter = 1;
            } else {
                vitkorDmg += medenkaDmg;
            }
            damageByCombatants.set("Vitkor",vitkorDmg);
            lastWhiteDamage = medenkaDmg;
        }
        else {
            let naskorDmg = damageByCombatants.get("Naskor");
            if(medenkaDmg == lastBlackDamage){
                blackCounter++;
            }
            if (blackCounter == 5) {
                medenkaDmg = 4.5 * medenkaDmg;
                naskorDmg += medenkaDmg;
                blackCounter=1
            } else {
                naskorDmg += medenkaDmg;
            }
            damageByCombatants.set("Naskor",naskorDmg);
            lastBlackDamage = medenkaDmg;
        }
    }
    let finalVitkorDmg = damageByCombatants.get("Vitkor");
    let finalNaskorDmg = damageByCombatants.get("Naskor");
    if (finalVitkorDmg > finalNaskorDmg) {
        console.log(`Winner - Vitkor`);
        console.log(`Damage - ${finalVitkorDmg}`);
    }
    else {
        console.log(`Winner - Naskor`);
        console.log(`Damage - ${finalNaskorDmg}`);
    }
}
// medenkaWars(['5 white medenkas',
//     '5 dark medenkas',
//     '4 white medenkas']);