const url = 'http://localhost:3030/jsonstore/messenger';

function attachEvents() {
    const submitBtn = document.getElementById('submit');
    const refreshBtn = document.getElementById('refresh');

    submitBtn.addEventListener('click', submit);
    refreshBtn.addEventListener('click', refresh);
}
attachEvents();

async function submit() {
    const nameInput = document.querySelector('[name="author"]');
    const messageInput = document.querySelector('[name="content"]');

    const name = nameInput.value;
    const message = messageInput.value;

    const response = await fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            author: name,
            content: message
        })
    });

    await response.json();

    nameInput.value = '';
    messageInput.value = '';
}

async function refresh() {
    const messagesTextArea = document.getElementById('messages');
    messagesTextArea.value = '';

    try {
        const response = await fetch(url);

        if (response.status != 200) {
            throw new Error(`Error: ${response.status}`);
        }

        const data = await response.json();

        for (const message in data) {
            let author = data[message].author;
            let content = data[message].content;

            messagesTextArea.value += `${author}: ${content}\n`;
        }

    } catch (error) {
        alert(error);
    }
}