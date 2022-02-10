function solution() {
    const giftName = document.querySelectorAll('.card')[0].children[1].children[0];
    const addBtn = document.querySelectorAll('.card')[0].children[1].children[1];
    const giftListUL = document.querySelectorAll('.card')[1].children[1];
    const sendGiftsListUL = document.querySelectorAll('.card')[2].children[1];
    const discardedGiftsUL = document.querySelectorAll('.card')[3].children[1];

    addBtn.addEventListener('click', addGift);

    function addGift() {
        const sendBtn = e('button', { id: 'sendButton' }, 'Send');
        const discardBtn = e('button', { id: 'discardButton' }, 'Discard');

        const liElement = e('li', { class: 'gift' }, giftName.value,
            sendBtn,
            discardBtn);

        giftName.value = '';
        giftListUL.appendChild(liElement);

        Array.from(giftListUL.getElementsByTagName('li'))
        .sort((a, b) => a.textContent.localeCompare(b.textContent))
        .forEach(li => giftListUL.appendChild(li));

        sendBtn.addEventListener('click', sendGift.bind(null, liElement));
        discardBtn.addEventListener('click', discardGift.bind(null, liElement));
    }

    function sendGift(liElement) {
        liElement.removeChild(liElement.children[0]);
        liElement.removeChild(liElement.children[0]);
        sendGiftsListUL.appendChild(liElement);
    }

    function discardGift(liElement) {
        liElement.removeChild(liElement.children[0]);
        liElement.removeChild(liElement.children[0]);
        discardedGiftsUL.appendChild(liElement);
    }

    function e(type, attr, ...content) {
        const element = document.createElement(type);

        for (let prop in attr) {
            element.setAttribute(prop, attr[prop]);
        }

        for (let item of content) {
            if (typeof item === 'string' || typeof item === 'number') {
                item = document.createTextNode(item);
            }
            element.appendChild(item);
        }

        return element;
    }
}