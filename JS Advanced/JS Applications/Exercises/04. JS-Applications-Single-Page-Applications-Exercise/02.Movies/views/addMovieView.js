import { movieBaseUrl } from "../dataServices/urls.js";
import {data} from '../dataServices/dataServise.js'
import auth from "../dataServices/auth.js";
import validator from '../helpers/validators.js';
import {viewChange} from '../helpers/events.js';

let addMovieView = document.querySelector('#add-movie');
let addMovieForm = addMovieView.querySelector('form');
addMovieForm.addEventListener('submit', addMovie);

 async function addMovie(e){
    e.preventDefault();
    let frmData = new FormData(addMovieForm);
    let title = frmData.get('title');
    let description = frmData.get('description');
    let img = frmData.get('imageUrl');

    if(! validator.validateForEmptyFields([title, description, img])) return;

    data.setUrl(movieBaseUrl);
    let response = await data.add({title, description, img}, auth.getToken());

    if(!response) return;
    viewChange('homeView');
}
export default {
    showView,
    hideView,
}

function showView(){
    addMovieView.classList.remove('hidden');
}

function hideView(){
    addMovieForm.reset();
    addMovieView.classList.add('hidden');
}