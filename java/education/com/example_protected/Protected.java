package com.example_protected;

public class Protected {
    protected void printHelloBobby() {
        System.out.println("Hello Bobby!");
    }

    public void printHelloWilli() {
        System.out.println("Hello Willi!");
    }

    private void printHellozBilliBobens() {
        System.out.println("Hello Billi Bobens!");
    }

    public void getPrintHellozBilliBobens() {
        printHellozBilliBobens();
        defaultMethod();
    }

    void defaultMethod() {
        System.out.println("Метод без модификатора доступа");
    }
}
