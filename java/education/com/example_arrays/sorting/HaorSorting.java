package com.example_arrays.sorting;

public class HaorSorting {
    public int[] array;

    public HaorSorting(int[] array) {
        System.out.println("Быстрая сортировка");

        this.array = array;
    }

    public int[] sortArray() {
        int q = 0;

        while (q == 0) {
            q = quickSort();
        }

        return array;
    }

    private int quickSort() {
        int q = 0;

        int pivot = 0;
        int firstIndex = 0;
        int secondIndex = array.length;

        pivot = array[array.length / 2];
        if (firstIndex == secondIndex) {
            return 1;
        } else {
            System.out.println("Первый - " + firstIndex + " Следующий - " + secondIndex);
            for (int i = firstIndex; i < secondIndex; i++) {
                if (array[i] > pivot) {
                    q = array[i];

                    array[i] = pivot;
                    pivot = q;
                }
            }
            return 0;
        }

    }

    public static void writeArray(int[] array, int pivot) {
        System.out.println("");

        for (int elem : array) {
            System.out.print(elem + " ");
        }
        System.out.print(" сортировка " + pivot + " " + array[pivot]);

        System.out.println("");
    }
}
