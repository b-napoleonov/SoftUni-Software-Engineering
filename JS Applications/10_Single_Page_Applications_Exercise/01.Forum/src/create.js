import { displayTopics } from './topics.js';

const form = document.getElementById('postForm');

export async function createPost(event) {
    event.preventDefault();
    const formData = new FormData(form);

    let topicName = formData.get('topicName').trim();
    let username = formData.get('username').trim();
    let postText = formData.get('postText').trim();
    let time = new Date().toLocaleString();
    
    if (topicName == '' || username == '' || postText == '') {
        return alert('Please fill the required fields!');
    }

    const bodyObj = {
        topicName,
        username,
        postText,
        time
    }

    try {
        const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts', {
            method: 'POST',
            headers: {
                'Content-type': 'application/json',
            },
            body: JSON.stringify(bodyObj)
        });

        if (response.status != 200) {
            const data = await response.json();
            throw new Error(data.message);
        }

        displayTopics();

    } catch (error) {
        form.reset();
        alert(error.message);
    }

    form.reset();
}

export async function cancelInputs(event) {
    event.preventDefault();
    form.reset();
}