import { editMeme, getMeme } from '../api/data.js';
import { html } from '../lib.js';
import { notify } from '../util.js';

const editTemplate = (onSubmit, meme) => html`
<section id="edit-meme">
    <form @submit=${onSubmit} id="edit-form">
        <h1>Edit Meme</h1>
        <div class="container">
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title" .value=${meme.title}>
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description">${meme.description}</textarea>
            <label for="imageUrl">Image Url</label>
            <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" .value=${meme.imageUrl}>
            <input type="submit" class="registerbtn button" value="Edit Meme">
        </div>
    </form>
</section>`;

export async function editPage(ctx) {
    const meme = await getMeme(ctx.params.id);
    ctx.render(editTemplate(onSubmit, meme));

    async function onSubmit(ev) {
        ev.preventDefault();

        const formData = new FormData(ev.target);
        const title = formData.get('title').trim();
        const description = formData.get('description').trim();
        const imageUrl = formData.get('imageUrl').trim();

        if (title == '' || description == '' || imageUrl == '') {
            return notify('Please fill all fields');
        }

        editMeme(ctx.params.id, {
            title,
            description,
            imageUrl
        });

        ctx.page.redirect('/details/' + ctx.params.id);
    }
}