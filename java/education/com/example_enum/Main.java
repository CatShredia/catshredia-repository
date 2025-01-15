package com.example_enum;

import static java.lang.System.out;

public class Main {
    public static void main(String[] args) {
        out.println("Enum example");

        enum DAYS {
            ПОНЕДЕЛЬНИК,
            ВТОРНИК,
            СРЕДА,
            ЧЕТВЕРГ,
            ПЯТНИЦА,
            СУББОТА,
            ВОСКРЕСЕНЬЕ
        }

        out.println(DAYS.ПОНЕДЕЛЬНИК);

        DAYS perem = DAYS.ВТОРНИК;

        out.println(perem);

        switch (perem) {
            case ВТОРНИК:
                out.println("Ура, сейчас Вторник!");
                break;

            default:
                break;
        }

        DAYS[] array = DAYS.values();

        for (DAYS day : array) {
            out.println(day);
        }
    }
}
