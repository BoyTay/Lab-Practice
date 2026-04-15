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
import time
bay_gio = time.time()
print(bay_gio)
# Kết quả dạng: 1775790243.9012365 (Số giây tính từ 01/01/1970)
#Nó trả về một số thực (float) biểu thị thời gian tính bằng giây trôi qua kể từ thời điểm Epoch (00:00:00 UTC ngày 1 tháng 1 năm 1970).

#Cau 34:Hàm định nghĩa bên trong class gọi là method (phương thức).

#Cau 35:
# ||: Đây là toán tử logic OR trong C/C++, Java... nhưng không tồn tại trong Python.
# |: Đây là toán tử Bitwise OR. Trong Python, để quá tải (overload) hành vi này cho một đối tượng, ta sử dụng phương thức đặc biệt __or__
# //: Toán tử chia lấy phần nguyên (floor division).
# /: Toán tử chia lấy số thực.
# Chọn b

#Cau 36:
i = 0
while i <3:
    print (i)
    i += 1
    print (i+1)
    #Kết quả: 0 2 1 3 2 4

#Cau 37:
print("Dalat university"[::-1])
# ytisrevinu talaD

#Cau 38: Hàm không trả về giá trị → Đáp án: d. None

#Cau 39:
print(0.1 + 0.2 == 0.3) #Trong Python (và hầu hết ngôn ngữ lập trình),
# số thực (float) được lưu dưới dạng nhị phân (binary floating-point) chứ không phải thập phân chính xác
# False

#Cau 40:
~~~~~~5 # Toán từ ~ là bitwise NOT (phủ định từng bit)
# ~x = -(x + 1)
# ~5 = -(5 + 1) = -6
# ~~5 = ~(-6) = -(-6 + 1) = 5
# ~~~5 = ~5 = -6
# ~~~~5 = ~(-6) = 5
# ~~~~~5 = ~5 = -6
# ~~~~~~5 = ~(-6) = 5

#Cau 41:
~~~18
# ~18 = -(18 + 1) = -19
# ~~18 = ~(-19) = -(-19 + 1) = 18
# ~~~18 = ~18 = -19

#Cau 42: Đáp án: d. s[1] = a (string không thể thay đổi từng ký tự vì bất biến)
s = "Welcome"
print(s[0])
print(s.lower())
print(s.strip())

#Cau 43: Chạy Python dòng lệnh → Đáp án: c. python

#Cau 44:class là cơ chế để định nghĩa kiểu dữ liệu mới, không phải một kiểu dữ liệu built-in cụ thể.
# d.class

#Cau 45:
L = [1,23,'helo',1]
print(type(L)) #list : chứa nhiều kiểu dữ liệu khác nhau

#Cau 46:
nameList = ['Harsh', 'Pratik', 'Bob', 'Dhruv']
pos = nameList.index("Bob") # pos = 2
print (pos * 3) #6

#Cau 47:
D = dict()
for x in enumerate(range(2)): #range(2) -> [0,1], enumerate(range(2)) → [(0, 0), (1, 1)]
 D[x[0]] = x[1] # x[0] = index , x[1] = value
 D[x[1]+7] = x[0]
print(D) # {0: 0, 7: 0, 1: 1, 8: 1}

#Lần 1 : x= (0,0)
#Dòng 1: D[0] = 0 --> Dictionary D = {0: 0}
#Dòng 2: D[0+7] = 0 --> Dictionary D = {0: 0, 7: 0}

#Lần 2 : x =(1,1)
#Dòng 1 : D[1] = 1 --> Dictionary D = {0: 0, 7: 0, 1:1}
#Dòng 2 : D[1+7] = 1 --> Dictionary D = {0: 0, 7: 0, 1:1, 8:1}

#Lưu ý : Dictionary không cho phép trùng key (0,7,1,8) --> không bị ghi đè

#Cau 48:
a = {i: i * i for i in range(6)}
print (a) # {0: 0, 1: 1, 2: 4, 3: 9, 4: 16, 5: 25}

