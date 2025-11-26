window.setThemeInLocalStorage = (theme) => {
    localStorage.setItem('theme', theme);
};

window.getThemeFromLocalStorage = () => {
    return localStorage.getItem('theme');
};

window.getPrefersDarkScheme = () => {
    return window.matchMedia("(prefers-color-scheme: dark)").matches;
};

window.toggleDarkMode = (isDark) => {
    if (isDark) {
        document.documentElement.classList.add('dark');
    } else {
        document.documentElement.classList.remove('dark');
    }
    return null;
};