function loadRepos() {
      let url = 'https://api.github.com/users/testnakov/repos';
      var request = new XMLHttpRequest();
      const resultDiv = document.querySelector('#res');
   
      request.addEventListener('readystatechange', function () {
         if (request.readyState == 4 && request.status == 200) {
            resultDiv.textContent = request.responseText;
         }
      });
      
      request.open("GET", url);
      request.send();
}