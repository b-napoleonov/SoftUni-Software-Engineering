import { e } from './dom.js';
import { displayComments, viewCommentBox } from './comments.js';

const main = document.querySelector('main');
const topicContainerDiv = document.querySelector('.topic-container');
const homepageDiv = document.getElementById('homepage');

export async function displayTopics() {
    topicContainerDiv.replaceChildren();

    try {
        const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts');
        const data = await response.json();

        if (response.status != 200) {
            throw new Error(data.message);
        }

        for (let item in data) {
            const topicNameDiv = e('div', { class: 'topic-name-wrapper' },
                e('div', { class: 'topic-name' },
                    e('a', { href: '#', class: 'normal' },
                        e('h2', { 'data-id': data[item]._id }, data[item].topicName)),
                    e('div', { class: 'columns' },
                        e('p', {}, 'Date: ',
                            e('time', {}, data[item].time))),
                    e('div', { class: 'nick-name' },
                        e('p', {}, 'Username: ',
                            e('span', {}, data[item].username)))));

            topicContainerDiv.appendChild(topicNameDiv);
            topicNameDiv.addEventListener('click', viewTopic);
        }
    } catch (error) {
        alert(error.message);
    }
}

async function viewTopic(ev) {
    if (ev.target.tagName == 'H2') {
        const targetId = ev.target.getAttribute('data-id');
        main.replaceChildren();
        homepageDiv.style.display = 'none';

        try {
            const response = await fetch(`http://localhost:3030/jsonstore/collections/myboard/posts/${targetId}`);
            const data = await response.json();

            if (response.status != 200) {
                throw new Error(error.message);
            }

            main.appendChild(e('h2', {}, data.topicName));

            const commentDiv = e('div', { class: 'comment' },
                e('div', { class: 'header' },
                    e('img', { src: './static/profile.png', alt: 'avatar' }),
                    e('p', {},
                        e('span', {}, `${data.username}`), ' posted on ',
                        e('time', {}, data.time)),
                    e('p', { class: 'post-content' }, data.postText)));

            main.appendChild(commentDiv);

        } catch (error) {
            alert(error.message);
        }

        viewCommentBox();
        displayComments();
    }
}