import { render } from './node_modules/lit-html/lit-html.js';
import { template } from './template.js';

const rootDiv = document.getElementById('root');
document.querySelector('form').addEventListener('submit', onSubmit);

function onSubmit(ev) {
    ev.preventDefault();

    const input = document.querySelector('input');
    const value = input.value.split(', ');
    input.value = '';
    
    render(template(value), rootDiv);
}