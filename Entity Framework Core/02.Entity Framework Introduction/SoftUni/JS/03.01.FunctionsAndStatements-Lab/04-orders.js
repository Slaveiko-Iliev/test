function calculateTotalPrice (product, quantity) {
    let getPrice = function(){
        let price = 0;
        if (product === `coffee`){
            price = 1.5;
        } else if (product === `water`){
            price = 1;
        }else if (product === `coke`){
            price = 1.4;
        }else if (product === `snacks`){
            price = 2;
        }
        return price;
    }

    let totalPrice = getPrice() * quantity;

    return totalPrice.toFixed(2);
}

console.log (calculateTotalPrice("water", 5));
console.log (calculateTotalPrice("coffee", 2));