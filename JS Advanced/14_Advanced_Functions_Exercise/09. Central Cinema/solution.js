function solve() {
    const formElements = document.querySelector('#container').children;
    const inputs = Array.from(formElements).slice(0, formElements.length - 1);
    const onscreenButton = Array.from(formElements).slice(formElements.length - 1)[0];
    const movieUl = document.querySelector('#movies>ul');
    const archiveUl = document.querySelector('#archive>ul');
    const clearBtn = document.querySelector('#archive>button');

    onscreenButton.addEventListener('click', createMovie);

    function createMovie(e){
        e.preventDefault();

        const name = inputs[0].value;
        const hall = inputs[1].value;
        const price = Number(inputs[2].value);

        if (!name || !hall || !price) { return; }

        inputs[0].value = '';
        inputs[1].value = '';
        inputs[2].value = '';

        const li = document.createElement('li');

        const span = document.createElement('span');
        span.textContent = name;
        li.appendChild(span);

        const strong = document.createElement('strong');
        strong.textContent = `Hall: ${hall}, `;
        li.appendChild(strong);

        const div = document.createElement('div');

        const innerStrong = document.createElement('strong');
        innerStrong.textContent = price.toFixed(2);

        const input = document.createElement('input');
        input.setAttribute('placeholder', 'Tickets Sold');

        const archiveBtn = document.createElement('button');
        archiveBtn.textContent = 'Archive';
        archiveBtn.addEventListener('click', archiveMovie);

        div.appendChild(innerStrong);
        div.appendChild(input);
        div.appendChild(archiveBtn);

        li.appendChild(div);

        movieUl.appendChild(li);
    }

    function archiveMovie(e){
        const li = e.target.parentNode.parentNode;
        const div = e.target.parentNode;
        const input = div.children[1];

        if (Number(input.value) == '') { return; }

        const span = document.createElement('span');
        const name = li.children[0].textContent;
        span.textContent = name;

        const strong = document.createElement('strong');
        const price = Number(div.children[0].textContent);
        const totalPrice = Number(input.value) * price;
        strong.textContent = `Total amount: ${totalPrice.toFixed(2)}`;

        const deleteBtn = document.createElement('button');
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', (e) => {
            e.target.parentNode.remove();
        });

        const resultLi = document.createElement('li');
        resultLi.appendChild(span);
        resultLi.appendChild(strong);
        resultLi.appendChild(deleteBtn);
        
        archiveUl.appendChild(resultLi);
        li.remove();
    }

    clearBtn.addEventListener('click', clearArchive);

    function clearArchive(e){
        archiveUl.innerHTML = '';
    }
}