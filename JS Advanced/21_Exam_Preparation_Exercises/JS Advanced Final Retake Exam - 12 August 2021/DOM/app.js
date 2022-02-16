window.addEventListener('load', solve);
//1 wrong test in judge
function solve() {
    const modelField = document.getElementById('model');
    const yearField = document.getElementById('year');
    const descriptionField = document.getElementById('description');
    const priceField = document.getElementById('price');
    const addBtn = document.getElementById('add');
    const inputForm = document.querySelector('form');
    const tBody = document.getElementById('furniture-list');
    const totalPriceElement = document.querySelector('.total-price');

    console.log(totalPriceElement);

    addBtn.addEventListener('click', function (ev) {
        ev.preventDefault();
        const model = modelField.value;
        const year = yearField.value;
        const description = descriptionField.value;
        let price = priceField.value;
        price = Number(price).toFixed(2);

        let isValidInput = model !== '' && year !== '' && description !== '' && price !== '' && price > 0 && year > 0;

        if (isValidInput) {
            const moreBtn = e('button', { class: 'moreBtn' }, 'More Info');
            const buyBtn = e('button', { class: 'buyBtn' }, 'Buy it');

            const trInfoElement = e('tr', { class: 'info' },
                e('td', {}, model),
                e('td', {}, price),
                e('td', {},
                    moreBtn,
                    buyBtn));

            const trHideElement = e('tr', { class: 'hide' },
                e('td', {}, 'Year: ' + year),
                e('td', { colspan: 3 }, 'Description: ' + description));

            tBody.appendChild(trInfoElement);
            tBody.appendChild(trHideElement);

            inputForm.reset();

            moreBtn.addEventListener('click', function (ev) {
                if (moreBtn.textContent == 'More Info') {
                    moreBtn.textContent = 'Less Info';
                    trHideElement.style.display = 'contents';
                }
                else {
                    moreBtn.textContent = 'More Info';
                    trHideElement.style.display = 'none';
                }
            });

            buyBtn.addEventListener('click', function (ev) {
                const price = Number(ev.target.parentElement.previousElementSibling.textContent);
                totalPriceElement.textContent = Number(totalPriceElement.textContent) + price;
                ev.target.parentElement.parentElement.nextElementSibling.remove();
                ev.target.parentElement.parentElement.remove();
            });
        }
    });

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
