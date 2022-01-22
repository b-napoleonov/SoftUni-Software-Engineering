function toggle() {
    let button = document.querySelector('.button');
    let divExtra = document.querySelector('#extra');

    switch(button.textContent) {
        case 'More':
            button.textContent = 'Less';
            divExtra.style.display = 'block';
            break;
        case 'Less':
            button.textContent = 'More';
            divExtra.style.display = 'none';
            break;
    };
}