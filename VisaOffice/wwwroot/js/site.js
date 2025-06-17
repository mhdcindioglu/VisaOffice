// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Fixed Navbar on Scroll
document.addEventListener('DOMContentLoaded', function() {
    const navbar = document.querySelector('.navbar');
    const body = document.body;
    let lastScrollTop = 0;
    const scrollThreshold = 100; // Pixels to scroll before fixing navbar
    
    if (!navbar) return; // Exit if navbar doesn't exist
    
    function handleScroll() {
        const scrollTop = window.pageYOffset || document.documentElement.scrollTop;
        
        if (scrollTop > scrollThreshold) {
            // Add fixed position and styling when scrolled down
            if (!navbar.classList.contains('navbar-fixed')) {
                navbar.classList.add('navbar-fixed', 'navbar-scrolled');
                body.classList.add('body-offset');
            }
        } else {
            // Remove fixed position when at top
            if (navbar.classList.contains('navbar-fixed')) {
                navbar.classList.remove('navbar-fixed', 'navbar-scrolled');
                body.classList.remove('body-offset');
            }
        }
        
        lastScrollTop = scrollTop <= 0 ? 0 : scrollTop;
    }
    
    // Throttle scroll events for better performance
    let ticking = false;
    function requestTick() {
        if (!ticking) {
            requestAnimationFrame(handleScroll);
            ticking = true;
            setTimeout(() => { ticking = false; }, 16); // ~60fps
        }
    }
    
    // Initial check in case page is already scrolled
    handleScroll();
    
    // Add scroll event listener
    window.addEventListener('scroll', requestTick, { passive: true });
    
    // Handle window resize to adjust body offset
    window.addEventListener('resize', function() {
        if (navbar.classList.contains('navbar-fixed')) {
            // Recalculate offset if navbar is fixed
            const navbarHeight = navbar.offsetHeight;
            document.documentElement.style.setProperty('--navbar-height', navbarHeight + 'px');
        }
    }, { passive: true });
});
