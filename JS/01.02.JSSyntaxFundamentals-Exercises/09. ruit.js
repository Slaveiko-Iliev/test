function solve(fruit, quantity, price) {
    let money = quantity / 1000 * price;

    console.log (`I need ${money.toFixed(2)} to buy ${(quantity / 1000).toFixed(2)} kilograms ${fruit}.`);
}   

solve ('orange', 2500, 1.80);
solve ('apple', 1563, 2.35);