function toggle() {
    let moreElement = document.querySelector('div.head span.button');
    const extraElement = document.getElementById('extra');

    if (moreElement.textContent === `More`){
        extraElement.style.display = 'block';
        moreElement.textContent = `Less`;
    } else if (moreElement.textContent === `Less`) {
        extraElement.style.display = 'none';
        moreElement.textContent = `More`;
    }
}