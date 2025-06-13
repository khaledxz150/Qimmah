// --- Countdown Timer ---
const countdownDate = new Date("Sep 11, 2025 00:00:00").getTime();

const hoursEl = document.getElementById("hours");
const minutesEl = document.getElementById("minutes");
const secondsEl = document.getElementById("seconds");

function updateCountdown() {
  const now = new Date().getTime();
  const distance = countdownDate - now;

  if (distance < 0) {
    hoursEl.textContent = "00";
    minutesEl.textContent = "00";
    secondsEl.textContent = "00";
    clearInterval(timerInterval);
    // Optionally display a message like "Event Started!"
    return;
  }

  const days = Math.floor(distance / (1000 * 60 * 60 * 24));
  const hours =
    Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60)) +
    days * 24; // Add days to hours
  const minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
  const seconds = Math.floor((distance % (1000 * 60)) / 1000);

  hoursEl.textContent = String(hours).padStart(2, "0");
  minutesEl.textContent = String(minutes).padStart(2, "0");
  secondsEl.textContent = String(seconds).padStart(2, "0");
}

if (hoursEl && minutesEl && secondsEl) {
  const timerInterval = setInterval(updateCountdown, 1000);

  updateCountdown(); // Initial call
}
function InitializeSelect2() {
  $(".select2").select2({
    theme: "bootstrap-5",
    placeholder: "الرجاء الاختيار",
  });
}
document.addEventListener("DOMContentLoaded", function () {
  InitializeSelect2();
});
