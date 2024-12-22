package com.example_compare;

import java.util.Arrays;
import java.util.Comparator;
import java.util.List;

public class Program {
    public static void main(String[] args) {
        Person person1 = new Person(100, "Aleksey", 72);
        Person person2 = new Person(12, "Mila", 32);
        Person person3 = new Person(55, "Mikhail", 52);
        Person person4 = new Person(23, "Ben", 87);

        person1.WriteInformation();

        List<Person> list = Arrays.asList(person1, person2, person3, person4);

        // вывод до сортировки
        System.out.println();
        for (Person person : list) {
            person.WriteInformation();
        }

        // 1 способ сортировки
        list.sort(new PersonAgeComparator());

        Comparator<Person> comparatorAgePerson = Comparator.comparingInt(p -> p.getAge());
        list.sort(comparatorAgePerson);

        System.out.println();
        for (Person person : list) {
            person.WriteInformation();
        }

        Comparator<Person> comparatorNamePerson = Comparator.comparing(p -> p.getName());
        list.sort(comparatorNamePerson);

        System.out.println();
        for (Person person : list) {
            person.WriteInformation();
        }
    }

}

class PersonAgeComparator implements Comparator<Person> {

    @Override
    public int compare(Person o1, Person o2) {
        return Integer.compare(o1.getAge(), o2.getAge());
    }

}
