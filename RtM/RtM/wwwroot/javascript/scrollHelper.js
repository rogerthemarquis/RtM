window.scrollToSection = function (id) {
    const el = document.getElementById(id);
    const navbar = document.querySelector('header'); // Adjust selector if your navbar is different
    if (el) {
        const navbarHeight = navbar ? navbar.offsetHeight : 0;
        const elementTop = el.getBoundingClientRect().top + window.pageYOffset;
        window.scrollTo({
            top: elementTop - navbarHeight,
            behavior: 'smooth'
        });
    }
};