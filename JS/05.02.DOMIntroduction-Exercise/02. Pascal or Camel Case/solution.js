function solve() {
  const textAsArray = document
    .getElementById('text')
    .value.toLowerCase()
    .split(' ');

  for (let i = 1; i < textAsArray.length; i++) {
    const firstLetter = textAsArray[i].slice(0, 1).toUpperCase();
    
    console.log(firstLetter);

    console.log(textAsArray);
  }
  
  
  const convention = document.getElementById('naming-convention').value;
  
  console.log(convention);
}