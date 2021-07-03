function solve() {
    let addElementContainer = document.querySelector('div.action');
    let addLectureButtonElement = addElementContainer.querySelector('button');
    let modulesContainer = document.querySelector('div.modules');
    addLectureButtonElement.addEventListener('click', addLectureClick);
    let addlements = {
        lectureName: addElementContainer.querySelector('input[name="lecture-name"]'),
        lectureDate: addElementContainer.querySelector('input[name="lecture-date"]'),
        moduleName: addElementContainer.querySelector('select'),
    }


    function addLectureClick(e){
        e.preventDefault();
        let lectureName = addlements.lectureName.value || false;
        let lectureDate = addlements.lectureDate.value.replace(/-/g, '/').replace(/T/g, ' - ') || false;
        let moduleName  = addlements.moduleName.value === 'Select module' ? false: addlements.moduleName.value;
        if(!lectureName || !lectureDate || !moduleName) return;

        moduleName = `${moduleName.toUpperCase()}-MODULE`
        let moduleElement = findOrCreateModule();
        addLecture(moduleElement.querySelector('ul'));


        function findOrCreateModule(){
            let moduleTitleElement = Array.from(modulesContainer.querySelectorAll('h3'))
                                        .find(h => h.textContent === moduleName);
            
            if(!moduleTitleElement){
                let moduleElement = document.createElement('div');
                moduleElement.classList.add('module');
                moduleElement.appendChild(document.createElement('h3')).textContent = moduleName;
                moduleElement.appendChild(document.createElement('ul')).addEventListener('click', deleteLecture);
                modulesContainer.appendChild(moduleElement);
                return moduleElement;
            }
            return moduleTitleElement.parentElement;
        }
                            
        function addLecture(lectureListElement){
            let liElement = lectureListElement.appendChild(document.createElement('li'));
            liElement.classList.add('flex');
            liElement.appendChild(document.createElement('h4'))
                    .textContent = `${lectureName} - ${lectureDate}`;
            let deleteButton = liElement.appendChild(document.createElement('button'));
            deleteButton.textContent = 'Del';
            deleteButton.classList.add('red');

            Array.from(lectureListElement.querySelectorAll('li'))
                .sort((a, b) => a.textContent.split(' - ')[1].localeCompare(b.textContent.split(' - ')[1]))
                .forEach(li => lectureListElement.appendChild(li));
        }
    }

    function deleteLecture(e){
        if(!e.target.matches('button')) return;

        e.target.parentElement.remove();
        if(!e.currentTarget.querySelector('li')){
            e.currentTarget.parentElement.remove();
        }
    } 

};

result();

let elements = {
    form: document.getElementsByTagName('form')[0],
    name: document.querySelector('input[name="lecture-name"]'),
    date: document.querySelector('input[name="lecture-date"]'),
    module: document.querySelector('select[name="lecture-module"]'),
    addBtn: document.querySelector('form button'),
    modulesDiv: document.querySelector('.modules'),
    moduleList: ()=>Array.from(document.querySelectorAll('.module')),
    listItems: ()=>Array.from(document.querySelectorAll('.flex')),
}

elements.name.value = "DOM";
elements.date.value = "2020-09-28T18:00";
elements.module.value = "Advanced";

elements.addBtn.click();

assert.equal(elements.moduleList()[0].children[0].textContent, 'ADVANCED-MODULE', 'Module name incorrect');

elements.name.value = "Arrays";
elements.date.value = "2020-09-17T18:00";
elements.module.value = "Advanced";

elements.addBtn.click();
assert.equal(elements.moduleList().length, 1, 'Incorrect amount of modules');
assert.equal(elements.listItems()[0].children[0].textContent, 'Arrays - 2020/09/17 - 18:00', 'Incorrect lecture appended');

elements.name.value = "Arrays";
elements.date.value = "2020-09-30T18:30";
elements.module.value = "Fundamentals";

elements.addBtn.click();

assert.equal(elements.listItems()[0].children[1].className, 'red', 'Incorrect className');