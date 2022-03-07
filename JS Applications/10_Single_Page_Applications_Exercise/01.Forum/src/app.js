//kinda works. Comments section needs improvement

import { createPost, cancelInputs } from './create.js';
import { displayTopics } from './topics.js';

window.onload = () =>{
    displayTopics();
    document.querySelector('.public').addEventListener('click', createPost);
    document.querySelector('.cancel').addEventListener('click', cancelInputs);

    const homeAnchor = document.getElementById('homeAnchor');
    homeAnchor.addEventListener('click', () => {
        window.location.href = './index.html';
    });
}