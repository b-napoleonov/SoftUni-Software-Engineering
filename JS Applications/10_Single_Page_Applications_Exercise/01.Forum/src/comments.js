import { e } from './dom.js';

const main = document.querySelector('main');

export async function displayComments() {
    const commentsDiv = document.querySelector('.comment');

    try {
        const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments');
        const data = await response.json();

        if (response.status != 200) {
            throw new Error(data.message);
        }

        for (const comment in data) {
            commentsDiv.appendChild(e('div', { class: 'user-comment' },
                e('div', { class: 'header' },
                    e('img', { src: './static/profile.png', alt: 'avatar' }),
                    e('p', {},
                        e('strong', {}, `${data[comment].username}`), ' commented on ',
                        e('time', {}, data[comment].time)),
                    e('p', { class: 'post-content' }, data[comment].postText))));
        }
    } catch (error) {
        alert(error.message);
    }
}

export function viewCommentBox() {
    const formElement = e('form', {},
        e('textarea', { name: 'postText', placeholder: 'Write your comment here...', rows: '10', cols: '30' }),
        e('div', {},
            e('label', { class: 'red' }, 'Username: '),
            e('input', { name: 'username', type: 'text', placeholder: 'Username' })),
        e('button', { href: '#', class: 'submit' }, 'Post'));

    const mainDiv = e('div', { class: 'answer-comment' },
        e('p', {},
            e('span', {}, 'Current User  comment: ')),
        e('div', { class: 'answer' },
            formElement));

    main.appendChild(mainDiv);

    formElement.addEventListener('submit', postComment);
}

async function postComment(ev) {
    ev.preventDefault();
    let form = new FormData(ev.target);
    let commentForm = document.querySelector('.answer form');

    let username = form.get('username').trim();
    let postText = form.get('postText').trim();
    let time = new Date().toLocaleString();

    if (username == '' || postText == '') {
        return alert('Please fill the required fields!');
    }

    try {
        const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments', {
            method: 'POST',
            headers: {
                'Content-type': 'application/json',
            },
            body: JSON.stringify({ username, postText, time })
        });

        if (response.status != 200) {
            const data = await response.json();
            throw new Error(data.message);
        }

    } catch (error) {
        commentForm.reset();
        alert(error.message);
    }

    displayComments();
    commentForm.reset();
}