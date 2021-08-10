import { movieBaseUrl, likesBaseUrl } from "../dataServices/urls.js";
import {data} from '../dataServices/dataServise.js'
import auth from "../dataServices/auth.js";
import {viewChange} from '../helpers/events.js';

let movieDetailsView = document.querySelector('#movie-example');
let ownerSpan = movieDetailsView.querySelector('#owners-buttons');
let likesSpan = movieDetailsView.querySelector('#logged-buttons');
let likedSpan = movieDetailsView.querySelector('span.enrolled-span');

async function movieDetailsLoad(movieId){
    let _ownerId = auth.getUser().userId;
    data.setUrl(movieBaseUrl);
    let movie = await data.get(movieId);

    if(!movie) return;

    movieDetailsView.querySelector('h1').textContent = `Movie title: ${movie.title}`;
    movieDetailsView.querySelector('img').src = movie.img;
    movieDetailsView.querySelector('p').textContent = movie.description;
    let editButton = movieDetailsView.querySelector('.btn.btn-warning');
    let deleteButton = movieDetailsView.querySelector('.btn.btn-danger');
    let likeButton = movieDetailsView.querySelector('.btn.btn-primary');
    likeButton.dataset.movieId = movie._id;
    likeButton.addEventListener('click', addLike);
    let liked = await checkUserLikedMovie(movieId);
//updateLikes(movieId);

    if(_ownerId === movie._ownerId){
        editButton.dataset.movieId = movie._id;
        deleteButton.dataset.movieId = movie._id;

        editButton.addEventListener('click', function (e) {
            viewChange('editMovieView', e.target.dataset.movieId);
        })
        deleteButton.addEventListener('click', function (e) {
            deleteMovie(e.target.dataset.movieId)
        })
        showElement(ownerSpan);
        hideElement(likesSpan);
        hideElement(likedSpan);
    }else{
        hideElement(ownerSpan);

        if(liked){
            hideElement(likesSpan);
            updateLikes(movieId);
        }else{
            showElement(likesSpan);
            hideElement(likedSpan);
        }
    }
}

function showElement(el){
    el.classList.remove('hidden');
}

function hideElement(el){
    if(!el.classList.contains('hidden'))el.classList.add('hidden');
}

function addLike(e){
    let movieId = e.target.dataset.movieId;
    data.setUrl(likesBaseUrl);
    data.add({movieId}, auth.getToken())
        .then(res => {
            hideElement(likesSpan);
            updateLikes(movieId)
        });
}

function updateLikes(movieId){
    let url = `${likesBaseUrl}?where=movieId%3D%22${movieId}%22&distinct=_ownerId&count`;
    data.setUrl(url);
    data.get()
        .then(res => {
            likedSpan.textContent = 'Liked ' + res;
            showElement(likedSpan);
        });
}

function deleteMovie(movieId){
    data.setUrl(movieBaseUrl);
    let token = auth.getToken();
    data.remove(movieId, token)
    .then(() => {
        viewChange('homeView');
    })
}

export default {
    showView,
    hideView,
}

function showView(id){
    movieDetailsLoad(id);
    showElement(movieDetailsView);
}

async function checkUserLikedMovie(id){
    let url = `${likesBaseUrl}?where=movieId%3D%22${id}%22%20and%20_ownerId%3D%22${auth.getUser().userId}%22`;
    data.setUrl(url);
    let response = await data.get();
    return response.length > 0;
}

function hideView(){
    hideElement(movieDetailsView);
}