let fullName = 'Stamat Petkov';
let fullName2 = 'Gosho Goshev';

let phoneBook = {
    'Ivan Ivanov': '+35988123123',
    'Ginka Stamenova': '+35988123124',
    [fullName]: '+35988123126',
    'Ivaylo Papazov': null
};

phoneBook['Pesho Gerov'] = '+35988123125';
phoneBook[fullName2] = '+35988123126';

console.log(phoneBook);

// Use for in loop
for (const name in phoneBook) {
    console.log(`${name} ->>> ${phoneBook[name]}`);
}

// Equivalent 
for (const name of Object.keys(phoneBook)) {
    console.log(name);
}

// Use forin for arrays !It works but don't use for arrays
const names = ['Pesho', 'Gosho', 'Stamat'];
for (const index in names) {
    console.log(names[index]);
}

// Check if person has value in the phoneBook
if (phoneBook['Ivaylo Papazov']){
    console.log('Phone Found');
} else {
    console.log('Phone Not found');
}

// Check if property name exists
if (phoneBook.hasOwnProperty('Ivaylo Papazov')) {
    console.log('Name found');
} else {
    console.log('Name not found');
}

console.log('Ivaylo Papazov' in phoneBook);

// Sort an object
let sortedArray = Object
    .entries(phoneBook)
    .sort(([keyA, valueA], [keyB, valueB]) => keyA.localeCompare(keyB))
    // .sort((a, b) => a[0].localeCompare(b[0]))
console.log(sortedArray);

console.log(Object.fromEntries(sortedArray));
