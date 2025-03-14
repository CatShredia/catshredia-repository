<?php

// выполнение миграций
$migrations = glob('php-server/migrations/*.php');

foreach ($migrations as $migration) {
    echo "Выполнение миграции: $migration\n";
    include $migration;
    echo "\n";
}
