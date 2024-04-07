function solve() {
   const addProductElements = document.querySelectorAll('.add-product');
   const textareaElement = document.querySelector('.shopping-cart textarea');
   const checkoutElement = document.querySelector('.checkout');

   let purchases = {};

   Array.from(addProductElements).forEach(addProductElement => {
      addProductElement.addEventListener('click', () => {
         const productElement = addProductElement
            .parentElement.parentElement;
         const productDetailsElement = productElement
            .querySelector('.product-details .product-title');
         const productPriceElement = productElement
            .querySelector('.product-line-price');

         if (!purchases[productDetailsElement.textContent]) {
            purchases[productDetailsElement.textContent] = Number(productPriceElement.textContent);
         } else {
            purchases[productDetailsElement.textContent] += Number(productPriceElement.textContent);
         }
         textareaElement.textContent += `Added ${productDetailsElement.textContent} for ${Number(productPriceElement.textContent).toFixed(2)} to the cart.\n`;
      });
   })

   checkoutElement.addEventListener('click', () => {
      const totalPrice = Object.values(purchases).reduce((a, b) => a + b, 0);
      const productsList = Object.keys(purchases).join(', ');
      textareaElement.textContent += `You bought ${productsList} for ${totalPrice.toFixed(2)}.\n`;
      
      Array.from(addProductElements).forEach(addProductElement => {
         addProductElement.setAttribute('disabled', 'disabled');
      })
      
      checkoutElement.setAttribute('disabled', 'disabled');
   });
}