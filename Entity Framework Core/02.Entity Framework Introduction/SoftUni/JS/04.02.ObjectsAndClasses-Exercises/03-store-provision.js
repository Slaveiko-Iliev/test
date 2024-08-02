function solve(currentStock, productsForDelivery) {
    let stocksInStore = {};

    for (let i = 0; i < currentStock.length; i+=2) {
        stocksInStore[currentStock[i]] = Number([currentStock[i+1]]);
    }

    for (let i = 0; i < productsForDelivery.length; i+=2) {
        // if (Object.keys(stocksInStore).find(key => key === productsForDelivery[i])) {
        //     stocksInStore[productsForDelivery[i]] += Number(productsForDelivery[i+1]);
        // } else {
        //     stocksInStore[productsForDelivery[i]] = Number(productsForDelivery[i+1]);
        // }
        Object.keys(stocksInStore).find(key => key === productsForDelivery[i]) ?
            stocksInStore[productsForDelivery[i]] += Number(productsForDelivery[i+1])
            : stocksInStore[productsForDelivery[i]] = Number(productsForDelivery[i+1]);
    }

    for (const stock in stocksInStore) {
        console.log(`${stock} -> ${stocksInStore[stock]}`);
    }
}

solve([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
    'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
    );