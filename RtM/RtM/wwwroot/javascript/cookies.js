window.setThemeInCookie = (theme) => {
    const expires = new Date();
    expires.setTime(expires.getTime() + (1 * 60 * 60 * 1000)); // 1 hour
    document.cookie = `theme=${theme}; path=/; Secure; HttpOnly; SameSite=Strict; Expires=${expires.toUTCString()}`;
};

window.getThemeFromCookie = () => {
    const name = 'theme=';
    const decodedCookie = decodeURIComponent(document.cookie);
    const ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) === ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) === 0) {
            return c.substring(name.length, c.length);
        }
    }
    return null;
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