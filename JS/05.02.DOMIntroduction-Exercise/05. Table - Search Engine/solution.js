function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let tbodyTrElementsAsArray = Array.from(document.querySelectorAll('tbody tr'));
      const searchFieldElement = document.getElementById('searchField');

      // console.log(searchFieldElement.value);
      
      for (const tr of tbodyTrElementsAsArray) {

         // console.log(tr);

         // const trTdAsArray = Array.from(tr);

         // console.log(trTdAsArray);

         for (const td of tr.children) {

            // console.log(td.textContent);

            if (td.textContent.toLowerCase().includes(searchFieldElement.value)){
               console.log('fffff');
            }
         }
      }
   }
}