
import { render } from '../node_modules/lit-html/lit-html.js';
import {data  } from './dataServices/dataServise.js';
import { allStudentsTemplate } from './templates/studentTemplates.js';

let studentsContainer = document.getElementById('students');
let studentsObj = await data.get();
let studentsBase = Object.values(studentsObj)
   .map(st => ({fullName: `${st.firstName} ${st.lastName}`,
               email: st.email,
               course: st.course,
               id: st._id}))
render(allStudentsTemplate(studentsBase), studentsContainer);

document.querySelector('#searchBtn').addEventListener('click', onClick);

function onClick() {
   let searchTextInput = document.getElementById('searchField');
   let searchText = searchTextInput.value.toLowerCase();
   let students = studentsBase.map(st => Object.assign({}, st));
   let selected = students.filter(st => 
         Object.values(st).some(v => v.toLowerCase().includes(searchText)));
   selected.forEach(st => st.class = 'select');
   render(allStudentsTemplate(students), studentsContainer);
   document.getElementById('searchField').value = ''
}
