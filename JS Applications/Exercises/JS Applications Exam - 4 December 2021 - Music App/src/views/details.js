import { deleteAlbum, getAlbumById } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const detailsTemplate = (album, onDelete, userData) => html`
<section id="detailsPage">
    <div class="wrapper">
        <div class="albumCover">
            <img src=${album.imgUrl}>
        </div>
        <div class="albumInfo">
            <div class="albumText">

                <h1>Name: ${album.name}</h1>
                <h3>Artist: ${album.artist}</h3>
                <h4>Genre: ${album.genre}</h4>
                <h4>Price: $${album.price}</h4>
                <h4>Date: ${album.releaseDate}</h4>
                <p>Description: ${album.description}</p>
            </div>
            ${userData && userData.id == album._ownerId
                ? html`
                    <div class="actionBtn">
                        <a href="/edit/${album._id}" class="edit">Edit</a>
                        <a @click=${onDelete} href="javascript:void(0)" class="remove">Delete</a>
                    </div>`
                : null}
        </div>
    </div>
</section>`;

export async function detailsPage(ctx) {
    const album = await getAlbumById(ctx.params.id);
    const userData = getUserData();

    ctx.render(detailsTemplate(album, onDelete, userData));

    async function onDelete() {
        if (confirm('Are you sure you want to delete this meme?')) {
            await deleteAlbum(ctx.params.id);
            ctx.page.redirect('/catalog');
        }
    }
}