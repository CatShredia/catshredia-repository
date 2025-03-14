<!DOCTYPE html>
<html lang="ru">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Простая Страница</title>

    <link rel="stylesheet" href="/rec/styles.php">
</head>

<body>
    <header>
        <h1>Добро пожаловать на мою страницу!</h1>
    </header>

    <nav>
        <ul>
            <li><a href="#">Главная</a></li>
            <li><a href="<?php echo htmlspecialchars('/form') ?>">Валидация</a></li>
            <li><a href="<?php echo htmlspecialchars('/db') ?>">DB</a></li>
            <li><a href="#">Контакты</a></li>
        </ul>
    </nav>

    <main>
        <h2>Это заголовок основного контента</h2>
        <p>Это простой параграф. Вы можете добавить сюда больше контента, например текст, изображения и видео. Это просто пример страницы, демонстрирующий основы HTML и CSS.</p>
        <p>Еще один параграф, чтобы показать, как выглядит текст.</p>
    </main>

    <footer>
        &copy; 2023 Моя Простая Страница
    </footer>

</body>

</html>