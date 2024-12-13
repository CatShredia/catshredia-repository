package com.example_nasl;

public final class Circe extends TwoDimensionalFigure {
    public Circe(int radius) {
        super(radius, Math.PI);
    }

    @Override
    public int findSquare() {
        if (isFill == false) {
            System.out.println("У окружности невозможно найти прощадь");
            return 0;
        } else if (isFill == true) {
            square = (int) (Math.PI * Math.pow(radius, 2.0));
        }
        return square;
    }

    @Override
    public void writeInformation() {
        System.out.println("Радиус: " + radius);
        System.out.println("Цвет: " + color + " Заполнен: " + isFill + " Площадь: " + square);
    }

}
