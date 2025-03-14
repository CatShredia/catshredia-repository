<!DOCTYPE html>
<html lang="ru">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Простая Страница</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
            color: #333;
        }

        header {
            background-color: #333;
            color: #fff;
            padding: 20px;
            text-align: center;
        }

        nav {
            background-color: #eee;
            padding: 10px;
        }

        nav ul {
            list-style: none;
            padding: 0;
            margin: 0;
            display: flex;
            justify-content: space-around;
        }

        nav a {
            text-decoration: none;
            color: #333;
            font-weight: bold;
        }

        main {
            padding: 20px;
            max-width: 800px;
            margin: 0 auto;
            background-color: #fff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h1 {
            margin-top: 0;
        }

        footer {
            background-color: #333;
            color: #fff;
            text-align: center;
            padding: 10px;
            position: fixed;
            /* Фиксируем футер внизу */
            bottom: 0;
            width: 100%;
        }
    </style>
</head>

<body>

    <header>
        <h1>Добро пожаловать на мою страницу!</h1>
    </header>

    <nav>
        <ul>
            <li><a href="#">Главная</a></li>
            <li onclick="redirect('/form')"><a href="#">Проверка</a></li>
            <li><a href="#">Услуги</a></li>
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