import { createItem } from '../api/data.js';
import { html } from '../lib.js';

const createTemplate = (onSubmit, errorMsg, errors) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Create New Furniture</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${onSubmit}>
    ${errorMsg ? html`<div class="form-group error">${errorMsg}</div>` : null}
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-make">Make</label>
                <input class=${errors.make ? "form-control" : "form-control is-invalid"} id="new-make" type="text"
                    name="make">
            </div>
            <div class="form-group has-success">
                <label class="form-control-label" for="new-model">Model</label>
                <input class=${errors.model ? "form-control" : "form-control is-invalid"} id="new-model"
                    type="text" name="model">
            </div>
            <div class="form-group has-danger">
                <label class="form-control-label" for="new-year">Year</label>
                <input class=${errors.year ? "form-control" : "form-control is-invalid"} id="new-year" type="number"
                    name="year">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-description">Description</label>
                <input class=${errors.description ? "form-control" : "form-control is-invalid"}
                    id="new-description" type="text" name="description">
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-price">Price</label>
                <input class=${errors.price ? "form-control" : "form-control is-invalid"} id="new-price"
                    type="number" name="price">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-image">Image</label>
                <input class=${errors.img ? "form-control" : "form-control is-invalid"} id="new-image" type="text"
                    name="img">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-material">Material (optional)</label>
                <input class="form-control" id="new-material" type="text" name="material">
            </div>
            <input type="submit" class="btn btn-primary" value="Create" />
        </div>
    </div>
</form>`;

export function createPage(ctx) {
    update(null, {});

    function update(errorMsg, errors) {
        ctx.render(createTemplate(onSubmit, errorMsg, errors));
    }

    async function onSubmit(ev) {
        ev.preventDefault();

        const formData = new FormData(ev.target);
        const make = formData.get('make').trim();
        const model = formData.get('model').trim();
        const year = Number(formData.get('year').trim());
        const description = formData.get('description').trim();
        const price = Number(formData.get('price').trim());
        const img = formData.get('img').trim();
        const material = formData.get('material').trim();
        let validationData = {
            make : (make == '' || make.length < 4) ? false : true,
            model : (model == '' || model.length < 4) ? false : true,
            year : (year < 1950 || year > 2050) ? false : true,
            description : (description == '' || description.length < 10) ? false : true,
            price : (price <= 0) ? false : true,
            img : img == '' ? false : true
        };

        try {
            if (Object.values(validationData).some(x => x == false)) {
                throw {
                    error: new Error('Please fill all required fields correctly.'),
                    validationData
                };
            }

            const data = {
                make,
                model,
                year,
                description,
                price,
                img,
                material
            }
            const result = await createItem(data);
            ev.target.reset();
            ctx.page.redirect('/details/' + result._id);

        } catch (err) {
            update(err.error.message, err.validationData);
        }
    }
}