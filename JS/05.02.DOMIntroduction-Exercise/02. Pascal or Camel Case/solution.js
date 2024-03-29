function solve() {
  let textAsArray = document
    .getElementById('text')
    .value.toLowerCase()
    .split(' ');

  const convention = document.getElementById('naming-convention').value;
  const resultElement = document.getElementById('result');

  function upperFirstLowerRest(inputAsArray) {
    for (let i = 0; i < textAsArray.length; i++) {
      let firstLetter = textAsArray[i].slice(0, 1).toUpperCase();
      let restOfWord = textAsArray[i].slice(1).toLowerCase();
      
      textAsArray[i] = firstLetter += restOfWord;
    }
  }

  
  if(convention === 'Camel Case'){
    upperFirstLowerRest(textAsArray);
    textAsArray[0] = textAsArray[0].toLowerCase();
    resultElement.textContent = textAsArray.join('');
  }else if(convention === 'Pascal Case'){
    upperFirstLowerRest(textAsArray);
    resultElement.textContent = textAsArray.join('');
  }else{
    resultElement.textContent = `Error!`
  }
}