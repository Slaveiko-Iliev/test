function solve(input) {
    let heroList = [];

    for (const currentHero of input) {
        const [heroName, heroLevel, items] = currentHero.split(' / ');
        const hero = {
            heroName,
            heroLevel: Number(heroLevel),
            items,
        }   
        heroList.push(hero);     
    }

    for (const hero of heroList.sort((a, b) => a.heroLevel - b.heroLevel)) {
        console.log(`Hero: ${hero.heroName}`);
        console.log(`level => ${hero.heroLevel}`);
        console.log(`items => ${hero.items}`);
    }
}

solve([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
    ]
    ); 

solve([
    'Batman / 2 / Banana, Gun',
    'Superman / 18 / Sword',
    'Poppy / 28 / Sentinel, Antara'
    ]
    );