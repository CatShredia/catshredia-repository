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

<script src="/scripts/validation.js"></script>