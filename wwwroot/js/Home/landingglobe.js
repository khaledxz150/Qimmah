
function initParticles() {
    const screenWidth = window.innerWidth;

    let particleSize = 3; // default
    let particlesValues = 50;
    if (screenWidth < 400) {
        particleSize = 1;
        particlesValues = 200;
    } else if (screenWidth < 768) {
        particleSize = 1.5;
        particlesValues = 80;
    } else if (screenWidth < 1200) {
        particleSize = 2;
        particlesValues = 60;
    } else {
        particleSize = 3;
    }

    particlesJS('particles-js', {
        particles: {
            number: {
                value: particlesValues ,
                density: {
                    enable: true,
                    value_area: 800
                }
            },
            color: {
                value: "#ffffff"
            },
            shape: {
                type: "circle",
                stroke: {
                    width: 0,
                    color: "#000000"
                }
            },
            opacity: {
                value: 0.5
            },
            size: {
                value: particleSize
            },
            move: {
                enable: true,
                speed: 2
            }
        },
        interactivity: {
            events: {
                onhover: {
                    enable: true,
                    mode: "repulse"
                }
            }
        },
        retina_detect: true
    });
}


document.addEventListener("DOMContentLoaded", () => {
    const svgObject = document.getElementById("globesvg");
    const paths = Array.from(svgObject.querySelectorAll('path'));
    const specialPath = document.getElementById("theSpecialOne");


    requestAnimationFrame(() => {
        // Set initial state
        gsap.set(paths.filter(p => p !== specialPath), {
            opacity: 0.5,
            scale: 1,
            x: () => (Math.random() - 0.1) * 120,
            y: () => (Math.random() - 0.1) * 120,
            rotation: () => (Math.random() - 0.5) * 45
        });
        setTimeout(() => {
            gsap.to(svgObject, { opacity: 1, duration: 0.5 });
        },10 );
        

        // Animate non-special paths
        gsap.to(paths.filter(p => p !== specialPath), {
            opacity: 1,
            x: 0,
            y: 0,
            rotation: 0,
            duration: 1,
            ease: "power2.out"
        });

        // Animate the special path
        gsap.to(specialPath, {
            opacity: 1,
            x: -10,
            y: -10,
            scale: 3,
            rotation: 0,
            duration: 1,
            ease: "power2.out",
            attr: { filter: "url(#shadowFilter)" }
        });


        // Initialize tooltip
        new bootstrap.Tooltip(specialPath);
        initParticles();
    });
});

window.addEventListener('resize', () => {
    // Remove existing particles
    if (window.pJSDom && window.pJSDom.length) {
        window.pJSDom[0].pJS.fn.vendors.destroypJS();
        window.pJSDom = [];
    }
    initParticles();
});