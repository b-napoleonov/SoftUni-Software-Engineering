let userData = null;

window.addEventListener('DOMContentLoaded', () => {
    loadData();
    userData = JSON.parse(sessionStorage.getItem('userData'));

    if (userData) {
        document.getElementById('guest').style.display = 'none';
        document.querySelector('#addForm .add').disabled = false;
        document.querySelector('.email>span').textContent = userData.email;
    }
    else {
        document.getElementById('user').style.display = 'none';
    }

    document.querySelector('.load').addEventListener('click', loadData);
    document.getElementById('addForm').addEventListener('submit', onCreateSubmit);
    document.getElementById('logout').addEventListener('click', logout);
    document.getElementById('catches').addEventListener('click', onDeleteEditField);
})

async function onDeleteEditField(ev) {
    ev.preventDefault();

    if (ev.target.className == 'delete') {
        const id = ev.target.dataset.id;

        try {
            const response = await fetch(`http://localhost:3030/data/catches/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization': userData.token
                }
            });

            if (response.status !== 200) {
                const error = await response.json();
                throw new Error(error.message);
            }

            loadData();

        } catch (error) {
            alert(error.message);
        }
    }
    else if (ev.target.className == 'update') {
        const [angler, weight, species, location, bait, captureTime] = ev.target.parentNode.querySelectorAll('input');
        const data = {
            angler: angler.value,
            weight: Number(weight.value),
            species: species.value,
            location: location.value,
            bait: bait.value,
            captureTime: Number(captureTime.value)
        }

        const targetId = ev.target.getAttribute('data-id');

        try {
            const response = await fetch(`http://localhost:3030/data/catches/${targetId}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization': userData.token
                },
                body: JSON.stringify({ data })
            });

            if (response.status != 200) {
                const error = await response.json();
                throw new Error(error.message);
            }

        } catch (error) {
            alert(error.message);
        }
    }
}

async function onCreateSubmit(ev) {
    ev.preventDefault();

    if (!userData) {
        window.location = './login.html';
        return;
    }

    const formData = new FormData(ev.target);

    const data = [...formData.entries()].reduce((a, [k, v]) => Object.assign(a, { [k]: v }), {});

    try {
        if (Object.values(data).some(x => x == '')) {
            throw new Error('All fields are required');
        }

        const response = await fetch('http://localhost:3030/data/catches', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': userData.token
            },
            body: JSON.stringify(data)
        });

        if (response.status !== 200) {
            const error = await response.json();
            throw new Error(error.message);
        }

        loadData();
        ev.target.reset;

    } catch (error) {
        alert(error.message);
    }
}

async function loadData() {
    const res = await fetch('http://localhost:3030/data/catches');

    const data = await res.json();

    document.getElementById('catches').replaceChildren(...data.map(previewData));
}

function previewData(item) {
    const isOwner = (userData && item._ownerId == userData.id);

    const divElement = document.createElement('div');
    divElement.className = 'catch';
    divElement.innerHTML = `<label>Angler</label>
    <input type="text" class="angler" value="${item.angler}" ${!isOwner ? 'disabled' : ''}>
    <label>Weight</label>
    <input type="text" class="weight" value="${item.weight}" ${!isOwner ? 'disabled' : ''}>
    <label>Species</label>
    <input type="text" class="species" value="${item.species}" ${!isOwner ? 'disabled' : ''}>
    <label>Location</label>
    <input type="text" class="location" value="${item.location}" ${!isOwner ? 'disabled' : ''}>
    <label>Bait</label>
    <input type="text" class="bait" value="${item.bait}" ${!isOwner ? 'disabled' : ''}>
    <label>Capture Time</label>
    <input type="number" class="captureTime" value="${item.captureTime}" ${!isOwner ? 'disabled' : ''}>
    <button class="update" data-id="${item._id}" ${!isOwner ? 'disabled' : ''}>Update</button>
    <button class="delete" data-id="${item._id}" ${!isOwner ? 'disabled' : ''}>Delete</button>`

    return divElement;
}

async function logout(ev) {
    ev.preventDefault();
    console.log('it works');
    await fetch('http://localhost:3030/users/logout', {
        method: 'GET',
        headers: {
            'X-Authorization': sessionStorage.getItem('authToken'),
        },
    });

    sessionStorage.clear(); // Clear tokens for this user
    window.location.href = './index.html';
}