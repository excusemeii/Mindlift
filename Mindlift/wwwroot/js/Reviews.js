document.addEventListener('DOMContentLoaded', () => {
    const title = document.querySelector('.page-title');
    const cards = document.querySelectorAll('.review-card');

    setTimeout(() => {
        title.style.opacity = '1';
        title.style.transform = 'translateY(0)';
    }, 300);

    cards.forEach((card, index) => {
        setTimeout(() => {
            card.style.opacity = '1';
            card.style.transform = 'translateY(0)';
        }, 500 + (index * 100));
    });

    function isInViewport(element) {
        const rect = element.getBoundingClientRect();
        return (
            rect.top >= 0 &&
            rect.left >= 0 &&
            rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
            rect.right <= (window.innerWidth || document.documentElement.clientWidth)
        );
    }

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

document.addEventListener('DOMContentLoaded', () => {

    const container = document.querySelector('.edit-review-container');

    setTimeout(() => {
        container.style.opacity = '1';
        container.style.transform = 'translateY(0)';
    }, 300);

    const submitBtn = document.querySelector('.btn-submit');

    submitBtn.addEventListener('mouseenter', () => {
        submitBtn.style.transform = 'translateY(-2px)';
    });

    submitBtn.addEventListener('mouseleave', () => {
        submitBtn.style.transform = 'translateY(0)';
    });

});

document.addEventListener('DOMContentLoaded', () => {

    const actionButtons = document.querySelectorAll('.action-buttons a');

    actionButtons.forEach(button => {
        button.addEventListener('mouseenter', () => {
            button.style.transform = 'translateY(-2px)';
        });

        button.addEventListener('mouseleave', () => {
            button.style.transform = 'translateY(0)';
        });
    });
});


document.addEventListener('DOMContentLoaded', function () {
    
    const deleteForm = document.querySelector('form');

    if (deleteForm) {
        deleteForm.addEventListener('submit', function (event) {
            const userConfirmed = confirm('Are you sure you want to delete this review?');
            if (!userConfirmed) {
                event.preventDefault(); 
            }
        });
    }
});

document.addEventListener('DOMContentLoaded', () => {
    
    const container = document.querySelector('.create-review-container');
    setTimeout(() => {
        container.style.opacity = '1';
        container.style.transform = 'translateY(0)';
    }, 300);

    
    const dateInput = document.querySelector('input[type="date"]');
    if (dateInput) {
        const today = new Date().toISOString().split('T')[0];
        dateInput.value = today;
    }

    
    const submitBtn = document.querySelector('.btn-submit');
    submitBtn.addEventListener('mouseenter', () => {
        submitBtn.style.transform = 'translateY(-2px)';
    });
    submitBtn.addEventListener('mouseleave', () => {
        submitBtn.style.transform = 'translateY(0)';
    });
});
