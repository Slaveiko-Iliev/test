function deleteByEmail() {
    const tbodyTrElement = document.querySelectorAll('#customers tbody tr');
    console.log(tbodyTrElement);
    const inputElement = document.querySelector('input');
    console.log(inputElement.value);
    const resultElement = document.getElementById('result');
    let isFound = false;

    for (const row of Array.from(tbodyTrElement)) {
        console.log(row);
        
        const tdElementsOfrow = row.querySelectorAll('td');

        for (const td of Array.from(tdElementsOfrow)) {
            if (inputElement.value === td.textContent){
                console.log(td.textContent);
                row.remove();
                isFound = true;
                resultElement.textContent = `Deleted.`;
            }
        }
    }
    
    if (!isFound){
        resultElement.textContent = `Not found.`;
    }

    inputElement.value= '';
}