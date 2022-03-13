import { render } from './node_modules/lit-html/lit-html.js';
import { template } from './template.js';
import { towns } from './towns.js';

const mainDiv = document.querySelector('#towns');
const searchField = document.getElementById('searchText');
const resultDiv = document.getElementById('result');
document.querySelector('button').addEventListener('click', search);

render(template(towns), mainDiv);

function search() {
    const listItems = document.querySelectorAll('li');
    const searchedText = searchField.value;
    let count = 0;

    Object.values(listItems).forEach(item => {
        if (item.textContent.toLowerCase().includes(searchedText.toLowerCase())) {
            item.classList = 'active';
            count++;
        }else{
            item.classList = '';
        }
    });

    resultDiv.textContent = `${count} matches found`;
}