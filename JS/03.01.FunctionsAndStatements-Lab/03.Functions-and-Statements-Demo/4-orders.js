

function solve(product, quantity) {
    const productPrice = getProductPrice(product);
    const totalPrice = productPrice * quantity;

    console.log(totalPrice.toFixed(2));
    
    function getProductPrice(product) {
        switch (product) {
            case 'coffee':
                return 1.5;
            case 'water':
                return 1;
            case 'coke':
                return 1.4;
            case 'snacks':
                return 2;
        }
    }
}

solve("water", 5);
