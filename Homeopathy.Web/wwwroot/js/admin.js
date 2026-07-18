document.addEventListener("DOMContentLoaded", function () {

    const sidebar = document.querySelector(".sidebar");
    const mainContent = document.querySelector(".main-content");
    const toggle = document.getElementById("sidebarToggle");

    toggle.addEventListener("click", function () {

        if (window.innerWidth <= 991) {

            // Mobile
            sidebar.classList.toggle("show");

        } else {

            // Desktop
            sidebar.classList.toggle("collapsed");
            mainContent.classList.toggle("collapsed");

        }

    });

});