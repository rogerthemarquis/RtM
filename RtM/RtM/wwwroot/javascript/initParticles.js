window.initParticles = function () {
    if (window.Particles && typeof window.Particles.init === "function") {
        Particles.init({
            selector: '.background'
        });
    } else {
        console.error("Particles.js is not loaded or not available.");
    }
};