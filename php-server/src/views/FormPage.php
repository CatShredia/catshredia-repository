<!DOCTYPE html>
<html lang="ru">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Форма с Валидацией</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }

        form {
            max-width: 400px;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        label {
            display: block;
            margin-bottom: 5px;
        }

        input[type="text"],
        input[type="email"],
        textarea {
            width: 100%;
            padding: 8px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
            /* Чтобы padding не увеличивал ширину */
        }

        .error {
            color: red;
            margin-bottom: 10px;
        }

        button[type="submit"] {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        button[type="submit"]:hover {
            background-color: #3e8e41;
        }
    </style>
</head>

<body>

    <form id="myForm" onsubmit="return validateForm()">
        <h2>Форма обратной связи</h2>

        <div id="nameError" class="error"></div>
        <label for="name">Имя:</label>
        <input type="text" id="name" name="name">

        <div id="emailError" class="error"></div>
        <label for="email">Email:</label>
        <input type="email" id="email" name="email">

        <div id="messageError" class="error"></div>
        <label for="message">Сообщение:</label>
        <textarea id="message" name="message" rows="4"></textarea>

        <button type="submit">Отправить</button>
    </form>

    <script>
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
    </script>

</body>

</html>