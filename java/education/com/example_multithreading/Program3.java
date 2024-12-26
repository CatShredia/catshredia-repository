package com.example_multithreading;

import static java.lang.System.in;
import static java.lang.System.out;
import static java.lang.Thread.currentThread;
import static java.lang.Thread.interrupted;

import java.util.Random;
import java.util.concurrent.TimeUnit;

public class Program3 {

    private static final String MESSAGE_SERVER_REQUEST = "Send Request to Server";
    private static final String MESSAGE_SERVER_ANSWER = "Request succesfull";
    private static final String MESSAGE_SERVER_CLOSE = "Server was Closed";

    private static int firstBorder = 0;
    private static int lastBorder = 100;
    private static int intInformation = 11;

    private static boolean isServerOnline;

    private static final int seconds = 1;

    public static void main(String[] args) {

        System.out.println("Hello World!");

        Thread threadServerConnection = new Thread(() -> {
            isServerOnline = true;
            while (isServerOnline) {
                try {
                    out.println(MESSAGE_SERVER_REQUEST);
                    intInformation = getInformation();
                    out.println(MESSAGE_SERVER_ANSWER + " " + intInformation + "\n");

                    if (checkServerInformation()) {
                        System.out.println("Stop! ");
                        isServerOnline = false;
                        interrupted();

                    }

                    Thread.sleep(100);
                } catch (InterruptedException e) {
                    out.println(MESSAGE_SERVER_CLOSE);
                }

            }
        });

        threadServerConnection.start();

        System.out.println("-----------------");

    }

    private static int getInformation() {
        Random rand = new Random();

        return rand.nextInt(firstBorder, lastBorder);
    }

    private static boolean checkServerInformation() {
        if (intInformation < 10) {
            return true;
        } else {
            return false;
        }
    }

    // @SuppressWarnings("removal")
    private static void stopServer(Thread thread) {
        isServerOnline = false;
        thread.stop();
    }
}