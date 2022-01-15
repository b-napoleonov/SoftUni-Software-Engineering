function focused() {
    const mainDiv = document.getElementsByTagName('div')[0];
    const mainDivArray = Array.from(mainDiv.children);

    for (const div of mainDivArray) {
        div.children[1].addEventListener('focus', onFocus);
        div.children[1].addEventListener('blur', onBlur);
    }

    function onFocus(event) {
        event.target.parentNode.classList.add('focused');
    }

    function onBlur(event) {
        event.target.parentNode.classList.remove('focused');
    }
}