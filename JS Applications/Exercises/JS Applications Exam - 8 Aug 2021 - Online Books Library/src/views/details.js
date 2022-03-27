import { addLike, deleteBook, getBook, getSpecificLike, getTotalLikes } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const detailsTemplate = (book, onDelete, userData, totalLikes, onLike, specificUserLike) => html`
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${book.title}</h3>
        <p class="type">Type: ${book.type}</p>
        <p class="img"><img src=${book.imageUrl}></p>
        <div class="actions">
            ${userData && userData.id == book._ownerId
            ? html`
                <a class="button" href="/edit/${book._id}">Edit</a>
                <a @click=${onDelete} class="button" href="javascript:void(0)">Delete</a>`
            : null}

            <!-- Bonus -->
            ${userData && userData.id != book._ownerId && !specificUserLike
                ? html`<a @click=${onLike} class="button" href="javascript:void(0)">Like</a>`
                : null}
            <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->

            <!-- ( for Guests and Users )  -->
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: ${totalLikes}</span>
            </div>
            <!-- Bonus -->
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${book.description}</p>
    </div>
</section>`;

export async function detailsPage(ctx) {
    const book = await getBook(ctx.params.id);
    const userData = getUserData();
    let totalLikes = await getTotalLikes(ctx.params.id);
    let specificUserLike;

    if (userData) {
        specificUserLike = await getSpecificLike(ctx.params.id, userData.id);
    }

    ctx.render(detailsTemplate(book, onDelete, userData, totalLikes, onLike, specificUserLike));

    async function onDelete(ev){
        ev.preventDefault();

        if(confirm('Are you sure you want to delete this book?')){
            await deleteBook(ctx.params.id);
            ctx.page.redirect('/');
        }
    }

    async function onLike(ev){
        ev.preventDefault();
        const bookId = ctx.params.id;

        await addLike({bookId});
        
        totalLikes++;
        specificUserLike = await getSpecificLike(ctx.params.id, userData.id);
        ctx.page.redirect('/details/' + ctx.params.id);
    }
}