package com.example_test;

public class Mmain {
    public static void main(String args[]) {
        System.out.println("Hello World!");

        try {
            testMethod();
        } catch (ArithmeticException e) {
            System.out.println("Отлов");
        }

    }

    public static void testMethod() {
        // System.out.println(2 / 0);
    }
}