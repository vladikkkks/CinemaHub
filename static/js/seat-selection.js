const container = document.querySelector('.seating-grid');
const seats = document.querySelectorAll('.row .seat:not(.occupied)');
const count = document.getElementById('count');
const total = document.getElementById('total');
const checkoutBtn = document.getElementById('checkout-btn');

// Базова ціна квитка для цього сеансу
let ticketPrice = 220;

// Оновлення лічильника та суми
function updateSelectedCount() {
    const selectedSeats = document.querySelectorAll('.row .seat.selected');
    const selectedSeatsCount = selectedSeats.length;

    count.innerText = selectedSeatsCount;
    total.innerText = selectedSeatsCount * ticketPrice;

    // Активуємо кнопку оплати тільки якщо обрано хоча б одне місце
    if (selectedSeatsCount > 0) {
        checkoutBtn.removeAttribute('disabled');
        checkoutBtn.style.opacity = '1';
        checkoutBtn.style.cursor = 'pointer';
    } else {
        checkoutBtn.setAttribute('disabled', 'true');
        checkoutBtn.style.opacity = '0.5';
        checkoutBtn.style.cursor = 'not-allowed';
    }
}

// Клік по місцю
container.addEventListener('click', (e) => {
    if (e.target.classList.contains('seat') && !e.target.classList.contains('occupied')) {
        e.target.classList.toggle('selected');
        updateSelectedCount();
    }
});

// Симуляція оплати
checkoutBtn.addEventListener('click', () => {
    alert(`Успішно! Ви придбали квитків: ${count.innerText} на суму ${total.innerText} грн. Після підключення бекенду тут формуватиметься чек.`);
    // Очищення вибору після "оплати"
    document.querySelectorAll('.row .seat.selected').forEach(seat => {
        seat.classList.remove('selected');
        seat.classList.add('occupied');
    });
    updateSelectedCount();
});