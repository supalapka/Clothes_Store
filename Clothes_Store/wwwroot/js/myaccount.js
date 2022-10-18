
function calcCartPrice() {
    const cartWrapper = document.querySelector('.cart_wrapper');
    const priceElements = cartWrapper.querySelectorAll('.pricee');
    const totalPriceEl = document.querySelector('.total_price');
    const allPrice = document.querySelector('.all_price');
    const devPrice = document.querySelector('.dev_price');
    let priceTotal = 0;
    priceElements.forEach(function (item) {
        const amountEl = item.closest('.goods_block').querySelector('[data-counter]');
        priceTotal += parseInt(item.innerText) * parseInt(amountEl.innerText);
    });
    totalPriceEl.innerText = priceTotal;
    let delivery_price;
    if (priceTotal >= 900 || priceTotal == 0) {
        delivery_price = 0;
        devPrice.innerText = "Безкоштовна";
        $('.currency').hide();
    } else {
        delivery_price = 45;
        devPrice.innerText = delivery_price;
        $('.currency').show();
    }
    allPrice.innerText = priceTotal + delivery_price;
}


function CartStatus() {
    const cartWrapper = document.querySelector('.cart_wrapper');
    if (cartWrapper.children.length > 0) {
        $('.empty_block').hide();
        $('.final_price').show();
    } else {
        $('.empty_block').show();
        $('.final_price').hide();
    }
}

window.onload = CartStatus(), calcCartPrice();
window.addEventListener('click', function (event) {
    let counter;
    CartStatus();
    if (event.target.dataset.action === 'plus' || event.target.dataset.action === 'minus') {
        const counterWrapper = event.target.closest('.quantity_goods');
        counter = counterWrapper.querySelector('[data-counter]');
    }
    if (event.target.dataset.action === 'plus') {
        counter.innerText = counter.innerText;
        calcCartPrice();
    }
    if (event.target.dataset.action === 'minus') {
        if (parseInt(counter.innerText) > 1) {
            counter.innerText = counter.innerText;
            calcCartPrice();
        } else if (event.target.closest('.quantity_goods') && parseInt(counter.innerText) === 1) {
            event.target.closest('.goods').remove();
        }
        CartStatus();
    }
    if (event.target.dataset.action === 'to_trash') {
        event.target.closest('.goods').remove();
        CartStatus();
    }
});

$(document).ready(function () {
    $('.nav_title').click(function (event) {
        $(this).toggleClass('active').next().slideToggle(300);
    });
});


window.onload = CartStatus(), calcCartPrice();
window.addEventListener('click', function (event) {
    let counter;
    CartStatus();
    if (event.target.dataset.action === 'plus' || event.target.dataset.action === 'minus') {
        const counterWrapper = event.target.closest('.quantity_goods');
        counter = counterWrapper.querySelector('[data-counter]');
    }
    if (event.target.dataset.action === 'plus') {
        counter.innerText = ++counter.innerText;
        calcCartPrice();
    }
    if (event.target.dataset.action === 'minus') {
        if (parseInt(counter.innerText) > 1) {
            counter.innerText = --counter.innerText;
            calcCartPrice();
        } else if (event.target.closest('.quantity_goods') && parseInt(counter.innerText) === 1) {
            event.target.closest('.goods').remove();
            calcCartPrice();
        }
        CartStatus();
    }
    if (event.target.dataset.action === 'to_trash') {
        event.target.closest('.goods').remove();
        CartStatus();
    }
});