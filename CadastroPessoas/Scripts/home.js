﻿const menu = document.getElementById("menu");
const loginComponent = document.getElementById("login-paragrafo")
const formularioinComponent = document.getElementById("formulario-paragrafo")

Array.from(document.getElementsByClassName("menu-item"))
    .forEach((item, index) => {
        item.onmouseover = () => {
            menu.dataset.activeIndex = index;
        }
    });

formularioinComponent.addEventListener(onload, () => {
})

loginComponent.addEventListener("click", () => {
    loginComponent.style.position = "absolute";
    loginComponent.style.fontSize = "70px";
    loginComponent.style.top = "0";
    loginComponent.style.left = "25px";
    loginComponent.innerText = "Duan";
})