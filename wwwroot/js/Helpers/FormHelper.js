// Password validation and strength meter JavaScript
class PasswordValidator {
  constructor() {
    this.init();
  }

  init() {
    document.addEventListener("DOMContentLoaded", () => {
      this.initializePasswordFields();
    });

    // Handle dynamically added password fields
    document.addEventListener("input", (e) => {
      if (e.target.classList.contains("password-input")) {
        this.handlePasswordInput(e.target);
      }
    });

    // Handle password toggle buttons
    document.addEventListener("click", (e) => {
      if (e.target.closest(".password-toggle")) {
        this.togglePasswordVisibility(e.target.closest(".password-toggle"));
      }
    });
  }

  initializePasswordFields() {
    const passwordInputs = document.querySelectorAll(".password-input");
    passwordInputs.forEach((input) => {
      this.setupPasswordField(input);
    });
  }

  setupPasswordField(input) {
    const rules = this.getPasswordRules(input);
    const messages = this.getValidationMessages(input);

    // Store rules and messages on the element for easy access
    input.passwordRules = rules;
    input.validationMessages = messages;

    // Initial validation
    this.validatePassword(input);

    // Setup confirmation field if it exists
    this.setupConfirmationField(input);
  }

  getPasswordRules(input) {
    try {
      const rulesData = input.getAttribute("data-password-rules");
      return rulesData ? JSON.parse(rulesData) : this.getDefaultRules();
    } catch (e) {
      console.warn("Failed to parse password rules:", e);
      return this.getDefaultRules();
    }
  }

  getValidationMessages(input) {
    try {
      const messagesData = input.getAttribute("data-validation-messages");
      return messagesData
        ? JSON.parse(messagesData)
        : this.getDefaultMessages();
    } catch (e) {
      console.warn("Failed to parse validation messages:", e);
      return this.getDefaultMessages();
    }
  }

  getDefaultRules() {
    return {
      minLength: 8,
      maxLength: 128,
      requireUppercase: true,
      requireLowercase: true,
      requireDigits: true,
      requireSpecialChars: true,
      minUppercase: 1,
      minLowercase: 1,
      minDigits: 1,
      minSpecialChars: 1,
    };
  }

  getDefaultMessages() {
    return {
      weakPassword: "Password is too weak",
      passwordMismatch: "Passwords do not match",
      showPassword: "Show password",
      hidePassword: "Hide password",
      veryWeak: "Very Weak",
      weak: "Weak",
      fair: "Fair",
      good: "Good",
      strong: "Strong",
    };
  }

  handlePasswordInput(input) {
    this.validatePassword(input);
    this.updateStrengthMeter(input);
    this.updateRequirements(input);
    this.validateConfirmation(input);
  }

  validatePassword(input) {
    const password = input.value;
    const rules = input.passwordRules || this.getPasswordRules(input);
    const isValid = this.checkPasswordStrength(password, rules).isValid;

    // Update input validation state
    input.classList.toggle("is-valid", isValid && password.length > 0);
    input.classList.toggle("is-invalid", !isValid && password.length > 0);

    return isValid;
  }

