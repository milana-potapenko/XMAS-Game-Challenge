// Toggles visibility of tips (spoiler tags)
document.addEventListener("DOMContentLoaded", () => {
    const toggles = document.querySelectorAll(".spoiler-toggle");

    toggles.forEach(toggle => {
        toggle.addEventListener("click", () => {
            const spoiler = toggle.nextElementSibling;
            if (spoiler) {
                spoiler.classList.toggle("revealed");
            }
        });
    });

    // Initialize snow effect
    generateSnow();
});

// Improved Snow Effect
function generateSnow() {
    const body = document.body;
    const snowflakeCount = 50; // Number of snowflakes
    const snowflakes = [];

    for (let i = 0; i < snowflakeCount; i++) {
        const snowflake = document.createElement("div");
        snowflake.className = "snowflake";
        snowflake.textContent = "❄️";

        // Random initial position and size
        snowflake.style.left = `${Math.random() * 100}vw`;
        snowflake.style.top = `${Math.random() * -100}vh`;
        snowflake.style.fontSize = `${Math.random() * 1.5 + 0.5}rem`;
        snowflake.style.opacity = Math.random() * 0.8 + 0.2;

        // Animation properties
        const duration = Math.random() * 5 + 5; // Fall duration between 5-10 seconds
        const delay = Math.random() * 5; // Random delay
        const horizontalMovement = Math.random() * 50 - 25; // Random horizontal swing

        snowflake.style.animation = `
            snowfall ${duration}s linear ${delay}s infinite,
            sway ${duration / 2}s ease-in-out ${delay}s infinite alternate
        `;

        snowflakes.push(snowflake);
        body.appendChild(snowflake);
    }
}

// Keyframes for snow animation
const styleSheet = document.createElement("style");
styleSheet.innerHTML = `
    @keyframes snowfall {
        0% {
            transform: translateY(-10vh);
        }
        100% {
            transform: translateY(100vh);
        }
    }
    @keyframes sway {
        0% {
            transform: translateX(0);
        }
        100% {
            transform: translateX(25px);
        }
    }
`;
document.head.appendChild(styleSheet);