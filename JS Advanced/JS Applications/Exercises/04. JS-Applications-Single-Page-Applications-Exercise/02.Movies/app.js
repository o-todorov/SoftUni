import auth from './dataServices/auth.js';
import homeView from './views/homeView.js';
import loginView from './views/loginView.js';
import registerView from './views/registerView.js';
import logoutView from './views/logoutView.js';
import addMovieView from './views/addMovieView.js';
import movieDetailsView from './views/movieDetailsView.js';
import editMovieView from './views/editMovieView.js';
import {stateChange, viewChange} from './helpers/events.js';

document.body.addEventListener('stateChange', setState);
document.body.addEventListener('viewChange', setView);
let state;


let currView;
let views = {
    homeView,
    loginView,
    registerView,
    logoutView,
    addMovieView,
    movieDetailsView,
    editMovieView,
}

Array.from(document.querySelectorAll('.view-nav'))
    .forEach(x => x.addEventListener('click', action));

stateChange(auth.isLogged()?'user':'guest');

function action(e){
    e.preventDefault();
    let link = e.target.dataset.link;
    viewChange(link);

}

function setView(e){
    let newView = views[e.detail.view];
    let movieId = e.detail.movieId;
    if(currView === newView) return;
    if(currView) currView.hideView();
    newView.showView(movieId);
    currView = newView;
}

function setState(e){
    let newState = e.detail.state;
    if(state === newState) return;
    Array.from(document.querySelectorAll(`.${state}`)).forEach (e => e.classList.add('hidden'));
    Array.from(document.querySelectorAll(`.${newState}`)).forEach (e => e.classList.remove('hidden'));

    if(newState == 'user'){
        document.getElementById('welcome').textContent = `Welcome, ${auth.getUser().email}`;
    }else if(newState == 'guest'){

    }

    viewChange('homeView');
    state = newState;
}



