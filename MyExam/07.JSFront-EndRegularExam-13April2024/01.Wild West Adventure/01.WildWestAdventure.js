function solve(input) {
    const countOfHooligans = Number(input[0]);
    const gang = [];

    for (let i = 1; i <= countOfHooligans; i++) {
        const currentBanditInfo = input[i].split(' ');

        const currentBandit = {
            "name": currentBanditInfo[0],
            "hp": currentBanditInfo[1],
            "bullets": currentBanditInfo[2],
        }
        
        gang.push(currentBandit);
    }

    for (let i = 0 + countOfHooligans + 1; i < input.length; i++) {

        const command = input[i].split(' - ');
        const banditHero = gang.find(bandit =>bandit.name === command[1]);

        if (input[i] !== `Ride Off Into Sunset`) {
            const target = command[2];

            if (command[0] === 'FireShot'){
                if (banditHero.bullets > 0) {
                    banditHero.bullets --;
                    console.log(`${banditHero.name} has successfully hit ${target} and now has ${banditHero.bullets} bullets!`);
                } else {
                    console.log(`${banditHero.name} doesn't have enough bullets to shoot at ${target}!`);
                }
            } else if (command[0] === 'TakeHit'){
                const damage = command[2];
                const attacker = command[3];
                banditHero.hp -= damage;

                if (banditHero.hp > 0) {
                    console.log(`${banditHero.name} took a hit for ${damage} HP from ${attacker} and now has ${banditHero.hp} HP!`);

                } else {
                    console.log(`${banditHero.name} was gunned down by ${attacker}!`);
                    const index = gang.findIndex(bandit =>bandit.name === command[1]);
                    gang.splice(index, 1);
                }
            } else if (command[0] === 'Reload'){
                if (banditHero.bullets < 6){
                    
                    console.log(`${banditHero.name} reloaded ${6 - banditHero.bullets} bullets!`);
                    banditHero.bullets = 6;
                } else {
                    //!!!!!!
                    console.log(`${banditHero.name}'s pistol is fully loaded!`);
                }
            } else if (command[0] === 'PatchUp'){
                const amount = Number(command[2]);

                if (banditHero.hp < 100){
                    
                    if ((banditHero.hp + amount) <= 100){
                        console.log(`${banditHero.name} patched up and recovered ${amount} HP!`);
                        banditHero.hp += amount;
                    } else {
                        console.log(`${banditHero.name} patched up and recovered ${100 - banditHero.hp} HP!`);
                        banditHero.hp = 100;
                    }
                    
                } else {
                    console.log(`${banditHero.name} is in full health!`);
                    banditHero.hp = 100;
                }
            }
        }
    }

    for (const currentBanditHero of gang) {
        console.log(`${currentBanditHero.name}\n HP: ${currentBanditHero.hp}\n Bullets: ${currentBanditHero.bullets}`);
    }
}

solve(["2",
"Jesse 100 4",
"Walt 100 5",
"FireShot - Jesse - Bandit",
 "TakeHit - Walt - 30 - Bandit",
 "PatchUp - Walt - 20" ,
 "Reload - Jesse",
 "Ride Off Into Sunset"])
;