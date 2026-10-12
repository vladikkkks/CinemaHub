// Зміна стилю навігації при скролі
window.addEventListener('scroll', () => {
    const nav = document.querySelector('.navbar');
    if (window.scrollY > 50) {
        nav.style.background = 'rgba(15, 15, 17, 0.98)';
        nav.style.boxShadow = '0 4px 15px rgba(0,0,0,0.5)';
    } else {
        nav.style.background = 'rgba(15, 15, 17, 0.8)';
        nav.style.boxShadow = 'none';
    }
});

// Плавний скрол для кнопок (наприклад "Дивитись афішу")
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        document.querySelector(this.getAttribute('href')).scrollIntoView({
            behavior: 'smooth'
        });
    });
});