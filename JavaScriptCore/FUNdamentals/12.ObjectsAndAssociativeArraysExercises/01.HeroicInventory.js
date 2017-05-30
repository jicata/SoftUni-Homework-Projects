/**
 * Created by Administrator on 30.5.2017 г..
 */
function heroicInventory(data){
    let heroData = [];
    for(let i = 0; i < data.length; i++){
        let currentHeroInfo = data[i].split(' / ').filter(String);

        let heroName = currentHeroInfo[0];
        let heroLevel = Number(currentHeroInfo[1]);
        let heroItems = [];

        if(currentHeroInfo.length>2){
            heroItems = currentHeroInfo[2].split(", ");
        }
        let hero = {
            name:heroName,
            level:heroLevel,
            items:heroItems
        };

        heroData.push(hero);
    }
    console.log(JSON.stringify(heroData));
}