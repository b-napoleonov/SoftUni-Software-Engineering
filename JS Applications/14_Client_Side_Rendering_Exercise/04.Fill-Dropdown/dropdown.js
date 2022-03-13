import { render } from '../node_modules/lit-html/lit-html.js';
import { template } from './template.js';

const mainDiv = document.getElementById('menu');
document.querySelector('form').addEventListener('submit', addItem);

async function generateOptions() {
    const response = await fetch('http://localhost:3030/jsonstore/advanced/dropdown');
    const data = await response.json();

    render(template(Object.values(data)), mainDiv);
}

generateOptions();

async function addItem(ev) {
    ev.preventDefault();
    const textField = document.getElementById('itemText');
    const text = textField.value;

    try {
        const response = await fetch('http://localhost:3030/jsonstore/advanced/dropdown', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ text })
        });
        const data = await response.json();

        if (!response.ok || response.status != 200) {
            throw new Error(data.message);
        }

        generateOptions();
        textField.value = '';

    } catch (err) {
        alert(err.message);
    }
}