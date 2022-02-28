const mainSection = document.getElementById('main');
const accordionDiv = document.querySelector('.accordion');

async function solution() {
    mainSection.innerHTML = '';

    try {
        const response = await fetch(`http://localhost:3030/jsonstore/advanced/articles/list`);
        if (response.status !== 200) {
            throw new Error(`Error ${response.status}: ${response.statusText}. Refresh and try again`);
        }

        const data = await response.json();

        for (const element in data) {
            const newDiv = accordionDiv.cloneNode(true);

            newDiv.querySelector('span').textContent = data[element].title;
            newDiv.querySelector('.button').addEventListener('click', showMore);
            requestContent(data[element]._id, newDiv);

            mainSection.appendChild(newDiv);
        }

    } catch (error) {
        const h1Element = document.createElement('h1');
        h1Element.textContent = error.message;
        mainSection.innerHTML = '';
        mainSection.appendChild(h1Element);
    }
}

function showMore(ev){
    switch(ev.target.textContent) {
        case 'More':
            ev.target.textContent = 'Less';
            ev.target.parentNode.parentNode.children[1].style.display = 'block';
            break;
        case 'Less':
            ev.target.textContent = 'More';
            ev.target.parentNode.parentNode.children[1].style.display = 'none';
            break;
    };
}

async function requestContent(id, newDiv) {
    try {
        const response = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${id}`);
        if (response.status !== 200) {
            throw new Error(`Error ${response.status}: ${response.statusText}. Refresh and try again`);
        }

        const data = await response.json();
        newDiv.querySelector('p').textContent = data.content;
        
    } catch (error) {
        const h1Element = document.createElement('h1');
        h1Element.textContent = error.message;
        mainSection.innerHTML = '';
        mainSection.appendChild(h1Element);
    }
}