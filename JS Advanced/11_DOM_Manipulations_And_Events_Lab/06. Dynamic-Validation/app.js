function validate() {
    const email = document.getElementById('email');
    email.addEventListener('change', error);

    function error(e){
        if (!(/\w+@\w+\.\w+/.test(email.value))) {
            e.target.classList.add('error');
        }
        else{
            e.target.classList.remove('error');
        }
    }
}