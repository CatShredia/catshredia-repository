package com.example_arrays;

import java.util.Random;

import com.example_arrays.sorting.BubbleSorting;
import com.example_arrays.sorting.ChoiseSorting;
import com.example_arrays.sorting.HaorSorting;
import com.example_arrays.sorting.InsertSorting;

public class Mmain {

    // TODO: main
    public static void main(String[] args) {
        System.out.println("Hello World!");

        int[] numbers = createRandomArray(1000, -100, 100);
        // int[] numbers = createRandomArray(10, -100, 100);

        writeArray(numbers);

        // ВЫЗОВ ПУЗЫРЬКОВОЙ СОРТИРОВКИ
        // BubbleSorting bubSort = new BubbleSorting(numbers);
        // numbers = bubSort.sortArray();

        // ВЫЗОВ СОРТИРОВКИ ВЫБОРА
        // ChoiseSorting choSort = new ChoiseSorting(numbers);
        // numbers = choSort.sortArray();

        // ВЫЗОВ СОРТИРОВКИ ВСТАВКИ
        // InsertSorting insSort = new InsertSorting(numbers);
        // numbers = insSort.sortArray();

        // ВЫЗОВ БЫСТРОй СОРТИРОВКИ
        // HaorSorting haoSort = new HaorSorting(numbers);
        // numbers = haoSort.sortArray();

        writeArray(numbers);

    }

    // TODO: создание рандомного массива
    public static int[] createRandomArray(int arrayLength, int firstRand, int secondRand) {
        int[] array = new int[arrayLength];
        Random rand = new Random();

        for (int i = 0; i < arrayLength; i++) {
            array[i] = rand.nextInt(firstRand, secondRand);
        }

        return array;
    }

    // TODO: вывод массива
    public static void writeArray(int[] array) {
        System.out.println("");

        for (int elem : array) {
            System.out.print(elem + " ");
        }

        System.out.println("");
    }
}
