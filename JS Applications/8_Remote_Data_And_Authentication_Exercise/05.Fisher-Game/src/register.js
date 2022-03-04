window.addEventListener('DOMContentLoaded', () => {
    const form = document.querySelector('form');

    document.getElementById('user').style.display = 'none';
    document.getElementById('guest').style.display = 'inline-block';

    form.addEventListener('submit', registerUser)
})

async function registerUser(ev) {
    ev.preventDefault();

    const formData = new FormData(ev.target);

    let email = formData.get('email').trim();
    let password = formData.get('password').trim();
    let repass = formData.get('rePass').trim();

    if (email == '' || password == '' || repass == '') {
        alert('Please fill the required fields!');
        return;
    } else if (password !== repass) {
        alert('Passwords don\'t match!');
        return;
    }

    try {
        const response = await fetch('http://localhost:3030/users/register', {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify({ email, password })
        });

        const data = await response.json();

        if (response.status != 200) {
            form.reset();
            throw new Error(data.message);
        }

        const userData = {
            id: data._id,
            email: data.email,
            token: data.accessToken
        };

        sessionStorage.setItem('userData', JSON.stringify(userData));
        window.location = './index.html';

    } catch (error) {
        alert(error.message);
    }
}