function search() {
   const townsElement = document.getElementById('towns');
   const searchTextElement = document.getElementById('searchText');
   let resultElement = document.getElementById('result');

   let townsElementChildren = townsElement.children;
   let foundTown = 0;

   let townsElementChildrenArray = Array.from(townsElementChildren);

   for (const town of townsElementChildrenArray) {
      if(town.textContent.toLowerCase().includes(searchTextElement.value.toLowerCase())){
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
         foundTown ++;
      } else {
         town.style.fontWeight = 'normal';
         town.style.textDecoration = 'none';
      }
   }

   resultElement.textContent = `${foundTown} matches found`;
}
