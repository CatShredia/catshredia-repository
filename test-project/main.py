import math
from itertools import combinations

def combinations_count(n, k):
    return math.comb(n, k)

def permutations_count(n):
    return math.factorial(n)

def arrangements_count(n, k):
    return math.perm(n, k)

# Задача 1
def task_1():
    return combinations_count(10, 1) * combinations_count(8, 1) * combinations_count(7, 1)

# Задача 2
def task_2():
    return arrangements_count(10, 3)

# Задача 3
def task_3():
    return 3 * arrangements_count(4, 2)

# Задача 4
def task_4():
    odd_digits = [1, 3, 5, 7]
    first_digit_options = [1, 2, 3, 4, 5, 6, 7]  # не может быть 0
    return len(odd_digits) * len(first_digit_options) * 7 * 6

# Задача 5
def task_5():
    return arrangements_count(5, 3) * arrangements_count(6, 2)

# Задача 6
def task_6():
    return permutations_count(6)

# Задача 7
def task_7():
    return permutations_count(6), permutations_count(9) // 2, permutations_count(11)

# Задача 9
def task_9():
    total_ways = combinations_count(50, 4)
    ivanov_in_guard = combinations_count(49, 3)
    return total_ways, ivanov_in_guard

# Задача 10
def task_10():
    total_chords = sum(combinations_count(10, k) for k in range(3, 11))
    return total_chords

# Задача 11
def task_11_a():
    return 3360

def task_11_b():
    return 11760

def task_11_c():
    return 16800

def task_11_d():
    return 36960

def task_11_e():
    return 46200

# Задача 12
def task_12_a():
    return "C(7,0)(1/2a)^7 + C(7,1)(1/2a)^6b + C(7,2)(1/2a)^5b^2 + C(7,3)(1/2a)^4b^3 + C(7,4)(1/2a)^3b^4 + C(7,5)(1/2a)^2b^5 + C(7,6)(1/2a)b^6 + C(7,7)b^7"

def task_12_b():
    return "41 + 29*sqrt(2)"

def task_12_c():
    return "C(6,0)a^6 + C(6,1)a^5(2b) + C(6,2)a^4(2b)^2 + C(6,3)a^3(2b)^3 + C(6,4)a^2(2b)^4 + C(6,5)a(2b)^5 + C(6,6)(2b)^6"

def task_12_d():
    return "a^6 - 6*sqrt(2)*a^5 + 30*a^4 - 40*sqrt(2)*a^3 + 60*a^2 - 24*sqrt(2)*a + 8"

# Примеры вызова задач
print("Задача 1:", task_1())
print("Задача 2:", task_2())
print("Задача 3:", task_3())
print("Задача 4:", task_4())
print("Задача 5:", task_5())
print("Задача 6:", task_6())
print("Задача 9:", task_9())
print("Задача 10:", task_10())
print("Задача 11a:", task_11_a())
print("Задача 11b:", task_11_b())
print("Задача 12a:", task_12_a())
print("Задача 12b:", task_12_b())
print("Задача 12c:", task_12_c())
print("Задача 12d:", task_12_d())