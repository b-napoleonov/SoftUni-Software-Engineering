const postsSelect = document.getElementById('posts');
const postsObj = {};

function attachEvents() {
    const loadPostsBtn = document.getElementById('btnLoadPosts');
    const viewPostsBtn = document.getElementById('btnViewPost');

    loadPostsBtn.addEventListener('click', loadPosts);
    viewPostsBtn.addEventListener('click', viewPosts);
}
attachEvents();

async function loadPosts() {
    try {
        const response = await fetch(`http://localhost:3030/jsonstore/blog/posts`);

        if (response.status !== 200) {
            throw new Error(`Error ${response.status}: ${response.statusText}. Refresh and try again`);
        }

        const posts = await response.json();

        for (const post in posts) {
            const option = e('option', { value: posts[post].id }, posts[post].title);
            postsSelect.appendChild(option);
            postsObj[posts[post].id] = posts[post].body;
        }

    } catch (error) {
        const h1Element = e('h1', {}, error.message);
        document.body.appendChild(h1Element);
    }
}

async function viewPosts(ev) {
    const selectedPostTitle = postsSelect.options[postsSelect.selectedIndex].text;
    const selectedId = postsSelect.options[postsSelect.selectedIndex].value;
    const postTitleH1 = document.getElementById('post-title');
    const postCommentsUl = document.getElementById('post-comments');

    try {
        postCommentsUl.innerHTML = '';

        const response = await fetch(`http://localhost:3030/jsonstore/blog/comments`);

        if (response.status !== 200) {
            throw new Error(`Error ${response.status}: ${response.statusText}. Refresh and try again`);
        }

        const comments = await response.json();

        const commentsForSelectedPost = [];
        for (const comment in comments) {
            if (comments[comment].postId === selectedId) {
                commentsForSelectedPost.push(comments[comment]);
            }
        }
        postTitleH1.textContent = selectedPostTitle;
        const pBody = e('p', { id: 'post-body' }, postsObj[selectedId]);

        if (postTitleH1.nextElementSibling.tagName != 'P') {
            postTitleH1.after(pBody);
        }
        else {
            postTitleH1.nextElementSibling.textContent = postsObj[selectedId];
        }

        commentsForSelectedPost.forEach(comment => {
            const li = e('li', { id: `comment-${comment.id}` }, comment.text);
            postCommentsUl.appendChild(li);
        });

    } catch (error) {
        const h1Element = e('h1', {}, error.message);
        document.body.appendChild(h1Element);
    }
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