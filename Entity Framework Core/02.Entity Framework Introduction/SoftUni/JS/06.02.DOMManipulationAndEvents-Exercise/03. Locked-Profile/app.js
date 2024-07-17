function lockedProfile() {
    const mainElement = document.getElementById('main');

    mainElement.addEventListener('click', (e) => {
        const currentTarget = e.target.tagName.toLowerCase();
        const currentUnlockInput = e.target.parentElement.querySelector('input[value=unlock]');
        const currentLockInput = e.target.parentElement.querySelector('input[value=lock]');
        const currentUserHiddenFields = e.target.previousElementSibling;

         if (currentTarget == 'button' 
            && currentUnlockInput.checked
            && e.target.textContent === 'Show more') {
                currentUserHiddenFields.style.display = 'block';
                e.target.textContent = 'Hide it';
         } else if (currentTarget == 'button' 
         && currentUnlockInput.checked
         && e.target.textContent === 'Hide it') {
             currentUserHiddenFields.style.display = 'none';
             e.target.textContent = 'Show more';
      }
    });
}