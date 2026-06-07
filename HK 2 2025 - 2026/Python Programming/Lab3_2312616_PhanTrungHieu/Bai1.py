#1. List
#Exercise 1. Perform Basic List Operations
sample_list = [10,20,30,40,50]

print(f"Third element: {sample_list[2]}")

print(f"Length of list: {len(sample_list)}")

is_empty = len(sample_list) == 0
print(f"Is the list empty? {is_empty}")

#Exercise 2. Perform List Manipulation
list_m = [100, 50, 400, 500]

list_m[1] = 200
print(f"Updated (Change): {list_m}") #[100,200,400,500]

# b) Append Element
list_m.append(600)
print(f"Updated (Append): {list_m}") #[100,200,400,500,600]

# c) Insert Element
list_m.insert(2, 300)
print(f"Updated (Insert): {list_m}") #[100,200,300,400,500,600]

# d) Remove Element by value
list_m.remove(600)
print(f"Updated (Remove 600): {list_m}") #[100,200,300,400,500]

# e) Remove Element by index
list_m.pop(0)
print(f"Updated (Remove Index 0): {list_m}") #[200,300,400,500]

#Exercise 3. Sum and Average of All Numbers in a List
nums = [10,20,30,40,50]

total_sum = sum(nums)
average = total_sum / len(nums)

print(f"Sum: {total_sum}")
print(f"Average: {average}")

#Exercise 4. Find Maximum and Minimum from List
data_points = [45, 12, 89, 2, 67]

max_val = max(data_points)
min_val = min(data_points)

print(f"Maximum: {max_val}")
print(f"Minimum: {min_val}")

#Exercise 5. Calculate the Product of All Elements
factors = [2, 3, 5, 7]
product = 1

for x in factors:
    product *= x

print(f"Product: {product}")

#Exercise 6. Count Even and Odd Numbers
numbers = [10, 21, 4, 45, 66, 93, 11]
even_count = 0
odd_count = 0

for num in numbers:
    if num % 2 == 0:
        even_count += 1
    else:
        odd_count += 1

print(f"Even numbers: {even_count}")
print(f"Odd numbers: {odd_count}")

#Exercise 7. Reverse a List
list1 = [100, 200, 300, 400, 500]

reversed_list = list1[::-1]

print(f"Reversed List: {reversed_list}")
#Exercise 8. Sort a List of Numbers
data = [56, 12, 89, 3, 22]
data.sort()

print(f"Sorted List: {data}")

#Exercise 9. Create a Copy of a List
original = ["Apple", "Banana", "Cherry"]

# Create a true copy
new_copy = original.copy()

# Prove they are independent
new_copy.append("Date")

print(f"Original: {original}")
print(f"Copy: {new_copy}")

#Exercise 10. Combine Two Lists
list_a = ["Physics", "Chemistry"]
list_b = ["Maths", "Biology"]

# Combine using the + operator
combined = list_a + list_b

print(f"Combined List: {combined}")

#2. Set
#Exercise 1: Perform Basic Set Operations

fruits = {"apple", "banana", "mango", "orange"}
print("1. After creating the set:", fruits)


fruits.add("grape")
print("2. After adding 'grape':", fruits)


fruits.remove("banana")
print("3. After removing 'banana':", fruits)


fruits.discard("mango")
print("4. After discarding 'mango':", fruits)

#Exercise 2: Union of Sets
set1 = {10, 20, 30, 40, 50}
set2 = {30, 40, 50, 60, 70}
union_set = set1.union(set2)
print("Union of set1 and set2:", union_set)

#Exercise 3: Intersection of Sets
set1 = {10, 20, 30, 40, 50}
set2 = {30, 40, 50, 60, 70}
intersection_set = set1.intersection(set2)
print("Intersection of set1 and set2:", intersection_set)

#Exercise 4: Difference of Sets
set1 = {10, 20, 30, 40, 50}
set2 = {30, 40, 50, 60, 70}
difference_set = set1.difference(set2)
print("3. Difference (set1 - set2):", difference_set)

#Exercise 5: Symmetric Difference
set1 = {10, 20, 30, 40, 50}
set2 = {30, 40, 50, 60, 70}
symmetric_difference_set = set1.symmetric_difference(set2)
print("Symmetric Difference:", symmetric_difference_set)

#Exercise 6: Add a list of Elements to a Set
sample_set = {"Yellow", "Orange", "Black"}
sample_list = ["Blue", "Green", "Red"]

