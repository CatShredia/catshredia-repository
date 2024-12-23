package com.example_multithreading;

import java.util.Scanner;

import static java.lang.System.out;
import static java.lang.Thread.currentThread;

public class Program2 {
    private static final String MESSAGE_TEMPLATE_WRITE_THREAD_STATUS = "%s : %s\n";

    public static void main(String[] args) throws InterruptedException {
        checkThreadStates();

        stopConsole();
    }

    // status of Threads
    private static void checkThreadStates() throws InterruptedException {
        Thread mainThread = currentThread();

        Runnable task0 = () -> {
            writeThreadStatus(currentThread());
        };
        Thread thread0 = new Thread(task0);

        // out.println(thread.getState()); // default method
        writeThreadStatus(thread0); // NEW
        thread0.start(); // start thread
        writeThreadStatus(thread0); // RUNNABLE

        writeThreadStatus(thread0); // TERMINATED
        waitEndOffAllThreads(thread0);
        writeThreadStatus(thread0);

        Thread thread1 = new Thread(() -> {
            writeThreadStatus(currentThread());
        });

        thread1.start();
        thread1.setName("TestName");
        waitEndOffAllThreads(thread1);
        writeThreadStatus(thread1);

        mainThread.join(1000);
        writeThreadStatus(mainThread);
    }

    // stop thread to complete others
    private static void waitEndOffAllThreads(Thread... threads) throws InterruptedException {
        for (Thread thread : threads) {
            thread.join();
        }
    }

    // writeThreadStatus
    private static void writeThreadStatus(Thread thread) {
        out.printf(MESSAGE_TEMPLATE_WRITE_THREAD_STATUS, thread.getName(), thread.getState());
    }

    // for more castomize
    public static void stopConsole() {
        out.println("---");
        out.println("Close Console App");

        Scanner s = new Scanner(System.in);

        s.nextLine();
        out.print("\033[H\033[2J");
    }
}
