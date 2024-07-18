function solve(employeeNames) {
    const employees = {};

    for (const name of employeeNames) {
        employees[name] = name.length
    }

    for (const employee in employees) {
        console.log(`Name: ${employee} -- Personal Number: ${employees[employee]}`);
    }
}

function fancierSolve(employeeNames) {
    const employees = [];

    for (const name of employeeNames) {
        const employee = {
            name,
            personalNumber: name.length,
        };

        employees.push(employee);
    }

    for (const employee of employees) {
        console.log(`Name: ${employee.name} -- Personal Number: ${employee.personalNumber}`);
    }
}

function fanciestSolve(employeeNames) {
    employeeNames
        .map(name => ({ name, personalNumber: name.length }))
        .forEach(employee => console.log(`Name: ${employee.name} -- Personal Number: ${employee.personalNumber}`))
}

fanciestSolve([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
])
