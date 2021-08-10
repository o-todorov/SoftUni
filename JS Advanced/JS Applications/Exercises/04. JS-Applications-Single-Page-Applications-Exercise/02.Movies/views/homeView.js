import { movieBaseUrl } from "../dataServices/urls.js";
import {data} from '../dataServices/dataServise.js'
import auth from '../dataServices/auth.js';
import { viewChange } from "../helpers/events.js";

let homeView = document.getElementById('home-view');
let movieContainer = homeView.querySelector('#movie-container');
let logged;

export default {
    showView,
    hideView,
    reload,
}

function showView(){
    logged = auth.isLogged();
    reload();
    homeView.classList.remove('hidden');
}

function hideView(){
    homeView.classList.add('hidden');
}

function reload(){
    loadMovies();
}

async function loadMovies(){
    data.setUrl(movieBaseUrl);
    let movies = await data.get();
    movieContainer.innerHTML = '';
    movieContainer.append(...movies.map(createMovieHTML));
}

function createMovieHTML(movie){
    let template = homeView.querySelector('#movie-template');
    let movieElement = template.cloneNode(true);
    movieElement.classList.remove('hidden');
    movieElement.removeAttribute('style');
    movieElement.querySelector('img').src = movie.img;
    movieElement.querySelector('h4').textContent = movie.title;
    let details = movieElement.querySelector('.card-footer');
    if(!logged){ 
        details.remove();
    }else{
        let button = details.querySelector('button');
        button.id = movie._id;
        button.addEventListener('click', showDetailsView);
    }
    return movieElement;
}

function showDetailsView(e){
    let id = e.target.id;
    viewChange('movieDetailsView', id)
}