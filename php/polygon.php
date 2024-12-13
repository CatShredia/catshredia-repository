<!DOCTYPE html>
<html lang="ru">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Polygon</title>
</head>
<body>
    Тестовый полигон
    <br>
    <?php
    $price = 3.5343241;
    $tax = 0.075;

    printf("The dish costs $%.2f", $price, ($tax + 1) );
    ?>
    <br>

    <?php
    $zip = "6520";
    $month = 2;
    $day = 6;
    $year = 2024;

    printf("ZIP is %05d and the date is %02d.%02d.%d",
    $zip, $month, $day, $year)
    ?>
    <br>
    <?php
    $testPerMin = -2;
    $testPerMax = 2;

    printf("Max: %+d. Min: %+d", $testPerMin, $testPerMax)
    ?>
</body>
</html>