import { getAllListings } from '../api/data.js';
import { html } from '../lib.js';

const listingsTemplate = (listings) => html`
<section id="car-listings">
    <h1>Car Listings</h1>
    <div class="listings">
        ${listings.length == 0
            ? html`<p class="no-cars">No cars in database.</p>` 
            : listings.map(car => listingCardTemplate(car))}
    </div>
</section>`;

const listingCardTemplate = (car) => html`
<div class="listing">
    <div class="preview">
        <img src=${car.imageUrl}>
    </div>
    <h2>${car.brand} ${car.model}</h2>
    <div class="info">
        <div class="data-info">
            <h3>Year: ${car.year}</h3>
            <h3>Price: ${car.price} $</h3>
        </div>
        <div class="data-buttons">
            <a href="/details/${car._id}" class="button-carDetails">Details</a>
        </div>
    </div>
</div>`;

export async function listingsPage(ctx) {
    const listings = await getAllListings();

    ctx.render(listingsTemplate(listings));
}