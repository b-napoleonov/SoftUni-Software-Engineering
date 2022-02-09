function solve() {
    const inputTask = document.getElementById('task');
    const inputDescription = document.getElementById('description');
    const inputDate = document.getElementById('date');
    const inputBtn = document.getElementById('add');
    const openDiv = document.querySelectorAll('section')[1].children[1];
    const inProgressDiv = document.querySelector('#in-progress');
    const completeDiv = document.querySelectorAll('section')[3].children[1];

    inputBtn.addEventListener('click', addEvent);

    function addEvent(ev) {
        ev.preventDefault();
        const task = inputTask.value;
        const description = inputDescription.value;
        const date = inputDate.value;

        if (task === '' || description === '' || date === '') {
            return;
        }

        const startBtn = e('button', {class: 'green'}, 'Start');
        const deleteBtn = e('button', {class: 'red'}, 'Delete');

        const articleElement = e('article', {},
        e('h3', {}, task),
        e('p', {}, 'Description: ' + description),
        e('p', {}, 'Due Date: ' + date),
        e('div', {class: 'flex'},
        startBtn,
        deleteBtn));

        openDiv.appendChild(articleElement);

        inputTask.value = '';
        inputDescription.value = '';
        inputDate.value = '';

        startBtn.addEventListener('click', startEvent.bind(null, articleElement));
        deleteBtn.addEventListener('click', deleteEvent);
    }

    function startEvent(articleElement) {
        inProgressDiv.appendChild(articleElement);
        articleElement.removeChild(articleElement.children[3]);

        const deleteBtn = e('button', {class: 'red'}, 'Delete');
        const finishButton = e('button', {class: 'orange'}, 'Finish');
        articleElement.appendChild(e('div', {class: 'flex'}, deleteBtn, finishButton));

        deleteBtn.addEventListener('click', deleteEvent);
        finishButton.addEventListener('click', finishEvent.bind(null, articleElement));
    }

    function deleteEvent(ev) {
        ev.target.parentElement.parentElement.remove();
    }

    function finishEvent(articleElement) {
        completeDiv.appendChild(articleElement);
        articleElement.removeChild(articleElement.children[3]);
    }

    function e(type, attr, ...content){
        const element = document.createElement(type);

        for (let prop in attr) {
            element.setAttribute(prop, attr[prop]);
        }

        for (let item of content) {
            if(typeof item === 'string' || typeof item === 'number'){
                item = document.createTextNode(item);
            }
            element.appendChild(item);
        }

        return element;
    }
}