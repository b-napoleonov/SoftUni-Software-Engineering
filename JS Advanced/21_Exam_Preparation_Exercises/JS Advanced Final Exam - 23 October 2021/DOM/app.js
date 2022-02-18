window.addEventListener('load', solve);

function solve() {
    const genreField = document.getElementById('genre');
    const nameField = document.getElementById('name');
    const authorField = document.getElementById('author');
    const dateField = document.getElementById('date');
    const addBtn = document.getElementById('add-btn');
    const allHitsDiv = document.querySelector('.all-hits-container');
    const likesDiv = document.querySelector('.likes');
    const savedSongsDiv = document.querySelector('.saved-container');

    console.log(savedSongsDiv);

    addBtn.addEventListener('click', addSong);

    function addSong(ev) {
        ev.preventDefault();

        const genre = genreField.value;
        const name = nameField.value;
        const author = authorField.value;
        const date = dateField.value;

        if (genre != '' && name != '' && author != '' && date != '') {
            const saveBtn = e('button', { class: 'save-btn' }, 'Save song');
            const likeBtn = e('button', { class: 'like-btn' }, 'Like song');
            const deleteBtn = e('button', { class: 'delete-btn' }, 'Delete');

            const hitsInfoDiv = e('div', { class: 'hits-info' },
                e('img', {src: './static/img/img.png'}),
                e('h2', {}, 'Genre: ' + genre),
                e('h2', {}, 'Name: ' + name),
                e('h2', {}, 'Author: ' + author),
                e('h3', {}, 'Date: ' + date),
                saveBtn,
                likeBtn,
                deleteBtn);

            allHitsDiv.appendChild(hitsInfoDiv);

            genreField.value = '';
            nameField.value = '';
            authorField.value = '';
            dateField.value = '';

            likeBtn.addEventListener('click', likeSong);

            saveBtn.addEventListener('click', function(){
                savedSongsDiv.appendChild(hitsInfoDiv);
                hitsInfoDiv.removeChild(saveBtn);
                hitsInfoDiv.removeChild(likeBtn);
            });

            deleteBtn.addEventListener('click', function(){
                hitsInfoDiv.remove();
            });
        }

        function likeSong(ev) {
            likesDiv.firstElementChild.textContent = 'Total Likes: ' + Number(Number(likesDiv.firstElementChild.textContent.split(' ')[2]) + 1);
            ev.target.disabled = true;
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
}