async function handleAjaxForms(form, e) {
  debugger;
  if (e) e.preventDefault();

  // Check form validity using HTML5 validation
  if (!form.checkValidity()) {
    form.classList.add("was-validated");
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
    window.location.href = result.redirectUrl || "/";
  } else if (result.errors) {
    for (const key in result.errors) {
      const input = form.querySelector(`[name="${key}"]`);
      const errorDiv = form.querySelector(`#${key}Error`);
      if (input && errorDiv) {
        input.classList.add("is-invalid");
        errorDiv.textContent = result.errors[key];
      }
    }
  }
}
