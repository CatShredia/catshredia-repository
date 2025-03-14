<!-- ! базовая маршрутизация -->
<?php
require __DIR__ . '/controllers/Controller.php';
require __DIR__ . '/controllers/HomePageController.php';
require __DIR__ . '/controllers/FormPageController.php';

// Получаем URI (часть URL после имени домена)
$uri = $_SERVER['REQUEST_URI'];

// Удаляем параметры запроса (часть после "?")
$uri = strtok($uri, '?');

// Удаляем ведущий и замыкающий слэши
$uri = trim($uri, '/');

// Если URI пустой, устанавливаем значение по умолчанию
if (empty($uri)) {
    $uri = '/'; // Или любое другое значение по умолчанию
}

// первоначальная
RedirectTo($uri);

function RedirectTo($uri)
{
    switch ($uri) {
        case '/':
            $homeController = new HomePageController();
            $homeController->index();
        case 'form':
            $formController = new formPageController();
            $formController->index();
    }
}
