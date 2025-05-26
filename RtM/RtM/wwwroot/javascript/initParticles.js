window.initParticles = function () {
    if (window.Particles && typeof window.Particles.init === "function") {
        Particles.init({
            selector: '.background',
            responsive: [
                {
                    breakpoint:
                        880
                    ,
                    options: {
                        maxParticles:
                            70
                        ,
                        connectParticles:
                            true
                    }
                },
                {
                    breakpoint:
                        440
                    ,
                    options: {
                        maxParticles:
                            40
                        ,
                        connectParticles:
                            true
                    }
                },
            ]
        });
    } else {
        console.error("Particles.js is not loaded or not available.");
    }
};