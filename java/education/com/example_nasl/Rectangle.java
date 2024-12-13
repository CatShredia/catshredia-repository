package com.example_nasl;

public class Rectangle extends TwoDimensionalFigure {
    public Rectangle() {
        super(2);

        System.out.println("Создан прямоугольник");
    }

    @Override
    public int findSquare() {
        square = faces[0] * faces[1];

        return square;
    }
}
