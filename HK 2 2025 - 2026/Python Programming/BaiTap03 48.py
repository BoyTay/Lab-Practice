#Cau 1
import time

if 5 > 2:
    print(" Nam lon hon hai !") # Loi thut le

#Cau 2
# 2my-first_name không hợp lệ vì: bắt đầu bằng số, có dấu gạch ngang
my_first_name = "John"

#Cau 3
def my_func():
    global x
    x = 'fanstatic'

#Cau 4
x = "Hello World"
print(type(x)) # <class 'str'>

#Cau 5
x = ("apple", "banana", "cherry")
print(type(x)) # <class 'tuple'>

#Cau 6
x = 5
x = float(x)

#Cau 7
txt = " Hello World "
x = txt.strip()
print(x)

#Cau 8
txt = "Hello World"
txt = txt.replace("H","J")
print(txt)

#Cau 9
age = 36
txt = "My name is John, and I am {}"
print(txt.format(age))

#Cau 10
print(bool("abc")) # True (Chuoi khac rong luon la true)

#Cau 11
print(10 == 9) # False

#Cau 12
if 5 == 10 or 4 == 4:
    print("Mot trong 2 dieu kien dung")

#Cau 13
print(10 // 4) #2 (chia lay phan nguyen)

#Cau 14
sum = 0
for i in range(1,10,2): # i = 1,3,5,7,9
    sum += i
print(sum) #25

#Cau 15
i = 0
while i < 5:
    print(i)
    i += 1 # i++ khong lop le trong python
    # 0 1 2 3 4

#Cau 16
sum = 0
for i in range(5): # i = 0,1,2,3,4
    sum += i
    print(sum)
    #In sau moi lan cong : 0 1 3 6 10

#Cau 17
fruits = ["apple", "banana", "cherry"]
fruits[0] = "kiwi"
print(fruits)

#Cau 18
fruits = ["apple", "banana", "cherry"]
fruits.insert(1, "lemon")
print(fruits)

#Cau 19
fruits = ["apple", "banana", "cherry"]
print(fruits[-1])  # cherry

#Cau 20
x = lambda a: a + 10
print(x(5))  # 15


#Cau 21
fruits = ["apple", "banana", "cherry","orange","kiwi","melon","mango"]
print(fruits[2:5])

#Cau 22
fruits = ["apple", "banana", "cherry","orange","kiwi","melon","mango"]
print(fruits[4:])# ['kiwi', 'melon', 'mango']

#Cau 23
fruits = {"apple", "banana", "cherry"}
fruits.add("lemon")
print(fruits)

#Cau 24
fruits = {"apple", "banana", "cherry"}
fruits.discard("banana")
print(fruits)

#Cau25
car = {
    "brand": "Ford",
    "model": "Mustang",
    "year": 1964,
    "color": "red"
}
#car["color"] = "red"
print(car)

#Cau 26
car = {
    "brand": "Ford",
    "model": "Mustang",
    "year": 1964,
}
car["year"] = 2020 #Thay đổi năm
print(car)

#Cau 27
i = 0
while i < 6:
    i += 1
    if i == 3:
        continue
    print(i)

#Cau 28
def my_function(*kids): # *arg cho phép hàm nhận không giời hạn số lượng tham số truyền vào gom thành 1 tuple
    print("The youngest child is " + kids[2])

#Cau 29
class MyClass:
    x = 5

p1 = MyClass()

#Cau 30
class Person:
    def __init__(self, name, age):
        self.name = name
        self.age = age

#Cau 31
def myfunc(n):
    return lambda a : a * n

mydoubler = myfunc(2) #n = 2
print(mydoubler(11)) # 11 * 2 = 22

#Cau 32
list1 = [3,4,5,20,5,25,1,3]
list1.pop(1) #Xóa phần từ index 1
print(list1)#[3,5,20,5,25,1,3]

#Cau 33: time.time()
time.time()




