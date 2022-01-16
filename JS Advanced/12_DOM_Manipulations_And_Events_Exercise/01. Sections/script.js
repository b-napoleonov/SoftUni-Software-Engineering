function create(words) {
   for (const word of words) {
      const paragraph = document.createElement('p');
      paragraph.textContent = word;
      paragraph.style.display = 'none';

      const div = document.createElement('div');
      div.appendChild(paragraph);
      div.addEventListener('click', (e) => e.target.children[0].style.display = 'block');

      document.getElementById('content').appendChild(div);
   }
}