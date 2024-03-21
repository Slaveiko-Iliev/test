function solve(input) {
    let listEmployees = {};

    for (const employee of input) {
        const personalNum = employee.length;
        listEmployees[employee] = [personalNum];
    }

    for (const employee in listEmployees) {
        console.log(`Name: ${employee} -- Personal Number: ${listEmployees[employee]}`);
    }
}

solve([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]
    );