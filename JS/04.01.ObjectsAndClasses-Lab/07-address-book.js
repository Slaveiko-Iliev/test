function solve(input) {
    let personList = {};

    for (const record of input) {
        const recordInfo = record.split(':');
        const name = recordInfo[0];
        const address = recordInfo[1];

        personList[name]=address;
    }

    const sortedArray = Object
        .entries(personList)
        .sort((a, b) => a[0].localeCompare(b[0]));

    const sortedPersonList = Object.fromEntries(sortedArray);

    for (const record in sortedPersonList) {
        console.log(`${record} -> ${personList[record]}`);
    }
}

solve(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']
);

solve(['Bob:Huxley Rd',
'John:Milwaukee Crossing',
'Peter:Fordem Ave',
'Bob:Redwing Ave',
'George:Mesta Crossing',
'Ted:Gateway Way',
'Bill:Gateway Way',
'John:Grover Rd',
'Peter:Huxley Rd',
'Jeff:Gateway Way',
'Jeff:Huxley Rd']
);