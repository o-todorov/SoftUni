import { reqMethod } from './auth.js';
import {addElement, createElement} from './funcs.js';
HTMLElement.prototype.add = addElement;

let usersURL = 'http://localhost:3030/users/';
let catchesURL = 'http://localhost:3030/data/catches';

let sections = {
    home: document.querySelector('#home-view'),
    register: document.querySelector('#register-view'),
    login: document.querySelector('#login-view')
}
let catchesDiv = sections.home.querySelector('#catches');
let nav = document.querySelector('nav');

let currView;
Object.values(sections).forEach(v => v.style.display = 'none');

let state = getToken()?'stateUser':'stateGuest';
setState(state);

nav.addEventListener('click', (e) => { 
    if(e.target.id == 'logout'){
        logout();
    }else if(e.target.tagName == 'A'){
         setView(e.target.id);
    }
})

let logForm = sections.login.querySelector('form')
logForm.addEventListener('submit', login);

let regForm = sections.register.querySelector('form')
regForm.addEventListener('submit', register);

let loadCatchesButton = sections.home.querySelector('aside button.load');
loadCatchesButton.addEventListener('click', loadCatchesAll);

let addCatchForm = document.getElementById('addForm');
addCatchForm.addEventListener('submit', addCatch);

// functionality

function addCatch(e){
    e.preventDefault();
    let currCatch = getCatchFromContainer(addCatchForm);
    let method = reqMethod.post(currCatch);
    method.headers['X-Authorization'] = getToken();
    fetch(catchesURL, method)
    .then(req => {
        statusValidate(req.status, 'Server request error!');
        addCatchForm.querySelectorAll('input').forEach(i => i.value = '');
        return req.json();
    })
    .then(res => catchesDiv.appendChild(createCatchHTML(res, getOwnerID())))
    .catch(err => window.alert('Error adding new catch: \n' + err));
}

function loadCatchesAll(){
    let userID = getOwnerID();
    fetch(catchesURL)
    .then(req => {
        statusValidate(req.status, 'Server request error!');
        return req.json();
    })
    .then(catches => {
        let catchesHTMLCollection = Array.from(catches).map(x => createCatchHTML(x, userID));
        catchesDiv.textContent = '';
        catchesDiv.append(...catchesHTMLCollection);
        sections.home.querySelector('#main').style.display = 'inline-block';
    })
    .catch(err => window.alert('Error loading all catches: \n' + err));
}
 
function createCatchHTML(_catch, userID){
    let isOwner = userID == _catch._ownerId;
    let div = createElement('div', ['class', 'catch'], ['id', _catch._id], ['ownerid', _catch._ownerId]);
    div.add('label', 'Angler');
    div.add('input', ['name', 'angler'], ['value', _catch.angler]);
    div.add('label', 'Weight');
    div.add('input', ['name', 'weight'], ['type', 'number'], ['value',  _catch.weight]);
    div.add('label', 'Species');
    div.add('input', ['name','species' ], ['value', _catch.species]);
    div.add('label', 'Location');
    div.add('input', ['name', 'location'], ['value', _catch.location]);
    div.add('label', 'Bait');
    div.add('input', ['name', 'bait'], ['value', _catch.bait]);
    div.add('label', 'Capture Time');
    div.add('input', ['name', 'captureTime'], ['type', 'number'], ['value', _catch.captureTime]);
    let updateButton = div.add('button', 'UPDATE', ['class', 'update']);
    let deleteButton = div.add('button', 'DELETE', ['class', 'delete']);
    updateButton.addEventListener('click', updateCatch);
    deleteButton.addEventListener('click', deleteCatch);
    updateButton.disabled = !isOwner;
    deleteButton.disabled = !isOwner;
    return div;
}

function deleteCatch(e){
    let catchDiv = e.target.closest('.catch');
    let method = {method: 'delete'};
    method.headers = {'X-Authorization': getToken()};

    fetch(`${catchesURL}/${catchDiv.id}`, method)
    .then(req => {
        statusValidate(req.status, 'Server request error!');
        return req.json();
    })
    .then(res => catchDiv.remove())
    .catch(error => window.alert('Delete catch error: \n' + error.message));
}

function updateCatch(e){
    let catchDiv = e.target.parentElement;
    let id = catchDiv.id;
    let currCatch = getCatchFromContainer(catchDiv);
    let method = reqMethod.put(currCatch);
    method.headers['X-Authorization'] = getToken();

    fetch(`${catchesURL}/${id}`, method)
    .then(req => statusValidate(req.status, 'Server request error!'))
    .catch(err => window.alert('Update catch error: \n' + err.message));
}

