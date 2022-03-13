import { render } from './node_modules/lit-html/lit-html.js';
import { cats } from './catSeeder.js';
import { template } from './template.js';

const castsSection = document.getElementById('allCats');
const result = cats.map(template);

render(template(result), castsSection);