<?php
class FormPageController extends Controller
{
    public function index()
    {
        $page = 'FormPage.php';
        include __DIR__ . "/../views/Main.php";
    }

    public function createUser()
    {
        if ($_SERVER['REQUEST_METHOD'] === 'POST') {
            $name = $_POST['name'] ?? '';
            $email = $_POST['email'] ?? '';
            $message = $_POST['message'] ?? '';

            if (!empty($name) && !empty($email) && !empty($message)) {
                $host = 'mysql';
                $username = 'catshredia';
                $password = 'password';
                $database = 'php_db';

                $mysqli = new mysqli($host, $username, $password, $database);

                if ($mysqli->connect_errno) {
                    echo "Не удалось подключиться к MySQL: " . $mysqli->connect_error;
                    exit();
                }

                $stmt = $mysqli->prepare("INSERT INTO users (name, email, message, created_at, updated_at) VALUES (?, ?, ?, NOW(), NOW())");
                $stmt->bind_param("sss", $name, $email, $message);

                if ($stmt->execute()) {
                    echo "Пользователь успешно создан!";
                } else {
                    echo "Ошибка при создании пользователя: " . $stmt->error;
                }

                $stmt->close();
                $mysqli->close();
            } else {
                echo "Все поля формы должны быть заполнены!";
            }
        }
    }
}
