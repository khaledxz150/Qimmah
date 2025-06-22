// --- Countdown Timer ---
const countdownDate = new Date("2025-09-11T00:00:00Z").getTime();

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
    clearIntervalt(imerInterval);
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
  $(".select2").each(function () {
    var $element = $(this);
    var permanentLabel = $element.data("permanent-label");

    if (permanentLabel) {
      $element.select2({
        theme: "bootstrap-5",
        placeholder: "الرجاء الاختيار",
        templateSelection: function (data) {
          if (data.id === "") {
            return data.text;
          }
          return permanentLabel + ": " + data.text;
        },
        templateResult: function (data) {
          return data.text; // Keep dropdown options normal
        },
      });
    }
  });
}
document.addEventListener("DOMContentLoaded", function () {
  new TabManager();
  InitializeSelect2();
  let lang = getCookie("LanguageID");
  if (!lang) {
    lang = "2"; // Arabic by default
    setCookie("LanguageID", lang, 30);
  }

  const langSelectors = ["langSelector", "langSelectorMobile"];

  langSelectors.forEach((id) => {
    const el = document.getElementById(id);
    if (el) {
      // Set the value
      el.value = lang;
    }
  } );


    initTextOverflow()
});

function setCookie(name, value, days) {
  let expires = "";
  if (days) {
    const date = new Date();
    date.setTime(date.getTime() + days * 24 * 60 * 60 * 1000);
    expires = "; expires=" + date.toUTCString();
  }

  document.cookie = name + "=" + (value || "") + expires + "; path=/";

  // Send fetch request to update language on server side
  const formData = new FormData();
  formData.append("LanguageId", value);

  fetch("/Home/ChangeLanguageID", {
    method: "POST",
    headers: {
      RequestVerificationToken: getAntiForgeryToken(),
    },
    body: formData,
  })
    .then((response) => {
      if (!response.ok) throw new Error("Failed to update language");
      return response.text();
    })
    .then(() => location.reload())
    .catch((error) => console.error("Language change failed:", error));
}

// Utility to get the anti-forgery token if you're using [ValidateAntiForgeryToken]
function getAntiForgeryToken() {
  const token = document.querySelector(
    'input[name="__RequestVerificationToken"]'
  );
  return token ? token.value : "";
}

// Helper to get cookie
function getCookie(name) {
  let nameEQ = name + "=";
  let ca = document.cookie.split(";");
  for (let i = 0; i < ca.length; i++) {
    let c = ca[i];
    while (c.charAt(0) == " ") c = c.substring(1, c.length);
    if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
  }
  return null;
}

// On change, set cookie and notify backend
function ChangeCookieValue(sender, isMobile) {
  setCookie("LanguageID", sender.value, 30);
}

function toggleMobileMenu() {
  const burger = document.querySelector(".burger-menu");
  const mobileMenu = document.getElementById("mobileMenu");

  burger.classList.toggle("active");
  mobileMenu.classList.toggle("active");

  // Prevent body scroll when menu is open
  if (mobileMenu.classList.contains("active")) {
    document.body.style.overflow = "hidden";
  } else {
    document.body.style.overflow = "auto";
  }
}

function closeMobileMenu() {
  const burger = document.querySelector(".burger-menu");
  const mobileMenu = document.getElementById("mobileMenu");

  burger.classList.remove("active");
  mobileMenu.classList.remove("active");
  document.body.style.overflow = "auto";
}

// Close mobile menu when clicking on a link
document.querySelectorAll(".mobile-menu a").forEach((link) => {
  link.addEventListener("click", () => {
    closeMobileMenu();
  });
});

// Close mobile menu when clicking outside (but not on burger or close button)
document.addEventListener("click", (e) => {
  const burger = document.querySelector(".burger-menu");
  const mobileMenu = document.getElementById("mobileMenu");
  const closeButton = document.querySelector(".mobile-menu-close");

  if (
    !burger.contains(e.target) &&
    !mobileMenu.contains(e.target) &&
    e.target !== closeButton
  ) {
    closeMobileMenu();
  }
});

// Close mobile menu with Escape key
document.addEventListener("keydown", (e) => {
  if (e.key === "Escape") {
    const mobileMenu = document.getElementById("mobileMenu");
    if (mobileMenu.classList.contains("active")) {
      closeMobileMenu();
    }
  }
});

// Handle window resize
window.addEventListener("resize", () => {
  if (window.innerWidth > 768) {
    closeMobileMenu();
  }
});

class TabManager {
  ACTIVE_CLASS = "active";
  COOKIE_NAME = "ActiveTab";
  constructor() {
    this.initializeActiveTab();
  }
  getCookie(name) {
    let value = `${document.cookie}`;
    let parts = value.substr(
      value.indexOf(this.COOKIE_NAME) + (this.COOKIE_NAME.length + 1)
    );
    return parts;
  }
  initializeActiveTab() {
    let activeTab = this.getCookie(this.COOKIE_NAME) || "Home";
    if (!activeTab) return;
    document.querySelectorAll(".nav-item").forEach((item) => {
      item.classList.remove(this.ACTIVE_CLASS);
    });
    let tabElement = document.querySelector(
      `.nav-item[data-tab="${activeTab}"]`
    );
    if (tabElement) {
      tabElement.classList.add(this.ACTIVE_CLASS);
    }
  }
}


function showLoading() {
    // Show overlay loading for initial load or major changes
    $('#loading-overlay').removeClass('d-none');

    // Add loading classes to content
    $('#program-cards-container').addClass('content-loading');
    $('.pagination-container').addClass('content-loading');

    // Show skeleton loading for quick feedback
    $('#program-cards-container').html(`
                <div class="col-md-4 mb-4"><div class="cards-loading"></div></div>
                <div class="col-md-4 mb-4"><div class="cards-loading"></div></div>
                <div class="col-md-4 mb-4"><div class="cards-loading"></div></div>
            `);

    $('.pagination-container').html('<div class="pagination-loading"></div>');
}

function hideLoading() {
    $('#loading-overlay').addClass('d-none');
    $('#program-cards-container').removeClass('content-loading');
    $('.pagination-container').removeClass('content-loading');
}
