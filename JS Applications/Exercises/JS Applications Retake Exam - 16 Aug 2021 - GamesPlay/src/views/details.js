import { createComment, deleteGame, getComments, getGameById } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const detailsTemplate = (game, userData, onDelete, comments, onSubmit) => html`
<section id="game-details">
    <h1>Game Details</h1>
    <div class="info-section">

        <div class="game-header">
            <img class="game-img" src=${game.imageUrl}/>
            <h1>${game.title}</h1>
            <span class="levels">MaxLevel: ${game.maxLevel}</span>
            <p class="type">${game.category}</p>
        </div>

        <p class="text">${game.summary}</p>

        <!-- Bonus ( for Guests and Users ) -->
        <div class="details-comments">
            <h2>Comments:</h2>
            <ul>
                ${comments.length == 0 
                    ? html`<p class="no-comment">No comments.</p>`
                    : comments.map(commentTemplate)}
            </ul>
        </div>

        ${userData && userData.id == game._ownerId 
        ? html`
            <div class="buttons">
                <a href="/edit/${game._id}" class="button">Edit</a>
                <a @click=${onDelete} href="javascript:void(0)" class="button">Delete</a>
            </div>` 
        : null}
    </div>

    <!-- Bonus -->
    ${userData && userData.id != game._ownerId 
    ? html`
        <article class="create-comment">
            <label>Add new comment:</label>
            <form @submit=${onSubmit} class="form">
                <textarea name="comment" placeholder="Comment......"></textarea>
                <input class="btn submit" type="submit" value="Add Comment">
            </form>
        </article>` 
    : null}
</section>`;

const commentTemplate = (comment) => html`
<li class="comment">
    <p>${comment.comment}</p>
</li>`;

export async function detailsPage(ctx) {
    const userData = getUserData();
    const game = await getGameById(ctx.params.id);
    const gameId = game._id;
    const comments = await getComments(gameId);

    ctx.render(detailsTemplate(game, userData, onDelete, comments, onSubmit));

    async function onDelete() {
        if (confirm('Are you sure you want to delete this game?')) {
            await deleteGame(gameId);
            ctx.page.redirect('/');
        }
    }

    async function onSubmit(ev){
        ev.preventDefault();

        const formData = new FormData(ev.target);
        const comment = formData.get('comment').trim();

        if (comment == '') {
            return alert('Please fill your comment!');
        }

        createComment({
            gameId,
            comment
        });

        ev.target.reset();

        ctx.page.redirect('/details/' + gameId);
    }
}