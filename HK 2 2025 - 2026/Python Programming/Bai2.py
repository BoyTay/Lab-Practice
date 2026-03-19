#Cau 1
def tinh_toan(a,b):
    tong = a + b
    thuong = a / b if b!=0 else "Khong chia duoc cho 0"
    luy_thua = a ** b
    return tong,thuong,luy_thua

a,b = 3,4
tong,thuong,luy_thua = tinh_toan(a,b)
print("Tong a + b : ",tong)
print("Thuong a / b : ",thuong)
print("Luy thua a ** b : ",luy_thua)

#Cau 2
def dien_tich_hcn(dai,rong):
    return dai * rong

dai = float(input("Nhập chiều dài : "))
rong = float(input("Nhập chiều rộng : "))
print("Diện tích hình chữ nhật: ",dien_tich_hcn(dai,rong))

#Cau 3
def so_nguyen_to(n):
    if n < 2:
        return False
    for i in range(2,int(n**0.5)+1):
        if n % i == 0:
            return False
    return True
def so_nguyen_to_trong_khoang(a,b):
    result = [n for n in range(a,b+1) if so_nguyen_to(n)]
    return result
print("Các số nguyên tố là: ",so_nguyen_to_trong_khoang(1,50))

#Cau 4 n là Fibonacci nếu 5*n^2 + 4 hoặc 5*n^2 - 4 là số chính phương
import math

def so_chinh_phuong(n):
    can = int(math.sqrt(n))
    return can * can == n
def is_fibonacci(n):
    return so_chinh_phuong(5 * n * n + 4) or so_chinh_phuong(5 * n * n - 4)

print(is_fibonacci(8))
print(is_fibonacci(9))
print(is_fibonacci(10))

#Cau 5
#Dùng đệ quy
def de_quy(n):
    if n <= 0:
        return 0
    if n == 1:
        return 1
    return de_quy(n - 1) + de_quy(n - 2)

#Không dùng đệ quy
def khong_de_quy(n):
    if n <= 0:
        return 0
    a,b =0,1
    for _ in range(2,n+1):
        a,b = b,a+b
    return b

n=10
print("Fibonacci thứ ",n," (đệ quy) là: ",de_quy(n))
print("Fibonacci thứ ",n," (không đệ quy) là: ",khong_de_quy(n))

#Cau 6
def tong_fib_de_quy(n):
    if n <= 0:
        return 0
    return de_quy(n-1) + tong_fib_de_quy(n-1)

# Không dùng đệ quy
def tong_fib_khong_de_quy(n):
    a, b = 0, 1
    tong = 0
    for _ in range(n):
        tong += a
        a, b = b, a + b
    return tong

n = 7
print(f"Tổng {n} số Fibonacci đầu (đệ quy):     {tong_fib_de_quy(n)}")
print(f"Tổng {n} số Fibonacci đầu (không đệ quy): {tong_fib_khong_de_quy(n)}")

#Cau 7
import  math
def tong_can_bac_2(n):
    