sample_set.update(sample_list)
print(sample_set)

#Exercise 7: Set Difference Update
set1 = {10, 20, 30}
set2 = {20, 40, 50}

set1.difference_update(set2)
print(set1)

#Exercise 8: Remove Items From Set Simultaneously
set1 = {10, 20, 30, 40, 50}
set1.difference_update({10, 20, 30})
print(set1)

#Exercise 9: Check Subset
subset_set = {10, 20}
main_set = {10, 20, 30, 40}

is_subset = subset_set.issubset(main_set)
print(f"Is {subset_set} a subset of {main_set}? {is_subset}")

#Exercise 10: Check Superset
subset_set = {10, 20}
main_set = {10, 20, 30, 40}
is_superset = main_set.issuperset(subset_set)
print(f"Is {main_set} a superset of {subset_set}? {is_superset}")

#3. Tuple
#Exercise 1: Basic Tuple Operations
fruits = ("apple", "banana", "cherry", "date")

print("First element:", fruits[0])
print("Last element:", fruits[-1])
print("Length:", len(fruits))

#Exercise 2: The Trailing Comma
t = (50,)

print(t)
print(type(t))

#Exercise 3: Tuple Repetition
colors = ("red", "green")

repeated = colors * 3

print(repeated)

#Exercise 4: Tuple Concatenation
a = (1, 2)
b = (3, 4)
c = (5, 6)

combined = a + b + c

print(combined)

#Exercise 5: Tuple Slicing
numbers = (10, 20, 30, 40, 50, 60, 70)

sliced = numbers[2:5]

print(sliced)

#Exercise 6: Tuple Reversal
items = (1, 2, 3, 4, 5)
reversed_items = items[::-1]

print(reversed_items)

#Exercise 7: Type Casting
my_list = [10, 20, 30, 40, 50]

my_tuple = tuple(my_list)

print(my_tuple)
print(type(my_tuple))

#Exercise 8: Tuple to String
chars = ('a', 'b', 'c')

result = "".join(chars)

print(result)

#Exercise 9: Tuple Membership Testing
fruits = ("apple", "banana", "cherry", "date")

print("cherry" in fruits)
print("mango" in fruits)

#Exercise 10: Counting
votes = ("yes", "no", "yes", "yes", "no", "yes")

yes_count = votes.count("yes")
no_count = votes.count("no")

print("yes appears", yes_count, "times")
print("no appears", no_count, "times")

#4. Dictionary
#Exercise 1: Basic Dictionary Operations
student = {"name": "Alice", "age": 20, "grade": "B"}

# Add a new key
student["city"] = "New York"

# Modify an existing key
student["age"] = 21

# Access a key
print(student)
print("Name:", student["name"])

#Exercise 2: Dictionary Operations
car = {"brand": "Toyota", "model": "Camry", "year": 2022, "color": "blue"}

# Remove a key
car.pop("color")
print(car)

# Get all key-value pairs
print(car.items())

# Check key existence
print("'brand' exists:", "brand" in car)
print("'color' exists:", "color" in car)

#Exercise 3: Dictionary from Two Lists
keys = ["name", "age", "city"]
values = ["Bob", 25, "London"]

result = dict(zip(keys, values))
print(result)

#Exercise 4: Clear Dictionary
inventory = {"apples": 10, "bananas": 5, "oranges": 8}

inventory.clear()
print(inventory)

#Exercise 5: Merge Dictionaries
dict1 = {"a": 1, "b": 2}
dict2 = {"b": 3, "c": 4}

# Method 1: update() — modifies dict1 in place
dict1.update(dict2)
print(dict1)

# Method 2: unpacking — creates a new dictionary
dict1 = {"a": 1, "b": 2}
merged = {**dict1, **dict2}
print(merged)

# Method 3: merge operator (Python 3.9+)
dict1 = {"a": 1, "b": 2}
merged = dict1 | dict2
print(merged)

#Exercise 6: Access Nested Dictionary
person = {"name": "Carol", "address": {"city": "Paris", "zip": "75001"}}

city = person["address"]["city"]
print("City:", city)

#Exercise 7: Access ‘history’ Key From a Nested Dictionary
student = {"name": "Dave", "grades": {"math": 88, "science": 92, "history": 75}}

history_grade = student["grades"]["history"]
print("History grade:", history_grade)

