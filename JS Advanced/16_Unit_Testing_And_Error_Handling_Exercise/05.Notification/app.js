function notify(message) {
    let messageBox = document.getElementById('notification');
    messageBox.textContent = message;
    messageBox.style.display = 'block';
    messageBox.addEventListener('click', hide);

    function hide() {
        messageBox.style.display = 'none';
    }
}