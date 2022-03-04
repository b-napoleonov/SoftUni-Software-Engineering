const url = 'http://localhost:3030/jsonstore/phonebook';
const phonebookUl = document.getElementById('phonebook');

function attachEvents() {
    const loadBtn = document.getElementById('btnLoad');
    const createBtn = document.getElementById('btnCreate');

    createBtn.addEventListener('click', createContact);
    loadBtn.addEventListener('click', loadContacts);
}

attachEvents();

async function loadContacts() {
    phonebookUl.innerHTML = '';

    try {
        const response = await fetch(url);

        if (response.status != 200) {
            throw new Error(`Error: ${response.status}`);
        }

        const data = await response.json();

        for (const record in data) {
            const liElement = document.createElement('li');
            const deleteBtn = document.createElement('button');

            liElement.textContent = `${data[record].person}: ${data[record].phone}`;
            deleteBtn.textContent = 'Delete';
            deleteBtn.addEventListener('click', deleteContact.bind(this, data[record]._id));

            liElement.appendChild(deleteBtn);
            phonebookUl.appendChild(liElement);
        }

    } catch (error) {
        alert(error);
    }
}

async function deleteContact(id) {
    try {
        const response = await fetch(url + '/' + id, {
            method: 'DELETE'
        });

        if (response.status != 200) {
            throw new Error(`Error: ${response.status}`);
        }

        await response.json();

        phonebookUl.innerHTML = '';

        loadContacts();

    } catch (error) {
        alert(error);
    }
}

async function createContact() {
    const personInput = document.getElementById('person');
    const phoneInput = document.getElementById('phone');

    const person = personInput.value;
    const phone = phoneInput.value;

    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                person: person,
                phone: phone
            })
        });

        if (response.status != 200) {
            throw new Error(`Error: ${response.status}`);
        }

        await response.json();

        personInput.value = '';
        phoneInput.value = '';
        phonebookUl.innerHTML = '';

        loadContacts();

    } catch (error) {
        alert(error);
    }
}