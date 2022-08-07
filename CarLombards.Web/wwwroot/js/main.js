$(document).ready(function () {
    let burger = $('.burger');
    let modal = $('.modal');

    if (burger) {
        burger.on('click', function () {
            modal.show();
            $('.close-modal__container').on('click', function () {
                modal.hide();
            });
        });
    };

    let menu = $('.blue-theme .header-nav .nav__item');
    let menuA = $('.blue-theme .header-nav .nav__item a');
    let logo = $('.logo__light');
    let burgerLite = $('.lite__burger');
    let header = $('header');

    $(window).scroll(function () {
        var scroll = $(window).scrollTop();

        if (scroll >= 60) {
            header.addClass("hide");
            menuA.addClass('changed__dark');
            menu.addClass('changed__dark');
            logo.addClass('logo__dark');
            burgerLite.addClass('burger__dark');
        } else {
            header.removeClass("hide");
            menuA.removeClass('changed__dark');
            menu.removeClass('changed__dark');
            logo.removeClass('logo__dark');
            burgerLite.removeClass('burger__dark');
        }
    });
});