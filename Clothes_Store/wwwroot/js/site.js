// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let slideIndex = 1;
showSlides(slideIndex);

// Next/previous controls
function plusSlides(n) {
    showSlides((slideIndex += n));
}

function showSlides(n) {
    let slides = document.getElementsByClassName("mySlides");
    if (n > slides.length) {
        slideIndex = 1;
    }
    if (n < 1) {
        slideIndex = slides.length;
    }
    for (let i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    slides[slideIndex - 1].style.display = "block";
    /* dots[slideIndex-1].className += " active"; */
    /* dots[slideIndex-1].className.add("active"); */
}

$(document).ready(function () {
    $(".slider").slick({
        arrows: false,
        dots: true,
        slidesToShow: 4,
        autoplay: false,
        speed: 1000,
        autoplaySpeed: 800,
        responsive: [
            {
                breakpoint: 1600,
                settings: {
                    slidesToShow: 3,
                },
            },
            {
                breakpoint: 768,
                settings: {
                    slidesToShow: 2,
                },
            },
            {
                breakpoint: 550,
                settings: {
                    slidesToShow: 1,
                },
            },
        ],
    });
});

const toggle = document.querySelector(".toggle");
const menu = document.querySelector(".menu");
const items = document.querySelectorAll(".item");

//toggle mobile menu
function toggleMenu() {
    if (menu.classList.contains("active")) {
        menu.classList.remove("active");
        toggle.querySelector("a").innerHTML = "<i class='fas fa-bars'></i>";
    } else {
        menu.classList.add("active");
        toggle.querySelector("a").innerHTML = "<i class='fas fa-times'></i>";
    }
}

//Activate Submenu
function toggleItem() {
    if (this.classList.contains("submenu-active")) {
        this.classList.remove("submenu-active");
    } else if (menu.querySelector(".submenu-active")) {
        menu.querySelector(".submenu-active").classList.remove("submenu-active");
        this.classList.add("submenu-active");
    } else {
        this.classList.add("submenu-active");
    }
}

//event listeners
toggle.addEventListener("click", toggleMenu, false);
for (let item of items) {
    if (item.querySelector(".submenu")) {
        item.addEventListener("click", toggleItem, false);
    }
    item.addEventListener("keypress", toggleItem, false);
}
//// JUST A SLIDER

// MULTY ITEM SLIDER STARTS HERE

console.log("================================");

