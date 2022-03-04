const url = `http://localhost:3030/jsonstore/collections/students`;
window.onload = attachEvents;

function attachEvents() {
    const formElement = document.getElementById('form');
    formElement.addEventListener('submit', createStudentRecord);

    loadStudents();
}

async function createStudentRecord(ev) {
    ev.preventDefault();

    const formData = new FormData(ev.target);

    const firstName = formData.get('firstName').trim();
    const lastName = formData.get('lastName').trim();
    const facultyNumber = formData.get('facultyNumber').trim();
    const grade = formData.get('grade').trim();

    if (firstName === '' || lastName === '' || facultyNumber === '' || grade === '') {
        alert('Please fill all fields!');
        return;
    }

    const studentBody = {
        firstName: firstName,
        lastName: lastName,
        facultyNumber: facultyNumber,
        grade: grade
    }

    await fetch(url, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify(studentBody)
    });

    ev.target.reset();
    loadStudents();
}

async function loadStudents() {
    const tableBody = document.getElementById('results').children[1];

    const studentsResponse = await fetch(url);
    const studentsResult = await studentsResponse.json();

    tableBody.innerHTML = '';

    for (const student in studentsResult) {
        const trElement = e('tr', {},
            e('td', {}, studentsResult[student].firstName),
            e('td', {}, studentsResult[student].lastName),
            e('td', {}, studentsResult[student].facultyNumber),
            e('td', {}, studentsResult[student].grade));

        tableBody.appendChild(trElement);
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