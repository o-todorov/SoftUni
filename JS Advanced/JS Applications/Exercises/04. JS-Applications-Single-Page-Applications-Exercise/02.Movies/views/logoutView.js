import { logoutUrl } from "../dataServices/urls.js";
import {data} from '../dataServices/dataServise.js'
import auth from "../dataServices/auth.js";
import {stateChange} from '../helpers/events.js';

async function showView(){
    data.setUrl(logoutUrl);
    let response = await data.get('', auth.getToken());
    if(!response) return;
    auth.removeUser();
    stateChange('guest');
}

function hideView(){
    //loginView.classList.add('hidden');
}

export default {
    showView,
    hideView,
}