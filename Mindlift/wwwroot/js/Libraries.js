document.addEventListener('DOMContentLoaded', () => {
    const title = document.querySelector('.page-title');
    const cards = document.querySelectorAll('.book-card');

    // Animate title
    setTimeout(() => {
        title.style.opacity = '1';
        title.style.transform = 'translateY(0)';
    }, 300);

    // Animate cards
    cards.forEach((card, index) => {
        setTimeout(() => {
            card.style.opacity = '1';
            card.style.transform = 'translateY(0)';
        }, 500 + (index * 100));
    });

    // Function to check if element is in viewport
    function isInViewport(element) {
        const rect = element.getBoundingClientRect();
        return (
            rect.top >= 0 &&
            rect.left >= 0 &&
            rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
            rect.right <= (window.innerWidth || document.documentElement.clientWidth)
        );
    }

    // Animate cards on scroll
    function handleScroll() {
        cards.forEach(card => {
            if (isInViewport(card)) {
                card.style.opacity = '1';
                card.style.transform = 'translateY(0)';
            }
        });
    }

    window.addEventListener('scroll', handleScroll);
});
