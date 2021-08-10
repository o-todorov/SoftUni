import { loginUrl } from "../dataServices/urls.js";
import {data} from '../dataServices/dataServise.js'
import auth from "../dataServices/auth.js";
import {stateChange} from '../helpers/events.js';
import validator from '../helpers/validators.js';

let loginView = document.getElementById('form-login');
let loginForm = loginView.querySelector('form');
loginForm.addEventListener('submit', login);

 async function login(e){
    e.preventDefault();
    let frmData = new FormData(loginForm);
    let email = frmData.get('email');
    let password = frmData.get('password');
    if(! validator.validateEmail(email) || !validator.validatePassword(password))
        return;
    data.setUrl(loginUrl);
    let response = await data.add({email, password});
    
    if(response == 403){
        window.alert(`User ${email} is not registered.\nPlease, enter valid email`);
        return;
    }
    if(!response) return;
    auth.saveUser({email,
                userId: response._id, 
                token: response.accessToken
            });
    stateChange('user');
 }
export default {
    showView,
    hideView,
}

function showView(){
    loginView.classList.remove('hidden');
}

function hideView(){
    loginForm.reset();
    loginView.classList.add('hidden');
}