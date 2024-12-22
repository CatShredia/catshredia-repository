package com.example_compare;

public class Person {
    private int age;

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    private String name;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    private int weight;

    public int getWeight() {
        return weight;
    }

    public void setWeight(int weight) {
        this.weight = weight;
    }

    public Person(int age, String name, int weight) {
        this.age = age;
        this.name = name;
        this.weight = weight;
    }

    public void WriteInformation() {
        System.out.println("Имя: " + name + ". Возраст: " + age + ". Вес: " + weight);
    }
}
