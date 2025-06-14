document.addEventListener("DOMContentLoaded", function () {
  // Initialize form validation
  const form = document.getElementById("registrationForm");
  const submitBtn = document.getElementById("submitBtn");

  // Enhanced form submission validation
  form.addEventListener("submit", function (e) {
    e.preventDefault();

    // Validate all password fields
    const allPasswordsValid =
      window.passwordValidator.validateAllPasswordFields(form);

    // Check if passwords match
    const password = document.getElementById("Password");
    const confirmation = document.getElementById("PasswordConfirmation");
    const passwordsMatch = password.value === confirmation.value;

    // Validate other required fields
    const requiredFields = form.querySelectorAll("[required]");
    let allRequiredValid = true;

    requiredFields.forEach((field) => {
      if (!field.value.trim()) {
        field.classList.add("is-invalid");
        allRequiredValid = false;
      } else {
        field.classList.remove("is-invalid");
        field.classList.add("is-valid");
      }
    });

    // Show validation summary
    if (!allPasswordsValid || !passwordsMatch || !allRequiredValid) {
      showValidationSummary();
      return false;
    }

      submitBtn.disabled = true;
      debugger;
    handleAjaxForms(form, e);
  });

  // Real-time validation feedback
  const inputs = form.querySelectorAll("input:not(.password-input)");
  inputs.forEach((input) => {
    input.addEventListener("blur", function () {
      validateField(this);
    });
  });

  // Password strength validation
  const passwordField = document.getElementById("Password");
  if (passwordField) {
    passwordField.addEventListener("input", function () {
      // Update confirmation field validation when password changes
      setTimeout(() => {
        window.passwordValidator.validateConfirmation(passwordField);
      }, 100);
    });
  }

  function validateField(field) {
    if (field.hasAttribute("required") && !field.value.trim()) {
      field.classList.add("is-invalid");
      field.classList.remove("is-valid");
    } else if (field.type === "email" && field.value) {
      const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
      if (emailRegex.test(field.value)) {
        field.classList.add("is-valid");
        field.classList.remove("is-invalid");
      } else {
        field.classList.add("is-invalid");
        field.classList.remove("is-valid");
      }
    } else if (field.value.trim()) {
      field.classList.add("is-valid");
      field.classList.remove("is-invalid");
    }
  }

  function showValidationSummary() {
    // Remove existing validation summary
    const existingSummary = document.querySelector(".validation-summary");
    if (existingSummary) {
      existingSummary.remove();
    }

    // Scroll to summary
    summary.scrollIntoView({ behavior: "smooth", block: "center" });

    // Auto-remove after 10 seconds
    setTimeout(() => {
      if (summary.parentElement) {
        summary.remove();
      }
    }, 10000);
  }
});
