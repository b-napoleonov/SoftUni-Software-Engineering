import { deleteListing, getListingById } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const detailsTemplate = (car, onDelete, userData) => html`
<section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        <img src=${car.imageUrl}>
        <hr>
        <ul class="listing-props">
            <li><span>Brand:</span>${car.brand}</li>
            <li><span>Model:</span>${car.model}</li>
            <li><span>Year:</span>${car.year}</li>
            <li><span>Price:</span>${car.price}$</li>
        </ul>

        <p class="description-para">${car.description}</p>

        <div class="listings-buttons">
            ${userData && userData.id == car._ownerId 
                ? html`
                    <a href="/edit/${car._id}" class="button-list">Edit</a>
                    <a @click=${onDelete} href="javascript:void(0)" class="button-list">Delete</a>`
                : null}
        </div>
    </div>
</section>`;

export async function detailsPage(ctx) {
    const car = await getListingById(ctx.params.id);
    const userData = getUserData();

    ctx.render(detailsTemplate(car, onDelete, userData));

    async function onDelete() {
        if (confirm('Are you sure you want to delete this listing?')) {
            await deleteListing(car._id);
            ctx.page.redirect('/listings');
        }
    }
}