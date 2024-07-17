function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let trElements = document.querySelectorAll('table.container tbody tr');
      const searchFieldElement = document.getElementById('searchField');

      for (const trElement of trElements) {
         let isSelected = false;
         trElement.classList.remove("select");
         const tdElements = trElement.querySelectorAll('td');

         for (const td of tdElements) {

            if (td.textContent.toLowerCase().includes(searchFieldElement.value.toLowerCase())){
               isSelected = true;
               // tr.classList.add("select");
               break;
            }
         }

         if (isSelected) {
            trElement.className = 'select';
         }
      }

      searchFieldElement.value = '';
   }
}