#Exercise 8: Initialize Dictionary with Default Values
keys = ["math", "science", "english", "history"]
default = 0

scores = dict.fromkeys(keys, default)
print(scores)

#Exercise 9: Rename a Key of Dictionary
employee = {"fname": "John", "age": 30, "dept": "Engineering"}

employee["first_name"] = employee.pop("fname")
print(employee)

#Exercise 10: Delete a List of Keys
product = {"id": 101, "name": "Laptop", "price": 999, "stock": 50, "warehouse": "A3"}
keys_to_remove = ["stock", "warehouse"]

for key in keys_to_remove:
    product.pop(key, None)

print(product)

#5.
numbers = [3, 15, 7, 21, 8, 13, 5, 34, 11, 25]

#6.  Xuât tất cả các số lẻ không chia hết cho 5
numbers = [3, 15, 7, 21, 8, 13, 5, 34, 11, 25]
result = [x for x in numbers if x % 2 != 0 and x % 5 != 0]
print("Số lẻ không chia hết cho 5:", result)

#7. Xuất tất cả các số Fibonacci
numbers = [3, 15, 7, 21, 8, 13, 5, 34, 11, 25]
def is_fibonacci(n):
    a, b = 0, 1
    while a < n:
        a, b = b, a + b
    return a == n

fib_nums = [x for x in numbers if is_fibonacci(x)]
print("Số Fibonacci:", fib_nums)

#8. Tìm số nguyên tố lớn nhất
numbers = [3, 15, 7, 21, 8, 13, 5, 34, 11, 25]
def is_prime(n):
    if n < 2:
        return False
    for i in range(2, int(n**0.5) + 1):
        if n % i == 0:
            return False
    return True

primes = [x for x in numbers if is_prime(x)]
print("Số nguyên tố lớn nhất:", max(primes) if primes else "Không có")

#9. Tìm số Fibonacci bé nhất
numbers = [3, 15, 7, 21, 8, 13, 5, 34, 11, 25]
fib_nums = [x for x in numbers if is_fibonacci(x)]
print("Số Fibonacci bé nhất:", min(fib_nums) if fib_nums else "Không có")

#10. Tính trung bình các số lẻ
numbers = [3, 15, 7, 21, 8, 13, 5, 34, 11, 25]
odds = [x for x in numbers if x % 2 != 0]
avg = sum(odds) / len(odds) if odds else 0
print("Trung bình số lẻ:", avg)

#11. Tích các phần tử lẻ không chia hết cho 3
numbers = [3, 15, 7, 21, 8, 13, 5, 34, 11, 25]
product = 1
filtered = [x for x in numbers if x % 2 != 0 and x % 3 != 0]
for x in filtered:
    product *= x
print("Tích:", product)

#12. Đổi chỗ 2 phần tử theo vị trí
numbers = [3, 15, 7, 21, 8, 13, 5, 34, 11, 25]
def swap(lst, i, j):
    lst[i], lst[j] = lst[j], lst[i]
    return lst

nums = numbers.copy()
print(swap(nums, 0, 3))

#13. Đảo ngược danh sách + Số lớn thứ nhì
numbers = [3, 15, 7, 21, 8, 13, 5, 34, 11, 25]
print("Đảo ngược:", numbers[::-1])


second_largest = sorted(set(numbers))[-2]
print("Số lớn thứ nhì:", second_largest)

#14. Tổng các chữ số của tất cả số trong danh sách
numbers = [3, 15, 7, 21, 8, 13, 5, 34, 11, 25]
total = sum(int(d) for x in numbers for d in str(x))
print("Tổng các chữ số:", total)

#15. Đếm số lần xuất hiện của 1 số
nums = [3, 15, 7, 3, 8, 13, 5, 3, 11, 25]
target = 3
print(f"{target} xuất hiện {nums.count(target)} lần")

#16 & 17: Số xuất hiện n lần / Số xuất hiện nhiều nhất
from collections import Counter

nums = [3, 15, 7, 3, 8, 13, 5, 3, 11, 15]
count = Counter(nums)

# Câu 16: xuất hiện đúng n lần
n = 2
print(f"Số xuất hiện {n} lần:", [k for k, v in count.items() if v == n])

# Câu 17: xuất hiện nhiều nhất
max_count = max(count.values())
print("Số xuất hiện nhiều nhất:", [k for k, v in count.items() if v == max_count])