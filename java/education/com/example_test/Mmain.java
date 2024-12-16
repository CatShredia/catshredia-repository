package com.example_test;

import java.util.InputMismatchException;
import java.util.Scanner;

public class Mmain {
    public static void main(String args[]) {
        System.out.println("Hello World!");

        Scanner s = new Scanner(System.in);

        int str = 0;
        try {
            str = s.nextInt();
        } catch (InputMismatchException e) {
            System.out.println("Введите число!");
        } finally {
            System.out.println(str);
        }

        stopMain();
    }

    public static void stopMain() {
        System.out.println("---");

        Scanner s = new Scanner(System.in);

        s.nextLine();
        System.out.print("\033[H\033[2J");
    }
}