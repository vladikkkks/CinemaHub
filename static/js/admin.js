// static/js/admin.js
document.addEventListener('DOMContentLoaded', () => {
    const pdfBtn = document.querySelector('.pdf-btn');
    const printBtn = document.querySelector('.print-btn');
    const excelBtn = document.querySelector('.excel-btn');

    // Функція для симуляції генерації звіту через C# бекенд
    function simulateReportGeneration(btn, originalText, successMessage) {
        // Змінюємо текст на стан завантаження
        btn.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Генерація...';
        btn.disabled = true;
        btn.style.opacity = '0.7';

        // Імітуємо затримку сервера (1.5 секунди)
        setTimeout(() => {
            btn.innerHTML = `<i class="fas fa-check-circle"></i> ${successMessage}`;
            btn.style.backgroundColor = '#38a169'; // Зелений колір успіху
            btn.style.opacity = '1';

            // Повертаємо кнопку в початковий стан через 3 секунди
            setTimeout(() => {
                btn.innerHTML = originalText;
                btn.disabled = false;
                btn.style.backgroundColor = ''; // Скидаємо інлайн стиль
            }, 3000);
        }, 1500);
    }

    // Прив'язка подій до кнопок
    if(pdfBtn) {
        pdfBtn.addEventListener('click', function() {
            simulateReportGeneration(this, '<i class="fas fa-file-pdf"></i> Фінансовий звіт (Crystal Reports)', 'PDF завантажено');
        });
    }

    if(printBtn) {
        printBtn.addEventListener('click', function() {
            simulateReportGeneration(this, '<i class="fas fa-print"></i> Теплова карта залів (RDLC)', 'Відправлено на друк');
        });
    }

    if(excelBtn) {
        excelBtn.addEventListener('click', function() {
            simulateReportGeneration(this, '<i class="fas fa-file-excel"></i> Експорт у Excel', 'Збережено в XLSX');
        });
    }
});