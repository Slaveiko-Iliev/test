function solve(startingYield) {
    let countOfDays = 0
    let extractedSpice = 0;
    const crewConsumation = 26;

    while (startingYield >= 100) {
        extractedSpice += startingYield;
        extractedSpice -= crewConsumation;
        startingYield -= 10;

        if (startingYield < 100 && extractedSpice >= crewConsumation) {
            extractedSpice -= crewConsumation
        } else if (startingYield < 100 && extractedSpice < crewConsumation) {
            extractedSpice = 0;
        } 

        countOfDays ++;
    }

    console.log (countOfDays);
    console.log (extractedSpice);
}

solve (111);
solve(450);