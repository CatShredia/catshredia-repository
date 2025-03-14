function validateForm() {
  let name = document.getElementById("name").value;
  let email = document.getElementById("email").value;
  let message = document.getElementById("message").value;

  let nameError = document.getElementById("nameError");
  let emailError = document.getElementById("emailError");
  let messageError = document.getElementById("messageError");

  nameError.innerHTML = "";
  emailError.innerHTML = "";
  messageError.innerHTML = "";

  let isValid = true;

  if (name === "") {
    nameError.innerHTML = "Пожалуйста, введите ваше имя.";
    isValid = false;
  }

  if (email === "") {
    emailError.innerHTML = "Пожалуйста, введите ваш email.";
    isValid = false;
  } else if (!isValidEmail(email)) {
    emailError.innerHTML = "Пожалуйста, введите корректный email.";
    isValid = false;
  }

  if (message === "") {
    messageError.innerHTML = "Пожалуйста, введите ваше сообщение.";
    isValid = false;
  }

  return isValid;
}

function isValidEmail(email) {
  // Простая проверка формата email
  let emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  return emailRegex.test(email);
}
