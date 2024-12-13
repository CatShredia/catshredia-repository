package com.example_arrays.sorting;

public class ChoiseSorting {
    public int[] array;

    public ChoiseSorting(int[] array) {
        System.out.println("Сортировка выбором");

        this.array = array;
    }

    private void getSmallerElement(int startIndex) {
        int q = 0;

        for (int i = 0; i < array.length; i++) {
            if (array[startIndex] < array[i]) {
                q = array[startIndex];

                array[startIndex] = array[i];
                array[i] = q;
            }
        }
    }

    public int[] sortArray() {
        for (int i = 0; i < array.length; i++) {
            getSmallerElement(i);
        }

        return array;
    }

}
