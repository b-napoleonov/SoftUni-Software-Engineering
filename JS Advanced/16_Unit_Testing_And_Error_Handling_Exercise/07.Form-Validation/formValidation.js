function validate() {
    const usernamePattern = /^[a-zA-Z0-9]{3,20}$/m;  
    const emailPattern = /^.*@.*\..*$/m;
    const passwordPattern = /^[\w]{5,15}$/m;  //
    const companyFieldPattern = /^[1-9][0-9]{3}$/m;  

    const userName = document.getElementById("username");
    const email = document.getElementById("email");
    const password = document.getElementById("password");
    const confirmPassword = document.getElementById("confirm-password");
    const checkbox = document.getElementById("company");
    const companyInfo = document.getElementById("companyInfo");
    const companyNumber = document.getElementById("companyNumber");
    const submitButton = document.getElementById("submit");

    submitButton.addEventListener("click", function (e) {
        e.preventDefault();
        let isDataValid = true;
        let isCompanyNumberValid = true;

        if (!usernamePattern.test(userName.value)) {
            userName.style.border = "1px solid red";
            isDataValid = false;
        }
        else{
            userName.removeAttribute("style");
        }

        if (!emailPattern.test(email.value)) {
            email.style.border = "1px solid red";
            isDataValid = false;
        }
        else{
            email.removeAttribute("style");
        }

        if (!passwordPattern.test(confirmPassword.value) || password.value !== confirmPassword.value) {
            password.style = 'border-color: red';
            isDataValid = false;
        } else {
            password.removeAttribute('style');
        }

        if (!passwordPattern.test(confirmPassword.value) || password.value !== confirmPassword.value) {
            confirmPassword.style = 'border-color: red';
            isDataValid = false;
        } else {
            confirmPassword.removeAttribute('style');
        }

        if (checkbox.checked) {
            if (!companyFieldPattern.test(companyNumber.value)) {
                companyNumber.style.border = "1px solid red";
                isCompanyNumberValid = false;
            }
            else{
                companyNumber.removeAttribute("style");
                isCompanyNumberValid = true;
            }
        }

        if (isDataValid && checkbox.checked === false) {
            document.getElementById('valid').style = 'display: block';
        }
        else if (isDataValid && checkbox.checked === true && isCompanyNumberValid) {
            document.getElementById('valid').style = 'display: block';
        }
        else{
            document.getElementById('valid').style = 'display: none';
        }
    });

    checkbox.addEventListener("change", (e) => {
        if (e.target.checked) {
            companyInfo.style.display = "block";
        }
        else{
            companyInfo.style.display = "none";
        }  
    });
}