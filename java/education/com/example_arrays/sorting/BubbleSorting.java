package com.example_arrays.sorting;

public class BubbleSorting {
    public int[] array;

    public BubbleSorting(int[] array) {
        System.out.println("Пузырьковая сортировка");

        this.array = array;
    }

    public int[] sortArray() {
        int count = 0;
        int q = 0;

        while (true) {
            count = 0;
            for (int i = 0; i < array.length; i++) {
                if (i < (array.length - 1)) {
                    if (array[i] > (array[i + 1])) {
                        q = array[i + 1];

                        array[i + 1] = array[i];
                        array[i] = q;

                        count++;
                    }
                }

            }

            if (count == 0) {
                break;
            }
        }

        return array;
    }
}
