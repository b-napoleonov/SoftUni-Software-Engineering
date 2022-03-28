import { getAllAlbumsByName } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const searchTemplate = (onSearch, albumsByName, userData) => html`
<section id="searchPage">
    <h1>Search by Name</h1>

    <div class="search">
        <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
        <button @click=${onSearch} class="button-list">Search</button>
    </div>

    <h2>Results:</h2>

    ${albumsByName.length == 0
    ? html`<p class="no-result">No result.</p>`
    : albumsByName.map(album => cardBoxTemplate(album, userData))}
</section>`;

const cardBoxTemplate = (album, userData) => html`
<div class="card-box">
    <img src=${album.imgUrl}>
    <div>
        <div class="text-center">
            <p class="name">Name: ${album.name}</p>
            <p class="artist">Artist: ${album.artist}</p>
            <p class="genre">Genre: ${album.genre}</p>
            <p class="price">Price: $${album.price}</p>
            <p class="date">Release Date: ${album.releaseDate}</p>
        </div>
        ${userData 
            ? html`
                <div class="btn-group">
                    <a href="/details/${album._id}" id="details">Details</a>
                </div>`
            : null}
    </div>
</div>`;

export function searchPage(ctx) {
    let albumsByName = [];
    const userData = getUserData();

    ctx.render(searchTemplate(onSearch, albumsByName, userData));

    async function onSearch(){
        const searchInput = document.getElementById('search-input').value;

        albumsByName = await getAllAlbumsByName(searchInput);
        
        ctx.render(searchTemplate(onSearch, albumsByName, userData));
    }
}