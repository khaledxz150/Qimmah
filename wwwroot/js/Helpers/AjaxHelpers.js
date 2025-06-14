async function handleAjaxForms(form, e) {
    debugger;
    if (e) e.preventDefault();
    var submitButton = $(form).find('button[type="submit"]');
    submitButton.attr("disabled", "disabled");
    // Check form validity using HTML5 validation
    if (!form.checkValidity()) {
        submitButton.removeAttr("disabled");
        e.stopPropagation();
        return;
    }
    form.classList.remove("was-validated");
    // Clear previous errors
    form
        .querySelectorAll(".is-invalid")
        .forEach((el) => el.classList.remove("is-invalid"));
    form
        .querySelectorAll(".invalid-feedback")
        .forEach((el) => (el.textContent = ""));
    // Collect form data
    const formData = {};
    Array.from(form.elements).forEach((el) => {
        if (el.name) formData[el.name] = el.value;
    });
    // Get antiforgery token if present
    const tokenInput = form.querySelector(
        'input[name="__RequestVerificationToken"]'
    );
    const headers = { "Content-Type": "application/json" };
    if (tokenInput) headers["RequestVerificationToken"] = tokenInput.value;
    // Send AJAX request
    const response = await fetch(form.action, {
        method: "POST",
        headers,
        body: JSON.stringify(formData),
    });
    const result = await response.json();
    if (result.success) {
        submitButton.removeAttr("disabled");
        window.location.href = result.redirectUrl || "/";
    } else if (result.errors) {
        for (const key in result.errors) {
            const input = form.querySelector(`[name="${key}"]`);
            if (input) {
                input.classList.add("is-invalid");
                const feedbackDiv = input.closest(".form-group, .mb-3, .form-floating")?.querySelector(".invalid-feedback")
                    || input.parentElement.querySelector(".invalid-feedback");
                if (feedbackDiv) {
                    feedbackDiv.textContent = result.errors[key];
                }

                // Add event listener to reset to original validation on input
                input.addEventListener('input', function resetValidation(e) {
                    e.stopImmediatePropagation();
                    this.classList.remove("is-invalid");
                    const originalMessage = this.getAttribute('data-val-required');
                    if (feedbackDiv && originalMessage) {
                        feedbackDiv.textContent = originalMessage;
                    }
                    this.removeEventListener('input', resetValidation);
                }, { once: true, capture: true });
            }
        }
        form.classList.add("was-validated");
        submitButton.removeAttr("disabled");
    }
}