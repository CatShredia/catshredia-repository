package com.example_nasl;

import java.util.Random;
import java.util.Scanner;

public abstract class TwoDimensionalFigure {
    public String color;
    public boolean isFill;

    public int square;

    public int[] faces;

    public double radius;

    public final int ten = 10;

    public final void finalMethod() {
        System.out.println("Hello World!");
    }

    public TwoDimensionalFigure(int countFaces) {
        faces = new int[countFaces];

        Scanner s = new Scanner(System.in);

        for (int i = 0; i < faces.length; i++) {
            faces[i] = s.nextInt();
        }
    }

    public TwoDimensionalFigure(int radius, double pi) {
        this.radius = radius;
    }

    public void writeInformation() {
        for (int element : faces) {
            System.out.print(element + " ");
        }
        System.out.println();
        System.out.println("Цвет: " + color + " Заполнен: " + isFill + " Площадь: " + square);
    }

    public int findSquare() {
        System.out.println("Поиск площади");

        return square;
    }
}