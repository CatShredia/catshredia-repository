package com.example_multithreading;

import static java.lang.System.out;

public class TickTock {
    public static void main(String[] args) {
        final Thread tickThread = new Thread() {
            @Override
            public void run() {
                tick();
            };
        };
        tickThread.start();

        final Thread tockThread = new Thread() {
            @Override
            public void run() {
                tock();
            };
        };
        tockThread.start();
    }

    synchronized public static void tick() {
        for (int i = 0; i < 10000; i++) {
            out.println("tick");
        }
    }

    synchronized public static void tock() {
        for (int i = 0; i < 10000; i++) {
            out.println("tock");
        }
    }
}
