function solve(countOfPeople, typeOfGroup, dayOfWeek ) {
    let price;
    switch (dayOfWeek) {
        case `Friday`:
            if (typeOfGroup === `Students`) {
                price = 8.45
            } else if (typeOfGroup === `Business`) {
                price = 10.9
            } else if (typeOfGroup === `Regular`) {
                price = 15
            }
            break;
        case `Saturday`:
            if (typeOfGroup === `Students`) {
                price = 9.8
            } else if (typeOfGroup === `Business`) {
                price = 15.6
            } else if (typeOfGroup === `Regular`) {
                price = 20
            }
            break;
        case `Sunday`:
            if (typeOfGroup === `Students`) {
                price = 10.46
            } else if (typeOfGroup === `Business`) {
                price = 16
            } else if (typeOfGroup === `Regular`) {
                price = 22.5
            }
            break;
    }

    let totalPrice = countOfPeople * price;

    if (typeOfGroup === `Students` && countOfPeople >= 30) {
        totalPrice *= 0.85;
    } else if (typeOfGroup === `Business` && countOfPeople >= 100) {
        totalPrice = (countOfPeople - 10) * price;
    } else if (typeOfGroup === `Regular` && countOfPeople >= 10 && countOfPeople <= 20) {
        totalPrice *= 0.95;
    }

    console.log (`Total price: ${totalPrice.toFixed(2)}`);
}

solve (30, "Students", "Sunday");
solve (40, "Regular", "Saturday");