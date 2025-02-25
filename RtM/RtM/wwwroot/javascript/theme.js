window.getMediaQueryMatches = (query) => {
    return window.matchMedia(query).matches;
};

window.toggleDarkMode = (isDark) => {
    if (isDark) {
        document.documentElement.classList.add('dark');
    } else {
        document.documentElement.classList.remove('dark');
    }
};

// Check the user's system preference on initial load
window.applySystemPreference = () => {
    const prefersDarkScheme = window.matchMedia("(prefers-color-scheme: dark)").matches;
    if (prefersDarkScheme) {
        document.documentElement.classList.add('dark');
    } else {
        document.documentElement.classList.remove('dark');
    }
};
