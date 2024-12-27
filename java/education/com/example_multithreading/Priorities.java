package com.example_multithreading;

import static java.lang.Thread.MAX_PRIORITY;
import static java.lang.Thread.MIN_PRIORITY;
import static java.lang.Thread.currentThread;

import java.util.Scanner;
import java.util.stream.IntStream;

// TODO: приоритеты потоков
public class Priorities {

    public static void main(String[] args) {
        System.out.println("Hello World!");

        informationAboutThreadConsole(currentThread());

        Thread newThread = new NewThread();
        newThread.setName("newThread");
        newThread.setPriority(MAX_PRIORITY);
        informationAboutThreadConsole(newThread);
        newThread.start();
        IntStream.rangeClosed(0, 100).forEach(System.out::println);
        ;

        clearConsole();
    }

    private static void clearConsole() {
        System.out.println("---");

        Scanner s = new Scanner(System.in);

        s.nextLine();
        System.out.print("\033[H\033[2J");
    }

    private final static String MESSAGE_THREAD_STATUS = "%s : %s %d \n"; // шаблон сообщения о потоке

    // вывод информации о потоке
    private static void informationAboutThreadConsole(Thread thread) {
        System.out.printf(MESSAGE_THREAD_STATUS, thread.getName(), thread.getState(), thread.getPriority());
    }

    private static final class NewThread extends Thread {

        @Override
        public void run() {
            for (int i = 0; i <= 10; i++) {
                System.out.println("Hello");
            }
        }

    }
}
