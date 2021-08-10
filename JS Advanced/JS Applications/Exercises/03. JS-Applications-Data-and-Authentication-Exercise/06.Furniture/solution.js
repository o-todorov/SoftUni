import {getAllFurniture} from './scripts/serverServices.js';

let baseFurnitureURL = 'http://localhost:3030/data/furniture';
let userStates = {
  user: 'user',
  guest: 'guest'
}
let state = userStates.guest;
let buyButton = document.querySelector('#index .buy');
buyButton.addEventListener('click', buy);

function buy(e){
  if(state = userStates.guest){

  }
}

function solve() {
  let furniture = getAllFurniture(baseFurnitureURL);
  console.log(furniture);
}

solve();