import { registerUrl } from "../dataServices/urls.js";
import {data} from '../dataServices/dataServise.js'
import validator from '../helpers/validators.js';
import auth from "../dataServices/auth.js";
import {stateChange} from '../helpers/events.js';

let registerView = document.getElementById('form-sign-up');
let registerForm = registerView.querySelector('form');
registerForm.addEventListener('submit', register);

 async function register(e){
    e.preventDefault();
    let frmData = new FormData(registerForm);
    let email = frmData.get('email');
    let password = frmData.get('password');
    let rePassword = frmData.get('repeatPassword');
    if(! validator.validateEmail(email) || !validator.validatePasswords(password, rePassword))
        return;
    data.setUrl(registerUrl);
    let response = await data.add({email, password});
    if(response == 409){
        window.alert(`User ${email} is already registered.\nPlease, enter another email`);
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
    registerView.classList.remove('hidden');
}

function hideView(){
    registerView.classList.add('hidden');
    registerForm.reset();
}