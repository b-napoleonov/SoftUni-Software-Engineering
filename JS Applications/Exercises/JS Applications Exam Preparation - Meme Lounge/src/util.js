export function getUserData(){
    return JSON.parse(sessionStorage.getItem('userData'));
}

export function setUserData(data){
    sessionStorage.setItem('userData', JSON.stringify(data));
}

export function clearUserData(){
    sessionStorage.removeItem('userData');
}

export function notify(message){
    const notifyDiv = document.getElementById('errorBox');
    notifyDiv.querySelector('span').textContent = message;
    notifyDiv.style.display = 'block';
    setTimeout(() => notifyDiv.style.display = 'none', 3000);
}