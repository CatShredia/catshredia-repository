<?php

class TestClass
{

    private int $age;

    public string $var;

    public function __construct(string $var = null, int $age = 0)
    {
        $this->var = $var;
        $this->age = $age;
    }

    public function getInformation()
    {
        echo $this->var . "\n";
        echo $this->age . "\n";
    }

    public function getAge(): int
    {
        return $this->age;
    }

    public function getVar(): string
    {
        return $this->var;
    }

    public function setAge(int $age): void
    {
        $this->age = $age;
    }

    public function setVar(string $var): void
    {
        $this->var = $var;
    }


}


$testClass = new TestClass("TestIternf", 22);

$testClass->getInformation();

echo $testClass->getAge() . "\n";
$testClass->setAge(102);
echo $testClass->getAge() . "\n";