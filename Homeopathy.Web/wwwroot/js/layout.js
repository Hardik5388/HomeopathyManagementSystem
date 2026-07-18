document.addEventListener("DOMContentLoaded", function () {

    const toggle = document.getElementById("sidebarToggle");

    toggle.addEventListener("click", function () {

        document.body.classList.toggle("sidebar-collapsed");

    });

});