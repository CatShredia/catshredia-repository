<!-- 1 задание -->
<?php
if ($_POST['input'] == 1) {
    print "Первый";
}
?>
<br>
<?php
if ($_POST['input'] == 2) {
    // print <br>
    $price = 3.5343241;
    $tax = 0.075;

    printf("The dish costs $%.2f", $price, ($tax + 1));
    // <br>

    $zip = "6520";
    $month = 2;
    $day = 6;
    $year = 2024;

    printf(
        "ZIP is %05d and the date is %02d.%02d.%d",
        $zip,
        $month,
        $day,
        $year
    );

    // <br>

    $testPerMin = -2;
    $testPerMax = 2;

    printf("Max: %+d. Min: %+d", $testPerMin, $testPerMax);

    // strcmp()
    $str1 = "100";
    $str2 = "2100";

    if (strcmp($str1, $str2)) {
        print "Число больше";
    } else if (strcmp($str1, $str2)) {
        print "Число меньше";
    }

    $str1 = 1;
    $str2 = 2;
    $str3 = 3;
    $str4 = 4;

    print "";
    print $str1 <=> $str2;
    print $str2 <=> $str3;
    print $str3 <=> $str4;
    print $str4 <=> $str3;
}
?>
<br>
<?php

if ($_POST['input'] == 3) {

    $array = array(
        'carrot' => 'parrot',
        'red' => 'bet',
        'redd' => 'bet',
        'reddd' => 'bet'
    );
    $array['black'] = "jhf";

    foreach ($array as $key => $value) {
        print "---";
        print $key;
        print "---";
        print $value;
    }
    $arrayNumber = array(
        1,
        3,
        4,
        65
    );
    $arrayNumber[0] = 87361;
    print "----------------------";
    foreach ($arrayNumber as $value) {
        print "---";
        print $value;
    }

    // print "----";
    // print count($arrayNumber);
}
?>
<br>
<?php
if ($_POST['input'] == 4) {
    $arrayCh = array(
        1,
        2,
        3,
        5,
        6
    );
    print in_array('4', $arrayCh) ? 'yes' : 'false';

    unset($arrayCh[0]);

    print " ";
    foreach ($arrayCh as $value) {
        print $value;
    }
}
?>

<br>
<?php
if ($_POST['input'] == 5) {
    $array = array(
        4,
        34,
        42,
        23,
        23,
        435,
        -13,
        -2,
        5
    );

    if (in_array(5, $array)) {
        print 5;
    } else {
        print "Элемента 5 нету";
    }

    print array_search(5, $array); //возврат ключа, если есть элемент
    print in_array(5, $array); //возврат true / false, если есть элемент

    foreach ($array as $value) {
        print $value;
        print " ";
    }
    print "---------------";
    sort($array);
    foreach ($array as $value) {
        print $value;
        print " ";
    }
    print "---------------";
    rsort($array);
    foreach ($array as $value) {
        print $value;
        print " ";
    }
}
?>
<br>

<?php
if ($_POST['input'] == 6) {
    $array = array(
        1 => ['Hello', 'World', '!!!'],
        2 => ['World', 'World', '!!!'],
        3 => ['Hello', 'Hill', '!!!']
    );

    foreach ($array as $key => $value) {
        print $value[0];
        print $value[1];
        print $value[2];
    }
}
?>

<?php
$array = array(
    1,
    1,
    2
);

if ($_POST['input'] == 7) {
    foreach ($GLOBALS['array'] as $key => $value) {
        print $value;
    }
}
?>