  checkPasswordStrength(password, rules) {
    if (!password) {
      return { score: 0, isValid: false, strength: "veryWeak" };
    }

    let score = 0;
    let isValid = true;
    const feedback = [];

    // Length check
    if (password.length >= rules.minLength) {
      score += 20;
    } else {
      isValid = false;
      feedback.push(`Minimum ${rules.minLength} characters required`);
    }

    if (password.length <= rules.maxLength) {
      score += 15;
    } else {
      isValid = false;
      feedback.push(`Maximum ${rules.maxLength} characters allowed`);
    }

    // Character type checks
    const uppercaseCount = (password.match(/[A-Z]/g) || []).length;
    const lowercaseCount = (password.match(/[a-z]/g) || []).length;
    const digitCount = (password.match(/[0-9]/g) || []).length;
    const specialCount = (password.match(/[^a-zA-Z0-9]/g) || []).length;

    // Uppercase validation
    if (rules.requireUppercase) {
      if (uppercaseCount >= rules.minUppercase) {
        score += 15;
      } else {
        isValid = false;
        feedback.push(
          `At least ${rules.minUppercase} uppercase letter(s) required`
        );
      }
    }

    // Lowercase validation
    if (rules.requireLowercase) {
      if (lowercaseCount >= rules.minLowercase) {
        score += 15;
      } else {
        isValid = false;
        feedback.push(
          `At least ${rules.minLowercase} lowercase letter(s) required`
        );
      }
    }

    // Digit validation
    if (rules.requireDigits) {
      if (digitCount >= rules.minDigits) {
        score += 15;
      } else {
        isValid = false;
        feedback.push(`At least ${rules.minDigits} digit(s) required`);
      }
    }

    // Special character validation
    if (rules.requireSpecialChars) {
      if (specialCount >= rules.minSpecialChars) {
        score += 17;
      } else {
        isValid = false;
        feedback.push(
          `At least ${rules.minSpecialChars} special character(s) required`
        );
      }
    }

    // Additional scoring for complexity
    if (password.length >= rules.minLength + 4) score += 5;
    if (uppercaseCount > rules.minUppercase) score += 3;
    if (lowercaseCount > rules.minLowercase) score += 3;
    if (digitCount > rules.minDigits) score += 3;
    if (specialCount > rules.minSpecialChars) score += 3;

    // Determine strength level
    let strength = "veryWeak";
    if (score >= 90) strength = "strong";
    else if (score >= 70) strength = "good";
    else if (score >= 50) strength = "fair";
    else if (score >= 30) strength = "weak";

    return { score, isValid, strength, feedback };
  }

  updateStrengthMeter(input) {
    const strengthMeter = document.querySelector(
      `.password-strength-meter[data-target="${input.id}"]`
    );
    if (!strengthMeter) return;

    const password = input.value;
    const rules = input.passwordRules || this.getPasswordRules(input);
    const messages =
      input.validationMessages || this.getValidationMessages(input);
    const result = this.checkPasswordStrength(password, rules);

    const strengthFill = strengthMeter.querySelector(".strength-fill");
    const strengthText = strengthMeter.querySelector(".strength-text");

    if (!password) {
      strengthFill.style.width = "0%";
      strengthFill.className = "strength-fill";
      strengthText.textContent = "";
      return;
    }

    // Update progress bar
    const percentage = Math.min(result.score, 100);
    strengthFill.style.width = `${percentage}%`;

    // Update classes and text
    strengthFill.className = `strength-fill strength-${result.strength}`;
    strengthText.textContent = messages[result.strength] || result.strength;
    strengthText.className = `strength-text text-${result.strength}`;
  }

  updateRequirements(input) {
    const requirementsContainer = document.querySelector(
      `.password-requirements[data-target="${input.id}"]`
    );
    if (!requirementsContainer) return;

    const password = input.value;
    const rules = input.passwordRules || this.getPasswordRules(input);
    const requirementItems =
      requirementsContainer.querySelectorAll(".requirement-item");

    requirementItems.forEach((item, index) => {
      const isValid = this.validateRequirement(password, rules, index);
      item.classList.toggle("valid", isValid);
      item.classList.toggle("invalid", !isValid && password.length > 0);
    });
  }

  validateRequirement(password, rules, index) {
    if (!password) return false;

    switch (index) {
      case 0: // Length
        return (
          password.length >= rules.minLength &&
          password.length <= rules.maxLength
        );
      case 1: // Uppercase
        return (
          !rules.requireUppercase ||
          (password.match(/[A-Z]/g) || []).length >= rules.minUppercase
        );
      case 2: // Lowercase
        return (
          !rules.requireLowercase ||
          (password.match(/[a-z]/g) || []).length >= rules.minLowercase
        );
      case 3: // Digits
        return (
          !rules.requireDigits ||
          (password.match(/[0-9]/g) || []).length >= rules.minDigits
        );
      case 4: // Special characters
        return (
          !rules.requireSpecialChars ||
          (password.match(/[^a-zA-Z0-9]/g) || []).length >=
            rules.minSpecialChars
        );
      default:
        return true;
    }
  }

