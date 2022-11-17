tabBtn = document.querySelectorAll('.tab-btn');
tabs = document.querySelectorAll('.tab-item');
tabBtn.forEach((itm) => {
    itm.addEventListener('click', () => {
        currentBtn = itm;
        tabID = currentBtn.getAttribute("data-tab");
        currentTab = document.querySelector(tabID);
        console.log(tabID);

        if (!currentBtn.classList.contains('active')) {
            console.log('siu');
            tabBtn.forEach((itm) => {
                itm.classList.remove('active');
            })
            tabs.forEach((itm) => {
                itm.classList.remove('active');
            })
            currentBtn.classList.add('active');
            currentTab.classList.add('active');
        }

        console.log("dui")
    })
});
$('.dropdown').click(function () {
    $(this).attr('tabindex', 1).focus();
    $(this).toggleClass('active');
    $(this).find('.dropdown-menu').slideToggle(300);
});
$('.dropdown').focusout(function () {
    $(this).removeClass('active');
    $(this).find('.dropdown-menu').slideUp(300);
});
//просто заміняє дроп меню тайтла на вибраний айтем(не обов'язковоє)
/*$('.dropdown .dropdown-menu li').click(function () {
    $(this).parents('.dropdown').find('span').text($(this).text());
    $(this).parents('.dropdown').find('input').attr('value', $(this).attr('id'));
});*/
