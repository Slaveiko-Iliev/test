function colorize() {
    const evenTrElements = document.querySelectorAll('table tr:nth-child(even)'); 
    
    for (const tr of evenTrElements) {
        tr.style.backgroundColor = 'teal';
    }
}