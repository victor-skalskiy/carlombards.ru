document.addEventListener("DOMContentLoaded", function (event) {

    let burger = document.querySelector('.lite__burger');
    let modal = document.querySelector('.modal')
    let closeModal = document.querySelector('.close-modal__container');
    if (burger) {
        burger.addEventListener('click', function () {
            modal.style.display = 'block';
        })
        closeModal.addEventListener('click', function () {
            modal.style.display = 'none';
        })
    }

    $(document).ready(function () {

        var menu = $('.blue-theme .header-nav .nav__item');
        let menuA = $('.blue-theme .header-nav .nav__item a');
        let logo = $('.logo__page');
        $(window).scroll(function () {

            var scroll = $(window).scrollTop();
            if (scroll >= 60) {

                $('header').addClass("hide");
                menuA.addClass('changed__dark');
                menu.addClass('changed__dark');
                logo.addClass("logo__dark");
                burger.style.color = '#000';

            } else {
                $('header').removeClass("hide");
                menuA.removeClass('changed__dark');
                menu.removeClass('changed__dark');
                logo.removeClass("logo__dark");
                burger.style.color = '#fff';
            }
        });
    });



});






