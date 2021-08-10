export default {
    saveUser,
    getUser,
    getToken,
    removeUser,
    isLogged,
}
/* user =   {
                email,
                userId
                token
            }                   */

function saveUser(user){
    localStorage.setItem('movie_user', JSON.stringify(user));
}

function getUser(){
    return JSON.parse(localStorage.getItem('movie_user'));
}

function getToken(){
    return getUser().token;
}

function removeUser(){
    localStorage.removeItem('movie_user');
}

function isLogged(){
    return Boolean(localStorage.getItem('movie_user'));
}