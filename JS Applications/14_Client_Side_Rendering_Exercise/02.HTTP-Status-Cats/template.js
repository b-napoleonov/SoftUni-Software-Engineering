import { html } from './node_modules/lit-html/lit-html.js';
import { cats } from './catSeeder.js';

export const template = () => html`
<ul>
    ${cats.map(cat => html`
    <li>
        <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
        <div class="info">
            <button @click=${showDetails} class="showBtn">Show status code</button>
            <div class="status" style="display: none" id=${cat.id}>
                <h4>Status Code: ${cat.statusCode}</h4>
                <p>${cat.statusMessage}</p>
            </div>
        </div>
    </li>`)}
</ul>
`;

function showDetails(ev){
    const statusDiv = ev.target.nextElementSibling;

    if(statusDiv.style.display === 'none'){
        statusDiv.style.display = 'block';
        ev.target.textContent = 'Hide status code';
    }
    else{
        statusDiv.style.display = 'none';
        ev.target.textContent = 'Show status code';
    }
}