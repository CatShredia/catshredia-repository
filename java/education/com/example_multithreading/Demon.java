package com.example_multithreading;

import static java.lang.Thread.currentThread;

import java.util.Scanner;

// TODO: потоки - демоны
public class Demon {
    public static void main(String[] args) throws InterruptedException {
        System.out.println("Hello World!");

        testMethod();

    }

    private static void testMethod() throws InterruptedException {
        informationAboutThreadConsole(currentThread());

        Thread myThread = new Thread(() -> {
            for (int i = 0; i <= 10; i++) {
                System.out.println(currentThread().getName() + " is active!");
            }
        });

        myThread.setName("my Thread");
        myThread.setDaemon(true);
        myThread.start();

        informationAboutThreadConsole(myThread);

        myThread.join();
    }

    // вывод информации о потоке
    private final static String MESSAGE_THREAD_STATUS = "%s : %s %d. is Demon: %b \n"; // шаблон сообщения о потоке

    private static void informationAboutThreadConsole(Thread thread) {
        System.out.printf(MESSAGE_THREAD_STATUS, thread.getName(), thread.getState(), thread.getPriority(),
                thread.isDaemon());
    }

}
