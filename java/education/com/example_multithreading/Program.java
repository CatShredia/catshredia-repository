package com.example_multithreading;

import static java.lang.Thread.currentThread; //импорт библиотеки и метода
import static java.lang.System.out;

import java.util.Scanner;
import java.util.stream.IntStream;

public class Program {
    public static void main(String[] args) throws InterruptedException {
        // TODO: вывод названия main
        out.println(currentThread().getName()); // вывод названия текущего потока

        // TODO: создание потока 1 способ
        final Thread myThread = new TestThread();
        myThread.start();

        // TODO: создание потока 2 способ
        final Thread myThread2 = new Thread() {
            @Override
            public void run() {
                out.println(currentThread().getName()); // вывод названия текущего потока
            };
        };
        myThread2.start();

        // TODO: runnable
        final Runnable task = () -> out.println(currentThread().getName()); //
        // создаем экземпляр интерфейса (скорее
        // класса, в котором переопределяем методы
        // интерфейса)
        final Thread thread = new Thread(task); // создаем поток

        thread.start(); // запускаем его

        stopConsole();

        // TODO: задание
        Scanner s = new Scanner(System.in);
        final int firstNumber = s.nextInt();
        final int lastNumber = s.nextInt();
        final int period = s.nextInt();

        final Task task0 = new Task(firstNumber, lastNumber / 2, period);
        startThread(task0);

        final Task task1 = new Task(lastNumber / 2 + 1, lastNumber, period);
        startThread(task1);

        Thread.sleep(150);
        currentThread().interrupt();

        int result = task0.getSummTask() + task1.getSummTask();

        out.println("Результат: " + result);
    }

    private static final class TestThread extends Thread {

        @Override
        public void run() {
            out.println(currentThread().getName()); // вывод названия текущего потока
        }
    }

    public static void stopConsole() {
        out.println("---");

        Scanner s = new Scanner(System.in);

        s.nextLine();
        out.print("\033[H\033[2J");
    }

    // запуск задачи в процессе
    public static void startThread(Runnable runnable) {
        final Thread thread = new Thread(runnable);
        thread.start();
    }
}

class Task implements Runnable {
    private int fistNumber;
    private int lastNumber;
    private int period;

    private int summTask;

    public int getSummTask() {
        return summTask;
    }

    Task(int fistNumber, int lastNumber, int period) {
        this.fistNumber = fistNumber;
        this.lastNumber = lastNumber;
        this.period = period;

        this.summTask = 0;
    }

    @Override
    public void run() {
        // находим сумму
        System.out.println("тест " + fistNumber + " " + lastNumber + " " + period);
        for (int i = fistNumber; i < lastNumber; i += period) {
            summTask += i;
        }
        out.println("Имя потока " + currentThread().getName());
        out.println(summTask + " сумма потока");

    }

}