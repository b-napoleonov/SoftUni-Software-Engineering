function lockedProfile() {
    const buttons = Array.from(document.getElementsByTagName('button'));
    buttons.forEach(button => button.addEventListener('click', showHiddenFields));

    function showHiddenFields(e) {
        if (e.target.parentNode.children[2].checked) {
            return;
        }

        if (e.target.textContent === 'Show more') {
            e.target.parentNode.children[9].style.display = 'block';
            e.target.textContent = 'Hide it';
        }
        else {
            e.target.parentNode.children[9].style.display = 'none';
            e.target.textContent = 'Show more';
        }
    }
}