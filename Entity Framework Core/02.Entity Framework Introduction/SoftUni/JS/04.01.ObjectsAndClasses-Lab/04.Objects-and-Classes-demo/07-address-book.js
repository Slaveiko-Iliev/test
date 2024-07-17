function solve(input) {
    const addressBook = {};

    input.forEach(line => {
        const [name, address] = line.split(':');

        addressBook[name] = address;
    });
    // const addressBook = input.reduce((book, line) => {
    //     const [name, address] = line.split(':');

    //     book[name] = address;

    //     return book;
    // }, {})

    Object
        .entries(addressBook)
        .sort((a, b) => a[0].localeCompare(b[0]))
        .forEach(([name, address]) => console.log(`${name} -> ${address}`))
}

solve(['Tim:Doe Crossing',
    'Bill:Nelson Place',
    'Peter:Carlyle Ave',
    'Bill:Ornery Rd']
)
