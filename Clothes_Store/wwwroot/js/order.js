price = document.querySelector('.price_');
btnPlus = document.querySelector('.plus');
btnMinus = document.querySelector('.minus');
count = document.querySelector('.count');
counter = 1;
currentPrice = parseInt(price.textContent);
const data = parseInt(price.textContent);
btnPlus.addEventListener('click', () => {
    currentPrice += data;
    counter += 1;
    price.textContent = `${currentPrice} грн`;
    count.textContent = counter;
    $("#quantity").val(counter);
});
btnMinus.addEventListener('click', () => {
    if (counter == 1) {
        price.textContent = `${currentPrice} грн`;
        count.textContent = counter;
        $("#quantity").val(counter);
    }
    else {
        currentPrice -= data;
        counter -= 1;
    }
    price.textContent = `${currentPrice} грн`;
    count.textContent = counter;
});