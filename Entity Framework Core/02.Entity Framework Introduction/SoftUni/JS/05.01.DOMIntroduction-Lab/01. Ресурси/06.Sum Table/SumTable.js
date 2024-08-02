function sumTable() {
    const priceRows = document.querySelectorAll('td:nth-child(even):not(#sum)');
    const sumElement = document.getElementById('sum');
    let sum = 0;
    
    for (const row of priceRows) {
        sum += Number(row.textContent);
    }

    sumElement.textContent = sum;
}