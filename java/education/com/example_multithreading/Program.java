package com.example_multithreading;

import static java.lang.Thread.currentThread; //импорт библиотеки и метода
import static java.lang.System.out;

import java.util.Scanner;

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

        // TODO: задание
        out.println("---");
        Scanner s = new Scanner(System.in);
        final int firstNumber = s.nextInt();
        final int lastNumber = s.nextInt();
        final int period = s.nextInt();

        final Task task0 = new Task(firstNumber, lastNumber / 2, period);
        final Thread thread0 = new Thread(task0);
        thread0.start();

        final Task task1 = new Task(lastNumber / 2 + 1, lastNumber, period);
        final Thread thread1 = new Thread(task1);
        thread1.start();

        // Thread.sleep(1000);
        waitForEndAllThreads(thread0, thread1);
        currentThread().interrupt();

        int result = task0.getSummTask() + task1.getSummTask();

        out.println("Результат: " + result);

        stopConsole();

    }

    // вызов этого метода в потоке, прервет его
    // до выполнения потоков (передаваемых в параметрах)
    private static final void waitForEndAllThreads(Thread... threads) throws InterruptedException {
        // Thread... threads - потоки, ожидание которых
        for (Thread thread : threads) {
            thread.join(); // Прерывания самого потока
        }
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
        for (int i = fistNumber; i < lastNumber; i += period) {
            summTask += i;
        }
        out.println(summTask + " сумма потока");

    }

}