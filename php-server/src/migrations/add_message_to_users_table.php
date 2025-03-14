<?php
$host = 'mysql';
$username = 'catshredia';
$password = 'password';
$database = 'php_db';

$mysqli = new mysqli($host, $username, $password, $database);

if ($mysqli->connect_errno) {
    echo "Не удалось подключиться к MySQL: " . $mysqli->connect_error;
    exit();
}

$checkColumnQuery = "SHOW COLUMNS FROM users LIKE 'message'";
$result = $mysqli->query($checkColumnQuery);

if ($result->num_rows > 0) {
    echo "Колонка 'message' уже существует в таблице 'users'.\n";
} else {
    $sql = "ALTER TABLE users ADD COLUMN message TEXT AFTER email;";

    if ($mysqli->query($sql) === TRUE) {
        echo "Колонка 'message' успешно добавлена к таблице 'users'.\n";
    } else {
        echo "Ошибка при добавлении колонки: " . $mysqli->error;
    }
}

$mysqli->close();
