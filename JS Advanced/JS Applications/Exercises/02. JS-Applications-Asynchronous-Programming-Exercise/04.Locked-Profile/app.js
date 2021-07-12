function lockedProfile() {
    const profilesPath = 'http://localhost:3030/jsonstore/advanced/profiles';
    fetch(profilesPath)
        .then(res => res.json())
        .then(obj => {
            document.querySelector('.profile').remove();
            Object.values(obj).forEach((profile, i) => createProfileHTML(profile, i + 1));
    });

    function createProfileHTML({_id, username, age, email}, idx){
        let div = document.createElement('div');
        div.className = 'profile';
        let img = div.appendChild(document.createElement('img'));
        img.src = `./iconProfile2.png`;
        img.classList.add('userIcon');

        div.appendChild(document.createElement('label')).textContent = 'Lock';
        let lock = div.appendChild(document.createElement('input'));
        lock.type = 'radio';
        lock.name = `user${idx}Locked`;
        lock.value = 'lock';
        lock.checked = true;

        div.appendChild(document.createElement('label')).textContent = 'Unlock';
        let unlock = div.appendChild(document.createElement('input'));
        unlock.type = 'radio';
        unlock.name = `user${idx}Locked`;
        unlock.value = 'unlock';

        div.appendChild(document.createElement('br'));
        div.appendChild(document.createElement('hr'));

        div.appendChild(document.createElement('label')).textContent = 'Username';
        let inputName = div.appendChild(document.createElement('input'));
        inputName.type = 'text';
        inputName.name = `user${idx}Username`;
        inputName.value = username;
        inputName.disabled = true;
        inputName.readOnly = true;

        let hiddenDiv = div.appendChild(document.createElement('div'));
        hiddenDiv.id = `user${idx}HiddenFields`
        hiddenDiv.style.display = 'none';
        hiddenDiv.appendChild(document.createElement('hr'));

        hiddenDiv.appendChild(document.createElement('label')).textContent = 'Email:';
        let inputEmail = hiddenDiv.appendChild(document.createElement('input'));
        inputEmail.type = 'email';
        inputEmail.name = `user${idx}Email`;
        inputEmail.value = email;
        inputEmail.disabled = true;
        inputEmail.readOnly = true;

        hiddenDiv.appendChild(document.createElement('label')).textContent = 'Age:';
        let inputAge = hiddenDiv.appendChild(document.createElement('input'));
        inputAge.type = 'email';
        inputAge.name = `user${idx}Age`;
        inputAge.value = age;
        inputAge.disabled = true;
        inputAge.readOnly = true;

        let moreButton = div.appendChild(document.createElement('button'))
        moreButton.textContent = 'Show more';
        moreButton.setAttribute('username', username);
        moreButton.addEventListener('click', showMoreLess);

        document.querySelector('#main').appendChild(div);

    }

    function showMoreLess(e){
        let button = e.target;
        let profileElem = button.parentElement;
        let isLocked = profileElem.querySelector(`input[type="radio"]:checked`).value == 'lock';

        if(isLocked) return;

        let hiddenDiv = profileElem.querySelector('div');
        let show = (button.textContent == 'Show more');
        button.textContent = show?'Hide it':'Show more';
        hiddenDiv.style.display = show?'block': 'none';
    }
}