function getCatchFromContainer(container){
    let currCatch = Array.from(container.querySelectorAll('input'))
                .reduce((obj, x) => {
                    obj[x.name] = x.value;
                    return obj;
                }, {});
    currCatch.weight = Number(currCatch.weight);
    currCatch.captureTime = Number(currCatch.captureTime);
    return currCatch;        
}

async function login(e){
    e.preventDefault();
    let formDate = new FormData(e.currentTarget);
    let user = {email: formDate.get('email'), password: formDate.get('password')};
    try {
        let req = await fetch(`${usersURL}/login`, reqMethod.post(user));
        let message = req.status == '403'? 'Invalid username or password':'Server request error!';
        statusValidate(req.status, message);
        let response = (await req.json())
        saveToken(response);
        setState('stateUser');
    } catch(error){
        logForm.querySelector('.notification').textContent = error.message;
        return;
    }finally{
        logForm.reset();
    }
}

async function register(e){
    e.preventDefault();
    let formData = new FormData(e.currentTarget);
    if(formData.get('password') !=formData.get('rePass') ){
        regForm.querySelector('.notification').textContent = 'Retype correct password!';
        regForm.querySelector('input[name="rePass"').focus();
        return;
    }
    let user = {email: formData.get('email'), password: formData.get('password')};
    try {
        let req = await fetch(`${usersURL}/register`, reqMethod.post(user));
        let message = req.status == '409'? 'User already exist!':'Server request error!';
        statusValidate(req.status, message);
        let response = (await req.json())
        saveToken(response);
        setState('stateUser');
    } catch(error){
        regForm.querySelector('.notification').textContent = error.message;
    }finally{
        regForm.reset();
    }
}

async function logout(){
    try {
        let token = localStorage.getItem('fish_token');
        let getMethod = reqMethod.get();
        getMethod.headers['X-Authorization'] = token;
        let req = await fetch(`${usersURL}/logout`, getMethod);
        statusValidate(req.status, 'Server request error!');
    } catch(error){
        window.alert('Logout error: \n' + error.message + '\nUser is logged out');
    }finally{
        setState('stateGuest');
        removeLocalData();
    }
}

function setState(newState){
    state = newState;
    if(state == 'stateUser'){
        let ownerID = getOwnerID();

        document.getElementById('guest').style.display = 'none';
        document.getElementById('user').style.display = 'inline-block';
        nav.querySelector('nav .email span').textContent = 'Dear User :)';
        nav.querySelector('nav .email').style.display = '';
        document.querySelector('#addForm button.add').disabled = false;
        document.querySelectorAll('.catch').forEach(x => {
            if(x.getAttribute('ownerid') == ownerID) x.querySelectorAll('.update, .delete').forEach(b => b.disabled = false);
        });
    }else{
        document.getElementById('guest').style.display = 'inline-block';
        document.getElementById('user').style.display = 'none';
        nav.querySelector('nav .email').style.display = 'none';
        nav.querySelector('nav .email span').textContent = '';
        document.querySelector('#addForm button.add').disabled = true;
        catchesDiv.querySelectorAll('.update, .delete').forEach(b => b.disabled = true);
    } 
    setView('home');
}

function setView(newViewName){
    let newView = sections[newViewName];
    if(newView === currView) return;
    if(currView) currView.style.display = 'none';
    currView = newView;
    currView.style.display = 'inline-block';
}

async function getUserEmail(){
    try {
        let getMethod = reqMethod.get();
        getMethod.headers['X-Authorization'] = getToken();
        let req = await fetch(`${usersURL}/me`, getMethod);
        return '';
    } catch(error){
        window.alert(error);
    }
}

function saveToken(arg){
    if(typeof arg == 'string'){
        localStorage.setItem('fish_token', arg);
    }else{
        localStorage.setItem('fish_token', arg.accessToken);
        localStorage.setItem('fish_ownerID', arg._id);
    }
}

function getToken(){
    return localStorage.getItem('fish_token');
}

function removeLocalData(){
    localStorage.removeItem('fish_token');
    localStorage.removeItem('fish_ownerID');
}
function getOwnerID(){
    return localStorage.getItem('fish_ownerID');
}
function statusValidate(actualStatusCode, errMessage, correctStatus = '200'){
    if(actualStatusCode != correctStatus) throw new Error(errMessage);
}
