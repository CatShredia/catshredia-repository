document.addEventListener("DOMContentLoaded", function () {
  const form = document.getElementById("myForm");
  form.addEventListener("submit", function (event) {
    event.preventDefault();
    const textInput = document.getElementById("text_input").value;
    const emailInput = document.getElementById("email_input").value;
    const passwordInput = document.getElementById("password_input").value;
    const numberInput = document.getElementById("number_input").value;
    const dateInput = document.getElementById("date_input").value;
    const timeInput = document.getElementById("time_input").value;
    const datetimeInput = document.getElementById("datetime_input").value;

    let isValid = true;
    let errorMessage = "";
    if (textInput.length < 3) {
      isValid = false;
      errorMessage += "Текстовое поле должно содержать не менее 3 символов.\n";
    }
    if (!validateEmail(emailInput)) {
      isValid = false;
      errorMessage += "Введите корректный email.\n";
    }
    if (passwordInput.length < 8) {
      isValid = false;
      errorMessage += "Пароль должен содержать не менее 8 символов.\n";
    }
    if (numberInput < 1 || numberInput > 100) {
      isValid = false;
      errorMessage += "Число должно быть в диапазоне от 1 до 100.\n";
    }
    if (!dateInput) {
      isValid = false;
      errorMessage += "Выберите дату.\n";
    }
    if (!timeInput) {
      isValid = false;
      errorMessage += "Выберите время.\n";
    }
    if (!datetimeInput) {
      isValid = false;
      errorMessage += "Выберите дату и время.\n";
    }
    if (isValid) {
      alert("Форма успешно отправлена!");
    } else {
      alert("Ошибки валидации:\n" + errorMessage);
    }
  });
  function validateEmail(email) {
    const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(String(email).toLowerCase());
  }
});
