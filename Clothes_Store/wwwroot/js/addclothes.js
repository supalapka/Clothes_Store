//ADMIN PANEL ADD CLOTHES
//THIS SCRIPT ADDS CHOOSEN IMAGE OF USER? DISPLAYED ON RIGHT DIV
//CLOSES 63E9
let wrapper = document.querySelector('.img_main');

function donwload(input) {
    let file = input.files[0];
    let reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
        img1.src = reader.result;
    }
}