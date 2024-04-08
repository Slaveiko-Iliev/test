function create(words, event) {
   const contentElement = document.getElementById('content');
   console.log(event);
   const divElements = words
      .map(word => {
         const pElement = document.createElement('p');
         pElement.textContent = word;
         pElement.style.display = 'none';

         const divElement = document.createElement('div');
         divElement.appendChild(pElement);

         // divElement.addEventListener('click', () => {
         //    pElement.style.display = 'block';
         // })

         return divElement;
      });

   // Attach multiple event listeners without event delegation
   // divElements
   //    .forEach(divElement => {
   //       divElement.addEventListener('click', (event) => {
   //          const pElement = divElement.querySelector('p');
   //          pElement.style.display = 'block';
   //       });
   //    });   

   // Append all to DOM
   // contentElement.append(...divElements); // Doesn't work in judge
   // divElements.forEach(divElement => contentElement.appendChild(divElement)); // Not efficient 
   // Using document fragment
   const divElementsFragment = document.createDocumentFragment();
   divElements.forEach(divElement => divElementsFragment.appendChild(divElement)); // Not efficient 
   contentElement.appendChild(divElementsFragment);

   // Attach "multiple" events using event delegation
   contentElement.addEventListener('click', (e) => {
      if (e.target.tagName === 'DIV') {
         const pElement = e.target.querySelector('p');
         pElement.style.display = 'block';
      }
   });
}

function originalCreate(words) {
   const contentElement = document.getElementById('content');

   const divElements = words
      .map(word => {
         const pElement = document.createElement('p');
         pElement.textContent = word;
         pElement.style.display = 'none';

         const divElement = document.createElement('div');
         divElement.appendChild(pElement);

         divElement.addEventListener('click', () => {
            pElement.style.display = 'block';
         });

         return divElement;
      });

   // Append all to DOM
   // contentElement.append(...divElements);
   divElements.forEach(divElement => contentElement.appendChild(divElement));
}
