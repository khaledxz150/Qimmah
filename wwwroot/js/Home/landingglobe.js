
particlesJS('particles-js', {
    particles: {
        number: {
            value: 50,
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
            value: 3
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
const svgObject = document.getElementById("globesvg");

svgObject.addEventListener("load", () => {
    const paths = Array.from(svgObject.querySelectorAll('path'));
    const specialPath = document.getElementById("theSpecialOne");


    requestAnimationFrame(() => {
        // Set initial state
        gsap.set(paths.filter(p => p !== specialPath), {
            opacity: 0.1,
            scale: 1,
            x: () => (Math.random() - 0.1) * 120,
            y: () => (Math.random() - 0.1) * 120,
            rotation: () => (Math.random() - 0.5) * 45
        });
        setTimeout(() => {
            gsap.to(svgObject, { opacity: 1, duration: 0.5 });
        },100 );
        

        // Animate non-special paths
        gsap.to(paths.filter(p => p !== specialPath), {
            opacity: 1,
            x: 0,
            y: 0,
            rotation: 0,
            duration: 3,
            ease: "power2.out"
        });

        // Animate the special path
        gsap.to(specialPath, {
            opacity: 1,
            x: -10,
            y: -10,
            scale: 3,
            rotation: 0,
            duration: 3,
            ease: "power2.out",
            attr: { filter: "url(#shadowFilter)" }
        });


        // Initialize tooltip
        new bootstrap.Tooltip(specialPath);
    });
});
