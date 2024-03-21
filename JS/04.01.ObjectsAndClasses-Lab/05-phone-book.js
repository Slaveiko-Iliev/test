function solve(inputPhoneBook){
    let phoneBook = {};

    for (const record of inputPhoneBook) {
        let personInfo = record.split(' ');

        let personName = personInfo[0];
        let phoneNumber = personInfo[1];

        phoneBook[personName] = phoneNumber;
    }

    for (const record in phoneBook) {
        console.log(`${record} -> ${phoneBook[record]}`);
    }
}

solve(['Tim 0834212554',
'Peter 0877547887',
'Bill 0896543112',
'Tim 0876566344']
);
console.log();
solve(['George 0552554',
'Peter 087587',
'George 0453112',
'Bill 0845344']
);