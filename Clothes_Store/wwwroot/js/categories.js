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