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

function fancySolve(input) {
    input
        .map(row => row.split(' | '))
        .map(row => ({
            town: row[0],
            latitude: Number(row[1]).toFixed(2),
            longitude: Number(row[2]).toFixed(2),
        }))
        .forEach(town => console.log(town));
}

fancySolve(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']
);