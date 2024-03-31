function solve() {
  const inputElement = document.getElementById('input');
  const outputElement = document.getElementById('output');
  const sentencesArray = inputElement.value
    .split('.').filter(sentence => !!sentence);

  function makePElement(){
    let newP = document.createElement("P");
    newP.textContent = paragraph;
    outputElement.appendChild(newP);
  }

  let paragraph = ``;

  for (let i = 1; i <= sentencesArray.length; i++) {
    paragraph += `${sentencesArray[i-1].trim()}.`;

    if(i % 3 === 0){
      makePElement();
      paragraph = ``;
    }
  }

  if(paragraph.length > 0){
    makePElement();
  }

  inputElement.value = ``;
}