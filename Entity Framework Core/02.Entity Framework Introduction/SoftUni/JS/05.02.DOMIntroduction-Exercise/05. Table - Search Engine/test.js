function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let trElements = document.querySelectorAll('tbody tr');
      const searchFieldElement = document.getElementById('searchField');

      for (const tr of trElements) {

         tr.classList.remove('select');
         
         for (const td of tr.children) {

            if (td.textContent.toLowerCase().includes(searchFieldElement.value.toLowerCase())){
               tr.classList.add('select');
            }
         }
      }
      searchFieldElement.value = '';
   }
}