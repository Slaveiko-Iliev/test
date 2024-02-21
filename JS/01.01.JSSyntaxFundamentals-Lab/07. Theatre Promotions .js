function solve(typeOfDay, age) {

    let result;

    switch (typeOfDay) {
        case `Weekday`:
            if (age < 0) {
                result = `Error!`;
            }    else if (age >= 0 && age <= 18) {
                result = `12$`;
            } else if (age <= 64) {
                result = `18$`;
            } else if (age <= 122) {
                result = `12$`;
            } else {
                result = `Error!`;
            }
            break;
        case `Weekend`:
            if (age < 0) {
                result = `Error!`;
            }    else if (age >= 0 && age <= 18) {
                result = `15$`;
            } else if (age <= 64) {
                result = `20$`;
            } else if (age <= 122) {
                result = `15$`;
            } else {
                result = `Error!`;
            }
            break;
        case `Holiday`:
            if (age < 0) {
                result = `Error!`;
            }    else if (age >= 0 && age <= 18) {
                result = `5$`;
            } else if (age <= 64) {
                result = `12$`;
            } else if (age <= 122) {
                result = `10$`;
            } else {
                result = `Error!`;
            }
            break;
    }

    console.log (result)
}

// solve ('Weekday', 42);
solve ('Holiday', -12);