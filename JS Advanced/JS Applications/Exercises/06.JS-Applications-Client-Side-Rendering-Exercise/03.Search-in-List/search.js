import { render } from "../node_modules/lit-html/lit-html.js";
import{towns as townsArr} from './towns.js';
import { townsTemplate } from "./townsTemplates.js";

let towns = townsArr.map(t => ({name: t}));
let townsContainer = document.getElementById('towns');
render(townsTemplate(towns), townsContainer);

let searchButton = document.getElementById('search');
searchButton.addEventListener('click', search);

function search() {
   let searchInput = document.getElementById('searchText');
   let searchText = searchInput.value;
   towns.forEach(town => {
      if(town.name.toLowerCase().includes(searchText.toLowerCase())){
         town.class = 'active';
      }else{
         delete town.class;
      }
   })
   render(townsTemplate(towns), townsContainer);
   document.getElementById('result').textContent = 
      `${towns.filter(t => t.hasOwnProperty('class')).length} matches found`;
}
