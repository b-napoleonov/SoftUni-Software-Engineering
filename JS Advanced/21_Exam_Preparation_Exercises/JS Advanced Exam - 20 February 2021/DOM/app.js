//1 test are wrong in judge

function solve() {
   const authorField = document.querySelectorAll('form')[0].querySelectorAll('input')[0];
   const titleField = document.querySelectorAll('form')[0].querySelectorAll('input')[1];
   const categoryField = document.querySelectorAll('form')[0].querySelectorAll('input')[2];
   const contentField = document.querySelectorAll('form')[0].querySelectorAll('textarea')[0];
   const createBtn = document.querySelectorAll('form')[0].querySelectorAll('button')[0];
   const postsSection = document.querySelectorAll('section')[1];
   const archiveSectionOL = document.querySelector('.archive-section>ol');

   createBtn.addEventListener('click', createArticle);

   function createArticle(ev) {
      ev.preventDefault();

      const author = authorField.value;
      const title = titleField.value;
      const category = categoryField.value;
      const content = contentField.value;

      const deleteBtn = e('button', {class: 'btn delete'}, 'Delete');
      const archiveBtn = e('button', {class: 'btn archive'}, 'Archive');

      const articleElement = e('article', {}, 
         e('h1', {}, title),
         e('p', {}, 'Category:', 
            e('strong', {}, category)),
         e('p', {}, 'Creator', 
            e('strong', {}, author)),
         e('p', {}, content),
         e('div', {class: 'buttons'}, 
            deleteBtn,
            archiveBtn));

      postsSection.appendChild(articleElement);

      authorField.value = '';
      titleField.value = '';
      categoryField.value = '';
      contentField.value = '';

      archiveBtn.addEventListener('click', archiveArticle);
      deleteBtn.addEventListener('click', deleteArticle);
   }

   function archiveArticle(ev) {
      const articleTitle = ev.target.parentNode.parentNode.children[0].textContent;

      const liElement = e('li', {}, articleTitle);
      archiveSectionOL.appendChild(liElement);

      ev.target.parentElement.parentElement.remove();

      Array.from(archiveSectionOL.getElementsByTagName("LI"))
         .sort((a, b) => a.textContent.localeCompare(b.textContent))
         .forEach(liElement => archiveSectionOL.appendChild(liElement));
   }

   function deleteArticle(ev) {
      ev.target.parentElement.parentElement.remove();
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
