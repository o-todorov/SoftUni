import { movieBaseUrl } from "../dataServices/urls.js";
import {data} from '../dataServices/dataServise.js'
import auth from "../dataServices/auth.js";
import validator from '../helpers/validators.js';
import {viewChange} from '../helpers/events.js';

let editMovieView = document.querySelector('#edit-movie');
let editMovieForm = editMovieView.querySelector('form');
editMovieForm.addEventListener('submit', editMovie);

 async function editMovie(e){
    e.preventDefault();
    let frmData = new FormData(editMovieForm);

    let movieId = editMovieForm.id;
    let title = frmData.get('title');
    let description = frmData.get('description');
    let img = frmData.get('imageUrl');

    if(! validator.validateForEmptyFields([title, description, img])) return;

    data.setUrl(movieBaseUrl);
    let response = await data.replace(movieId, {title, description, img}, auth.getToken());

    if(!response) return;
    viewChange('movieDetailsView', movieId);
 }
export default {
    showView,
    hideView,
}

async function showView(movieId){
    data.setUrl(movieBaseUrl);
    let movie = await data.get(movieId);
    if(!movie) return;

    editMovieForm.id = movieId;
    editMovieForm.querySelector('input[name="title"]').value = movie.title;
    editMovieForm.querySelector('textarea').value = movie.description;
    editMovieForm.querySelector('input[name="imageUrl"]').value = movie.img;
    editMovieView.classList.remove('hidden');
}

function hideView(){
    editMovieForm.reset();
    editMovieView.classList.add('hidden');
}