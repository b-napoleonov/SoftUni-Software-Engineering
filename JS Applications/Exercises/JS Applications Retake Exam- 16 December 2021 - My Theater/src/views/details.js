import { deleteTheater, getLikes, getTheaterById, likedBy, likeTheater } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const detailsTemplate = (theater, onDelete, userData, onLike, allLikes, alreadyLiked) => html`
<section id="detailsPage">
    <div id="detailsBox">
        <div class="detailsInfo">
            <h1>Title: ${theater.title}</h1>
            <div>
                <img src=${theater.imageUrl}/>
            </div>
        </div>

        <div class="details">
            <h3>Theater Description</h3>
            <p>${theater.description}</p>
            <h4>Date: ${theater.date}</h4>
            <h4>Author: ${theater.author}</h4>
            <div class="buttons">
                ${userData && userData.id == theater._ownerId 
                    ? html`
                        <a @click=${onDelete} class="btn-delete" href="javascript:void(0)">Delete</a>
                        <a class="btn-edit" href="/edit/${theater._id}">Edit</a>`
                    : null}
                    ${userData && userData.id != theater._ownerId && alreadyLiked == 0
                        ? html`<a @click=${onLike} class="btn-like" href="javascript:void(0)">Like</a>`
                        : null}
            </div>
            <p id="likes" class="likes">Likes: ${allLikes}</p>
        </div>
    </div>
</section>`;

export async function detailsPage(ctx) {
    const theater = await getTheaterById(ctx.params.id);
    const userData = getUserData();
    let allLikes = await getLikes(theater._id);
    const alreadyLiked = await likedBy(theater._id, userData.id);

    ctx.render(detailsTemplate(theater, onDelete, userData, onLike, allLikes, alreadyLiked));

    async function onDelete(){
        if (confirm('Are you sure you want to delete this theater?')) {
            await deleteTheater(ctx.params.id);
            ctx.page.redirect('/profile');
        }
    }

    async function onLike(ev){
        ev.target.style.display = 'none';
        const theaterId = ctx.params.id;

        likeTheater({theaterId});

        allLikes++;

        document.getElementById('likes').textContent = `Likes: ${allLikes}`;
    }
}