function lockedProfile() {
    Array.from(document.querySelectorAll('.profile button'))
        .forEach(b => {
            b.addEventListener('click', showMore);
        });

    function showMore(event){
        let target = event.target;
        let hiddenContainer = target.parentElement.querySelector('div');
        let lockValue = target.parentElement.querySelector('input[type="radio"]:checked').value;
        
        if( lockValue === 'unlock'){
            let show = (target.textContent == 'Show more');
            target.textContent = show?'Hide it':'Show more';
            hiddenContainer.style.display = show?'block': '';
        }
    }
}