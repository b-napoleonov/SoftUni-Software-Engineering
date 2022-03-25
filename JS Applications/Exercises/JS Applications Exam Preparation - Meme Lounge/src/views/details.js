import { deleteMeme, getMeme } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const detailsTemplate = (meme, onDelete, userData) => html`
<section id="meme-details">
    <h1>Meme Title: ${meme.title}</h1>
    <div class="meme-details">
        <div class="meme-img">
            <img alt="meme-alt" src=${meme.imageUrl}>
        </div>
        <div class="meme-description">
            <h2>Meme Description</h2>
            <p>
                ${meme.description}
            </p>

            ${(userData && userData.id == meme._ownerId) 
            ? html`
                <a class="button warning" href="/edit/${meme._id}">Edit</a>
                <button @click=${onDelete} class="button danger">Delete</button>`
            : null}

        </div>
    </div>
</section>`;

export async function detailsPage(ctx) {
    const meme = await getMeme(ctx.params.id);
    const userData = getUserData();

    ctx.render(detailsTemplate(meme, onDelete, userData));

    async function onDelete(ev) {
        ev.preventDefault();

        if (confirm('Are you sure you want to delete this meme?')) {
            await deleteMeme(ctx.params.id);
            ctx.page.redirect('/memes');
        }
    }
}