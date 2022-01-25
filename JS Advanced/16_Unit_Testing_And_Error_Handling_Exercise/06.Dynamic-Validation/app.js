function validate() {
    document.getElementById('email').addEventListener('change', onChange);

    function onChange(e) {
        const regex = /^[a-z]+@[a-z]+\.[a-z]+$/;

        if (regex.test(e.target.value)) {
            e.target.classList.remove('error');
        }
        else{
            e.target.classList.add('error');
        }
    }
}