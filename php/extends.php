<?php

echo "Hello World!" . "\n";


class Person
{

    public int $age;
    public string $name;
    public function __construct(int $age, string $name)
    {
        $this->age = $age;
        $this->name = $name;
    }

    public function getInformation()
    {
        echo $this->name . " : " . $this->age . "\n";
    }

}

class Manager extends Person
{
    public int $experience;
}


$manager = new Manager(24, "Василий");
$manager->getInformation();
$manager->experience = 12;

echo $manager->experience . "\n";