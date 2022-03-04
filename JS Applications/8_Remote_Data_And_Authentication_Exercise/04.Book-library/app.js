const url = `http://localhost:3030/jsonstore/collections/books/`;
const form = document.querySelector('form');
const formH3Element = document.querySelector('form > h3');
const formBtnElement = document.querySelector('form button');
let targetId = '';
window.onload = attachEvents;

function attachEvents() {
    let loadBtn = document.querySelector('#loadBooks');

    loadBtn.addEventListener('click', loadBooks);
    form.addEventListener('submit', createOrSave);

    loadBooks();
}

attachEvents();

async function loadBooks() {
    const tBodyElement = document.querySelector('tbody');
    tBodyElement.innerHTML = '';

    try {
        const response = await fetch(`${url}`);

        if (response.status != 200) {
            const error = await response.json();
            throw new Error(error.message);
        }

        const data = await response.json();

        Object.entries(data).forEach(([key, info]) => {
            const editBtn = e('button', {}, 'Edit');
            const deleteBtn = e('button', {}, 'Delete');

            const trElement = e('tr', { id: key },
                e('td', {}, info.title),
                e('td', {}, info.author),
                e('td', {},
                    editBtn,
                    deleteBtn));

            tBodyElement.appendChild(trElement);

            editBtn.addEventListener('click', editForm);
            deleteBtn.addEventListener('click', deleteBook);
        });

    } catch (error) {
        alert(error.message);
    }
}

async function editForm(ev) {
    ev.preventDefault();
    targetId = ev.target.parentNode.parentNode.getAttribute('id');

    const response = await fetch(`${url}${targetId}`);
    const data = await response.json();

    formH3Element.textContent = 'Edit Form';
    formBtnElement.textContent = 'Save';

    document.querySelector('[name="title"]').value = data.title;
    document.querySelector('[name="author"]').value = data.author;
}

async function createOrSave(ev) {
    ev.preventDefault();

    let formData = new FormData(ev.target)
    let title = formData.get('title').trim();
    let author = formData.get('author').trim();

    if (title === '' || author === '') {
        alert('Please fill all fields!');
        return;
    }

    if (formBtnElement.textContent == 'Save') {
        await fetch(`${url}${targetId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ title, author })
        })

        formH3Element.textContent = 'FORM';
        formBtnElement.textContent = 'Submit';

    }
    else {
        await fetch(`${url}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ title, author })
        })
    }

    form.reset();
    loadBooks()
}

async function deleteBook(ev) {
    let targetId = ev.target.parentNode.parentNode.getAttribute('id');

    await fetch(`${url}${targetId}`, {
        method: 'DELETE'
    });

    loadBooks();
}

function e(type, attr, ...content) {
    const element = document.createElement(type);

    for (let prop in attr) {
        element.setAttribute(prop, attr[prop]);
    }

    for (let item of content) {
        if (typeof item === 'string' || typeof item === 'number') {
            item = document.createTextNode(item);
        }
        element.appendChild(item);
    }

    return element;
}