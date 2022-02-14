window.addEventListener('load', solution);

function solution() {
  const fullNameField = document.getElementById('fname');
  const emailField = document.getElementById('email');
  const phoneField = document.getElementById('phone');
  const addressField = document.getElementById('address');
  const postalCodeField = document.getElementById('code');
  const submitBtn = document.getElementById('submitBTN');
  const previewUl = document.getElementById('infoPreview');
  const editBtn = document.getElementById('editBTN');
  const continueBtn = document.getElementById('continueBTN');
  const blockDiv = document.getElementById('block');

  submitBtn.addEventListener('click', submitFunction);

  function submitFunction() {
    const fullName = fullNameField.value;
    const email = emailField.value;
    const phone = phoneField.value;
    const address = addressField.value;
    const postalCode = postalCodeField.value;

    if (fullName != '' || email != '') {
      submitBtn.disabled = true;

      previewUl.appendChild(e('li', {}, 'Full Name: ' + fullName));
      previewUl.appendChild(e('li', {}, 'Email: ' + email));
      previewUl.appendChild(e('li', {}, 'Phone Number: ' + phone));
      previewUl.appendChild(e('li', {}, 'Address: ' + address));
      previewUl.appendChild(e('li', {}, 'Postal Code: ' + postalCode));

      fullNameField.value = '';
      emailField.value = '';
      phoneField.value = '';
      addressField.value = '';
      postalCodeField.value = '';

      editBtn.disabled = false;
      continueBtn.disabled = false;

      editBtn.addEventListener('click', editFunction);

      function editFunction() {
        fullNameField.value = fullName;
        emailField.value = email;
        phoneField.value = phone;
        addressField.value = address;
        postalCodeField.value = postalCode;

        submitBtn.disabled = false;
        editBtn.disabled = true;
        continueBtn.disabled = true;

        previewUl.innerHTML = '';
      }

      continueBtn.addEventListener('click', continueFunction);

      function continueFunction() {
        blockDiv.innerHTML = '';

        blockDiv.appendChild(e('h3', {}, 'Thank you for your reservation!'));
      }
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
}
