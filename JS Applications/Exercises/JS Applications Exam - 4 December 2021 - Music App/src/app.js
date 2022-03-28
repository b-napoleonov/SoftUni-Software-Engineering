import { logout } from './api/data.js';
import { page, render } from './lib.js';
import { getUserData } from './util.js';
import { catalogPage } from './views/catalog.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { homePage } from './views/home.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';
import { searchPage } from './views/search.js';

const root = document.getElementById('main-content');
document.getElementById('logoutBtn').addEventListener('click', onLogout);

page(decorateContext);

page('/', homePage);
page('/login', loginPage);
page('/register', registerPage);
page('/catalog', catalogPage);
page('/create', createPage);
page('/details/:id', detailsPage);
page('/edit/:id', editPage);
page('/search', searchPage);

updateUserNav();
page.start();

function decorateContext(ctx, next){
    ctx.render = (template) => render(template, root);
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
        document.getElementById('createBtn').style.display = 'inline-block';
        document.getElementById('logoutBtn').style.display = 'inline-block';
        document.getElementById('loginBtn').style.display = 'none';
        document.getElementById('registerBtn').style.display = 'none';
    } else{
        document.getElementById('createBtn').style.display = 'none';
        document.getElementById('logoutBtn').style.display = 'none';
        document.getElementById('loginBtn').style.display = 'inline-block';
        document.getElementById('registerBtn').style.display = 'inline-block';
    }
}