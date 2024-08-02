function solve (lostFights, helmetPrice, swordPrice, shieldPrice, armorPrice ) {
    let totalPrice = 0;
    let countShieldBreaks = 0
    
    for (let i = 1; i <= lostFights; i++) {
        if (i % 2 === 0) {
            totalPrice += helmetPrice;
        }
        if (i % 3 === 0) {
            totalPrice += swordPrice;
        }
        if (i % 2 === 0 && i % 3 === 0) {
            totalPrice += shieldPrice;
            countShieldBreaks ++;
        }
        if (countShieldBreaks > 0 && countShieldBreaks % 2 === 0) {
            totalPrice += armorPrice;
            countShieldBreaks = 0;
        }
    }
    console.log (`Gladiator expenses: ${totalPrice.toFixed(2)} aureus`);
}


solve (23,
    12.50,
    21.50,
    40,
    200);