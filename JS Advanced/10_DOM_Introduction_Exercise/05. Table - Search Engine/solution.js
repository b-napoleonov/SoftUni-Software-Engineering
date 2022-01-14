function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      document.getElementById('searchField').textContent = '';
      const searchText = document.getElementById('searchField').value.toLowerCase();

      const arr = Array.from(document.getElementsByClassName('container')[0].querySelectorAll('tbody tr'));

      for (const element of arr) {
         element.classList.remove('select');
      }

      for (const element of arr.filter(e => e.textContent.toLowerCase().includes(searchText))) {
         element.classList.add('select');
      }
   }
}