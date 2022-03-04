window.addEventListener('DOMContentLoaded', () => {
    const form = document.querySelector('form');

    document.getElementById('user').style.display = 'none';
    document.getElementById('guest').style.display = 'inline-block';

    form.addEventListener('submit', onLogin);
})

async function onLogin(e) {
    e.preventDefault();

    const formData = new FormData(e.target);

    let emailData = formData.get('email').trim();
    let passwordData = formData.get('password').trim();

    if (emailData == '' || passwordData == '') {
        alert('Please fill the required fields!');
        return;
    }

    const data = {
        email: emailData,
        password: passwordData
    }

    try {
        const response = await fetch('http://localhost:3030/users/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (response.status !== 200) {
            const error = await response.json();
            throw new Error(error.message);
        }

        const user = await response.json();

        const userData = {
            id: user._id,
            email: user.email,
            token: user.accessToken
        };

        sessionStorage.setItem('userData', JSON.stringify(userData));
        window.location = './index.html';

    } catch (error) {
        alert(error.message);
    }
}