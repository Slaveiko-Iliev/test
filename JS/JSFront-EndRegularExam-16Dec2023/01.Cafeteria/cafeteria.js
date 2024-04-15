function solve(input) {
    const baristaCount = Number(input[0]);

    const cafeteriaTeam = [];

    for (let i = 1; i <= baristaCount; i++) {
        const baristaInfo = input[i].split(' ');
        const coffeList = baristaInfo[2].split(',');

        const barista = {
            "name": baristaInfo[0],
            "shift": baristaInfo[1],
            "coffeType": coffeList,
        }

        cafeteriaTeam.push(barista);
    }

    for (let i = 1 + baristaCount; i < input.length; i++) { 
        const commandInfo = input[i].split(' / ');
        const command = commandInfo[0];
        const baristaName = commandInfo[1];
        const currentBarista = cafeteriaTeam.find(barista => barista.name === baristaName);

        if (command !== 'Closed') {
            switch (command) {
                case "Prepare":
                    const currentCoffeType = commandInfo[3];

                    if (currentBarista.coffeType.find(coffeName => coffeName === currentCoffeType) &&
                        currentBarista.shift === commandInfo[2]){
                            console.log(`${currentBarista.name} has prepared a ${currentCoffeType} for you!`);
                    }else {
                        console.log(`${currentBarista.name} is not available to prepare a ${currentCoffeType}.`);
                    }
                    break;
                case "Change Shift":
                    currentBarista.shift = commandInfo[2];
                    console.log(`${baristaName} has updated his shift to: ${currentBarista.shift}`);
                    break;
                case "Learn":
                    const newCoffeType = commandInfo[2];
                    if (currentBarista.coffeType.includes(newCoffeType)) {
                        console.log(`${baristaName} knows how to make ${newCoffeType}.`);
                    } else {
                        console.log(`${baristaName} has learned a new coffee type: ${newCoffeType}.`);
                        currentBarista.coffeType.push(newCoffeType)
                    }
                    break;
            }
        }
    }

    for (const barista of cafeteriaTeam) {
        console.log(`Barista: ${barista.name}, Shift: ${barista.shift}, Drinks: ${barista.coffeType.join(', ')}`);
    }
}

solve([
    '3',
      'Alice day Espresso,Cappuccino',
      'Bob night Latte,Mocha',
      'Carol day Americano,Mocha',
      'Prepare / Alice / day / Espresso',
      'Change Shift / Bob / night',
      'Learn / Carol / Latte',
      'Learn / Bob / Latte',
      'Prepare / Bob / night / Latte',
      'Closed']
    );