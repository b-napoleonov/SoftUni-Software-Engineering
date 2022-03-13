import { html } from './node_modules/lit-html/lit-html.js';

export let template = (towns) => html`
<ul>
    ${towns.map(town => html`<li>${town}</li>`)}
</ul>
`;