  setupConfirmationField(passwordInput) {
    const confirmationInput = document.querySelector(
      `#${passwordInput.id}Confirmation, #Confirm${passwordInput.id}, input[name="${passwordInput.name}Confirmation"]`
    );
    if (confirmationInput) {
      confirmationInput.addEventListener("input", () => {
        this.validateConfirmation(passwordInput);
      });
    }
  }

  validateConfirmation(passwordInput) {
    if (!passwordInput) return;

    const confirmationInput = document.querySelector(
      `#${passwordInput.id}Confirmation, #Confirm${passwordInput.id}, input[name="${passwordInput.name}Confirmation"]`
    );
    if (!confirmationInput) return;

    const password = passwordInput.value;
    const confirmation = confirmationInput.value;
    const messages =
      passwordInput.validationMessages || getValidationMessages(passwordInput); // assumes this function exists globally

    const isMatch = password === confirmation && confirmation.length > 0;

    // Reset all validation classes first
    confirmationInput.classList.remove("is-valid", "is-invalid");

    if (confirmation.length > 0) {
      confirmationInput.classList.add(isMatch ? "is-valid" : "is-invalid");
    }

    // Feedback message
    let feedback = confirmationInput.parentElement.querySelector(
      ".confirmation-feedback"
    );
    if (!feedback) {
      feedback = document.createElement("div");
      feedback.className = "invalid-feedback confirmation-feedback";
      confirmationInput.parentElement.appendChild(feedback);
    }

    if (!isMatch && confirmation.length > 0) {
      feedback.textContent =
        messages.passwordMismatch || "Passwords do not match";
      feedback.style.display = "block";
    } else {
      feedback.style.display = "none";
    }
  }

  togglePasswordVisibility(button) {
    const targetId = button.getAttribute("data-target");
    const input = document.getElementById(targetId);
    const icon = button.querySelector("i");
    const messages =
      input.validationMessages || this.getValidationMessages(input);

    if (input.type === "password") {
      input.type = "text";
      icon.className = "fas fa-eye-slash";
      button.title = messages.hidePassword || "Hide password";
    } else {
      input.type = "password";
      icon.className = "fas fa-eye";
      button.title = messages.showPassword || "Show password";
    }
  }

  // Public method to validate a specific password field
  validatePasswordField(fieldId) {
    const input = document.getElementById(fieldId);
    if (input && input.classList.contains("password-input")) {
      return this.validatePassword(input);
    }
    return false;
  }

  // Public method to get password strength
  getPasswordStrength(fieldId) {
    const input = document.getElementById(fieldId);
    if (input && input.classList.contains("password-input")) {
      const rules = input.passwordRules || this.getPasswordRules(input);
      return this.checkPasswordStrength(input.value, rules);
    }
    return null;
  }

  // Public method to validate all password fields in a form
  validateAllPasswordFields(formElement = document) {
    const passwordInputs = formElement.querySelectorAll(".password-input");
    let allValid = true;

    passwordInputs.forEach((input) => {
      const isValid = this.validatePassword(input);
      if (!isValid) allValid = false;
    });

    return allValid;
  }
}

// Initialize the password validator
const passwordValidator = new PasswordValidator();

// Export for use in other scripts if needed
if (typeof module !== "undefined" && module.exports) {
  module.exports = PasswordValidator;
} else if (typeof window !== "undefined") {
  window.PasswordValidator = PasswordValidator;
  window.passwordValidator = passwordValidator;
}
