#1. Formatted Twinkle Poem
print("Twinkle, twinkle, little star, "
      "\n\tHow I wonder what you are! "
      "\n\t\tUp above the world so high, "
      "\n\t\tLike a diamond in the sky. "
      "\nTwinkle, twinkle, little star, "
      "\n\tHow I wonder what you are!")

#2. Python Version Checker
print("\n")
import sys
print("Python version")
print(sys.version)
print("Version info.")
print(sys.version_info)

#3. Current DateTime Display
print("\n")
import datetime
now = datetime.datetime.now()
print("Current date and time:")
print(now.strftime("%Y-%m-%d %H:%M:%S"))

#4. Circle Area Calculator
print("\n")
from math import pi
r = float(input("Enter radius: "))
area = pi * r ** 2 # ** là toán tử lũy thừa trong python
print("Area of circle: " + str(r) + " is: " + str(area))

#5. Reverse Full Name
print("\n")
fname = input("Enter first name: ")
lname = input("Enter last name: ")
print("Hello " + fname + " " + lname)

#6. List and Tuple Generator
values = input("Input some comma-separated numbers: ")
list = values.split(",")
tuple = tuple(list)
print('List : ', list)
print('Tuple : ', tuple)

#7. File Extension Extractor
print("\n")
filename = input("Enter file name: ")
f_extns = filename.split(".")
print("The extension of the file is : " + repr(f_extns[-1]))

#8. First and Last Colors
color_list =  ["Red", "Green", "White", "Black"]
print("%s %s" % (color_list[0], color_list[-1]))# %s = placeholder chỗ trống để chèn dữ liệu

#9. Exam Schedule Formatter
exam_st_date = (11, 12, 2014)
print("The examination will start from : %i / %i / %i" % exam_st_date)

#10. Number Expansion Calculator
a = int(input("Input an integer: "))
n1 = int("%s" % a) #5
n2 = int("%s%s" % (a, a)) #55
n3 = int("%s%s%s" % (a, a, a))#555
print(n1 + n2 + n3)

#11. Function Documentation Printer
print(abs.__doc__) # In ra nội dung mô tả của hàm abs
print(len.__doc__)

#12. Monthly Calendar Display
import calendar
y = int(input("Input the year : "))
m = int(input("Input the month : "))
print(calendar.month(y, m))

#13. Multi-line Here Document
print("""
a string that you "don't" have to escape
This
is a  ....... multi-line
heredoc string --------> example
""")

#14. Days Between Dates
from datetime import date

f_date = date(2014, 7, 2)

l_date = date(2014, 7, 11)

delta = l_date - f_date

print(delta.days)

#15. Sphere Volume Calculator
pi = 3.1415926535897931
r = 6.0
V = 4.0/3.0 * pi * r**3
print('The volume of the sphere is: ', V)

#16.Difference from 17
def difference(n):

    if n <= 17:
        return 17 - n
    else:
        return (n - 17) * 2

print(difference(22))

print(difference(14))

#17. Number Range Tester
def near_thousand(n):
    return ((abs(1000 - n) <= 100) or (abs(2000 - n) <= 100)) # or chỉ cần 1 trong 2 đk đúng --> True

print(near_thousand(1000))

print(near_thousand(900))

print(near_thousand(800))

print(near_thousand(2200))

#18. Triple Sum Calculator
def sum_thrice(x, y, z):
    sum = x + y + z
    if x == y == z:
        sum = sum * 3
    return sum

print(sum_thrice(1, 2, 3))

print(sum_thrice(3, 3, 3))

#19. Prefix "Is" String Modifier
def new_string(text):
    if len(text) >= 2 and text[:2] == "Is": #text[:2] lấy 2 kí tự đầu
        return text
    else:
        return "Is" + text

print(new_string("Array"))

print(new_string("IsEmpty"))

#20. String Copy Generator
def larger_string(text, n):
    result = ""
    for i in range(n):
        result = result + text
    return result

print(larger_string('abc', 2))

print(larger_string('.py', 3))

#21. Even or Odd Checker
num = int(input("Enter a number: "))

mod = num % 2

if mod > 0:
    print("This is an odd number.")
else:
    print("This is an even number.")
#22. Count 4 in List
def list_count_4(nums):
  count = 0
  for num in nums:
    if num == 4:
      count = count + 1
  return count
print(list_count_4([1, 4, 6, 7, 4]))
print(list_count_4([1, 4, 6, 4, 7, 4]))

#23. String Prefix Copies
def substring_copy(text, n):
  flen = 2
  if flen > len(text):
    flen = len(text)

  substr = text[:flen]
  result = ""

  for i in range(n):
    result = result + substr
  return result

print(substring_copy('abcdef', 2))
print(substring_copy('p', 3))

#24. Vowel Tester
def is_vowel(char):
    all_vowels = 'aeiou'
    return char in all_vowels

print(is_vowel('c'))
print(is_vowel('e'))

#25. Value in Group Tester
def is_group_member(group_data, n):
    for value in group_data:
        if n == value:
            return True
    return False

print(is_group_member([1, 5, 8, 3], 3))
print(is_group_member([5, 8, 3], -1))