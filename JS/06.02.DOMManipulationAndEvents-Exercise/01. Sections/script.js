function create(words) {
   const contentElement = document.getElementById('content');

   for (const word of words) {
      const divElement = document.createElement('div');
      const pElement = document.createElement('p');
      pElement.textContent = word;
      divElement.appendChild(pElement);
      contentElement.appendChild(divElement);
   }

   console.log(contentElement);
}