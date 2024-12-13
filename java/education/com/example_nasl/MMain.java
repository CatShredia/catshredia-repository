package com.example_nasl;

import com.example_protected.Protected;

public class MMain {
    public static void main(String[] args) {
        System.out.println("Hello World!");

        Rectangle rectangle = new Rectangle();

        rectangle.findSquare();

        rectangle.color = "Blue";

        rectangle.writeInformation();

        Circe circe = new Circe(5);

        circe.isFill = true;
        circe.findSquare();

        circe.writeInformation();

        circe.finalMethod();

        Protected protected1 = new Protected();
        // protected1.printHelloBobby();
        protected1.printHelloWilli();
        // protected1.printHellozBilliBobens();
        protected1.getPrintHellozBilliBobens();
        // protected1.defaultMethod();
    }

}
