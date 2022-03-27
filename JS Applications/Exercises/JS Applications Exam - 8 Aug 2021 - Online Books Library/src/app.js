import { logout } from './api/data.js';
import { render, page } from './lib.js';
import { getUserData } from './util.js';
import { createPage } from './views/create.js';
import { dashboardPage } from './views/dashboard.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { loginPage } from './views/login.js';
import { myBooksPage } from './views/myBooks.js';
import { registerPage } from './views/register.js';

const root = document.getElementById('site-content');
document.getElementById('logoutBtn').addEventListener('click', onLogout);

page(decorateContext);
page('/', dashboardPage);
page('/login', loginPage);
page('/register', registerPage);
page('/create', createPage);
page('/details/:id', detailsPage);
page('/edit/:id', editPage);
page('/myBooks', myBooksPage);

updateUserNav();
page.start();

function decorateContext(ctx, next){
    ctx.render = (content) => render(content, root);
    ctx.updateUserNav = updateUserNav;

    next();
}

async function onLogout(){
    logout();
    updateUserNav();
    page.redirect('/');
}

function updateUserNav(){
    const userData = getUserData();

    if (userData) {
        document.getElementById('user').style.display = 'block';
        document.getElementById('guest').style.display = 'none';
        document.getElementById('user').querySelector('span').textContent = `Welcome, ${userData.email}`;
    }else{
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = 'block';
    }
}