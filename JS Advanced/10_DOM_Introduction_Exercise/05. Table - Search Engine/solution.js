function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   let input = document.querySelectorAll('tbody>tr');

   function onClick() {
      const searchText = document.querySelector('#searchField').value.toLowerCase();
      for (const element of input) {
         if (element.innerText.toLowerCase().includes(searchText)) {
            element.setAttribute('class', 'select');
         }
         else{
            element.removeAttribute('class');
         }
      }

      //Solution using Array.map() function
      // Array.from(input).map(e => changeClass(e));

      // function changeClass(e) {
      //    return e.innerText.toLowerCase().includes(searchText) ? e.setAttribute('class', 'select') : e.removeAttribute('class');
      // }
   }
}