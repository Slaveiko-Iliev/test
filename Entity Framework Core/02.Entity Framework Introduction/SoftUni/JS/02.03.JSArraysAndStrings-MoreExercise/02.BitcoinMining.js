function solve(amountOfGold) {
    const priceOfBitcoin = 11949.16;
    const priceOfGold = 67.51;
    let boughtBitcoins = 0;
    let firstPurchasedDay = 0;
    let leftMoney = 0;
    
    for (let i = 1; i <= amountOfGold.length; i++) {
        leftMoney += amountOfGold[i - 1] * priceOfGold;
        if (i % 3 === 0){
            leftMoney -= amountOfGold[i - 1]*0.3*priceOfGold;
        }
        if (firstPurchasedDay === 0 && leftMoney >= priceOfBitcoin){
            firstPurchasedDay = i;
            while (leftMoney >= priceOfBitcoin) {
                boughtBitcoins++;
                leftMoney-=priceOfBitcoin;
                }
        } else if (leftMoney >= priceOfBitcoin){
            while (leftMoney >= priceOfBitcoin) {
            boughtBitcoins++;
            leftMoney-=priceOfBitcoin;
            }
        }
    }

    console.log (`Bought bitcoins: ${boughtBitcoins}`);
    if (firstPurchasedDay > 0){
        console.log (`Day of the first purchased bitcoin: ${firstPurchasedDay}`);
    }
    console.log (`Left money: ${leftMoney.toFixed(2)} lv.`);
}

// solve ([100, 200, 300]);
// solve ([50, 100]);
solve ([3124.15, 504.212, 2511.124]);