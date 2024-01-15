const button = document.querySelector('.search button');

button?.addEventListener('click', () => {


    button.classList.add('clicked');

    setTimeout(() => {
        button.classList.remove('clicked');
    }, 50);

});

