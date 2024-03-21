function solve(input) {
    for (const record of input) {
        const townInfo = record.split(' | ');
        const town = townInfo[0];
        const latitude = Number(townInfo[1]).toFixed(2);
        const longitude = Number(townInfo[2]).toFixed(2);

        let currentTown = {
            town,
            latitude,
            longitude,
        };

        console.log(currentTown);
    }
}

solve(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']
);