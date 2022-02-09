function solution() {
    const addBtn = document.querySelector('.card button');
    const inputName = document.querySelector('.card input');
    const listOfGiftsUL = document.querySelectorAll('.card>ul')[0];
    const sendGiftUL = document.querySelectorAll('.card>ul')[1];
    const discardGiftUL = document.querySelectorAll('.card>ul')[2];

    addBtn.addEventListener('click', addCard);
    
    function addCard() {
        const sendBtn = e('button', {id: 'sendButton'}, 'Send');
        const discardBtn = e('button', {id: 'discardButton'}, 'Discard');

        const liElement = e('li', {class: 'gift'}, 
        inputName.value,
         sendBtn,
         discardBtn);
         
         inputName.value = '';
         listOfGiftsUL.appendChild(liElement);
         Array.from(listOfGiftsUL.getElementsByTagName('li'))
         .sort((a, b) => a.textContent.localeCompare(b.textContent))
         .forEach(li => listOfGiftsUL.appendChild(li));

         sendBtn.addEventListener('click', sendGift);

         function sendGift(e) {
            const gift = e.target.parentElement;
            sendGiftUL.appendChild(gift);
            gift.removeChild(e.target);
            gift.removeChild(discardBtn);
        }

         discardBtn.addEventListener('click', discardGift);

         function discardGift(e) {
            const gift = e.target.parentElement;
            discardGiftUL.appendChild(gift);
            gift.removeChild(e.target);
            gift.removeChild(sendBtn);
        }
    }
    
    function e(type, attr, ...content){
        const element = document.createElement(type);

        for (let prop in attr) {
            element.setAttribute(prop, attr[prop]);
        }

        for (let item of content) {
            if(typeof item === 'string' || typeof item === 'number'){
                item = document.createTextNode(item);
            }
            element.appendChild(item);
        }

        return element;
    }
}