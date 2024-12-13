package com.example_arrays.sorting;

public class InsertSorting {
    public int[] array;

    public InsertSorting(int[] array) {
        System.out.println("Сортировка вставки");

        this.array = array;
    }

    public int[] sortArray() {
        boolean isComplete = false;

        while (isComplete == false) {
            isComplete = recursion();
        }
        return array;
    }

    private boolean recursion() {
        int q = 0;
        int count = 0;

        for (int i = 1; i < array.length; i++) {
            if (array[i] < array[i - 1]) {
                q = array[i];

                array[i] = array[i - 1];
                array[i - 1] = q;

                count++;
            }
        }

        if (count != 0) {
            return false;
        } else {
            return true;
        }
    }
}
