function deleteByEmail() {
    const tbodyTrElement = document.querySelectorAll('#customers tbody tr');
    console.log(tbodyTrElement);
    const inputElement = document.querySelector('input');
    console.log(inputElement.value);
    const resultElement = document.getElementById('result');
    let isFound = false;

    for (const row of Array.from(tbodyTrElement)) {
        console.log(row);
        if (inputElement.value === row[1]){
            console.log(row[1]);
            tbodyTrElement.remove(row);
            isFound = true;
            resultElement.textContent = `Deleted.`;
        }
    }
    
    if (!isFound){
        resultElement.textContent = `Not found.`;
    }
}