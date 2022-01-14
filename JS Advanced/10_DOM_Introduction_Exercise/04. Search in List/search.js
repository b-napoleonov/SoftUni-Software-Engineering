function search() {
   document.getElementById('result').textContent = '';
   const arr = Array.from(document.getElementById('towns').querySelectorAll('li'));
   for (const element of arr) {
      element.style.textDecoration = 'none';
      element.style.fontWeight = 'normal';
   }
   const searchInput = document.getElementById('searchText').value.toLowerCase();
   let matches = 0;
   for (const element of arr) {
      const value = element.textContent.toLowerCase();
      if (value.includes(searchInput)) {
         element.style.textDecoration = 'underline';
         element.style.fontWeight = 'bold';
         matches++;
      }
   }
   document.getElementById('result').textContent = `${matches} matches found`;
}