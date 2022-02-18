window.addEventListener('load', solve);

function solve() {
    const productTypeField = document.getElementById('type-product');
    const descriptionField = document.getElementById('description');
    const clientNameField = document.getElementById('client-name');
    const clientPhoneField = document.getElementById('client-phone');
    const sendBtn = document.querySelector('form>button');
    const receivedOrdersSection = document.getElementById('received-orders');
    const completedOrdersSection = document.getElementById('completed-orders');
    const clearBtn = document.getElementsByClassName('clear-btn')[0];

    sendBtn.addEventListener('click', sendFunction);

    function sendFunction(ev) {
        const productType = productTypeField.value;
        const description = descriptionField.value;
        ev.preventDefault();
        const clientName = clientNameField.value;
        const clientPhone = clientPhoneField.value;

        
        if (description != '' && clientName != '' && clientPhone != '') {
            const startBtn = e('button', {class: 'start-btn'}, 'Start repair');
            const finishBtn = e('button', {class: 'finish-btn'}, 'Finish repair');
            finishBtn.disabled = true;
            
            const divContainer = e('div', { class: 'container' },
                e('h2', {}, 'Product type for repair: ' + productType),
                e('h3', {}, 'Client information: ' + clientName + ' ' + clientPhone),
                e('h4', {}, 'Description of the problem: ' + description),
                startBtn,
                finishBtn);

            receivedOrdersSection.appendChild(divContainer);

            descriptionField.value = '';
            clientNameField.value = '';
            clientPhoneField.value = '';

            startBtn.addEventListener('click', function () {
                startBtn.disabled = true;
                finishBtn.disabled = false;
            });

            finishBtn.addEventListener('click', function () {
                startBtn.remove();
                finishBtn.remove();
                completedOrdersSection.appendChild(divContainer);
            });

            clearBtn.addEventListener('click', function () {
                let childrenElements = Array.from(completedOrdersSection.children);

                for (let i = 3; i < childrenElements.length; i++) {
                    completedOrdersSection.removeChild(childrenElements[i]);
                }
            });
        }
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