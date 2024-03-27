function extract(content) {
    const contentElement = document.getElementById('content');

    const matches = contentElement.textContent.matchAll(/\(([a-zA-Z ]+)\)/g);
    
    const matchesArray = Array.from(matches);

    return matchesArray.join('; ');
}