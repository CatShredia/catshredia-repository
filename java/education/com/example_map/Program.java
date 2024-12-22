package com.example_map;

import java.util.HashMap;
import java.util.Map;

public class Program {
    public static void main(String[] args) {
        // using before java 8 creating HashMap
        Map<Integer, String> myMap = new HashMap<>();

        myMap.put(0, "Hello");
        myMap.put(1, "World");
        myMap.put(2, "!");
        myMap.put(3, "!");
        myMap.put(4, "!");

        System.out.println(myMap);
        for (int i = 0; i < myMap.size(); i++) {
            System.out.print(myMap.get(i) + " ");
        }
        System.out.println();

        // using a new java 8 versions creating HashMap
        Map<Integer, String> myNewMap = new HashMap<>(Map.of(
                1, "test 1",
                2, "test 2",
                3, "test 3",
                4, "test 4",
                5, "test 5"));
        System.out.println(myNewMap);
        myNewMap.put(6, "rfgij");
        System.out.println(myNewMap);

    }
}
