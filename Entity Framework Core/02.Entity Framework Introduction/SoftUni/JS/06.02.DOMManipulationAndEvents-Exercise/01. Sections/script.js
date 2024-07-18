function create(words) {
   const contentElement = document.getElementById('content');

   for (const word of words) {
      const pElement = document.createElement('p');
      pElement.textContent = word;
      pElement.style.display = 'none';
      

      const divElement = document.createElement('div');
      divElement.appendChild(pElement);

      divElement.addEventListener('click', () => {
         pElement.style.display = 'block';
      });

      contentElement.appendChild(divElement);
   }
}