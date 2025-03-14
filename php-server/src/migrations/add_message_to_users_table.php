<?php
// Подключение к базе данных
$host = 'mysql';
$username = 'catshredia';
$password = 'password';
$database = 'php_db';

$mysqli = new mysqli($host, $username, $password, $database);

// Проверка соединения
if ($mysqli->connect_errno) {
    echo "Не удалось подключиться к MySQL: " . $mysqli->connect_error;
    exit();
}

// SQL-запрос для добавления колонки `Message` к таблице `users`
$sql = "ALTER TABLE users ADD COLUMN Message TEXT AFTER password;";

// Выполнение запроса
if ($mysqli->query($sql) === TRUE) {
    echo "Колонка 'Message' успешно добавлена к таблице 'users'.";
} else {
    echo "Ошибка при добавлении колонки: " . $mysqli->error;
}

// Закрытие соединения
$mysqli->close();
