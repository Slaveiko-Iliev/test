function search() {
   const townsElementChildren = document.getElementById('towns').children;
   const searchTextElement = document.getElementById('searchText');

   townsElements.style.fontWeight = 'normal';

   townsElementChildren.forEach(element => {
      element
      .textContent.includes(searchTextElement.value)
      .style.fontWeight = 'normal'
   });

}
