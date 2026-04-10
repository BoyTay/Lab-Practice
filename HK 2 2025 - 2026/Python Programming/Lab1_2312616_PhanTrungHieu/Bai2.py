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
    return sum(math.sqrt(i) for i in range(1, n + 1))
n = 5
print(f"Tổng căn bậc 2 của {n} số đầu: {tong_can_bac_2(n):.4f}")

#Cau 8
import math

def giai_phuong_trinh_bac2(a,b,c):
    if a == 0:
        if b == 0:
            return "Phương trình vô nghiệm hoặc vô số nghiệm"
        return f"Phương trình bậc 1: x = {-c/b}"
    delta = b**2 - 4*a*c
    if delta > 0:
        x1 = (-b + math.sqrt(delta))/(2*a)
        x2 = (-b - math.sqrt(delta))/(2*a)
        return f"Hai nghiệm phân biệt: x1 = {x1:.4f}, x2 = {x2:.4f}"
    elif delta==0:
        x = -b/(2*a)
        return f"Nghiệm kép: x = {x:.4f}"
    else:
        return "Phương trình vô nghiệm thực (delta < 0)"

print(giai_phuong_trinh_bac2(1,-5,6))
print(giai_phuong_trinh_bac2(1,-2,1))
print(giai_phuong_trinh_bac2(1,0,1))

#Cau 9
#Dùng đệ quy
def giai_thua_de_quy(n):
    if n < 0:
        return "Không xác định"
    if n == 0 or n == 1:
        return 1
    return n * giai_thua_de_quy(n-1)

#Không dùng đệ quy
def giai_thua(n):
    if n < 0:
        return "Không xác định"
    result = 1
    for i in range(2, n+1):
        result *= i
    return result

print(giai_thua_de_quy(5))
print(giai_thua(5))

#Cau 10
def in_tam_giac(n):
    for i in range(n):
        row = [' '] * n
        if i == n - 1:
            # Hàng cuối: in tất cả *
            row = ['*'] * n
        else:
            row[0] = '*'   # Cột đầu
            row[i] = '*'   # Đường chéo
        print(' '.join(row))

in_tam_giac(7)

#Cau 11
def doi_gio_phut_giay(so_giay):
    gio = so_giay // 3600 # // chia lấy nguyên
    phut = (so_giay % 3600) // 60
    giay = so_giay % 60
    return f"{gio}:{phut}:{giay}"

 # Test
print(doi_gio_phut_giay(3770))
print(doi_gio_phut_giay(7384))
print(doi_gio_phut_giay(60))

#Cau 12
import math
from collections import Counter

arr = [1, 3, 5, 7, 8, 13, 15, 21, 2, 4, 6, 9, 11, 3, 5, 3]

# ── Hàm hỗ trợ ──────────────────────────────────────────
def la_so_chinh_phuong(n):
    can = int(math.sqrt(n))
    return can * can == n

def is_prime(n):
    if n < 2: return False
    for i in range(2, int(n**0.5) + 1):
        if n % i == 0: return False
    return True

def is_fib(n):
    return la_so_chinh_phuong(5*n*n + 4) or la_so_chinh_phuong(5*n*n - 4)

# ── Hàm xử lý match case ────────────────────────────────
def xu_ly_mang(arr, chuc_nang, *args):
    match chuc_nang:
        case "a":
            return [x for x in arr if x % 2 != 0 and x % 5 != 0]
        case "b":
            return [x for x in arr if is_fib(x)]
        case "c":
            primes = [x for x in arr if is_prime(x)]
            return max(primes) if primes else None
        case "d":
            fibs = [x for x in arr if is_fib(x)]
            return min(fibs) if fibs else None
        case "e":
            les = [x for x in arr if x % 2 != 0]
            return sum(les) / len(les) if les else 0
        case "f":
            result = 1
            for x in arr:
                if x % 2 != 0 and x % 3 != 0:
                    result *= x
            return result
        case "g":
            i, j = args[0], args[1]
            arr = arr.copy()
            arr[i], arr[j] = arr[j], arr[i]
            return arr
        case "h":
            match args[0] if args else 1:
                case 1: return arr[::-1]
                case 2: return list(reversed(arr))
                case 3:
                    arr = arr.copy()
                    arr.reverse()
                    return arr
        case "i":
            unique = sorted(set(arr), reverse=True)
            if len(unique) < 2: return None
            return [x for x in arr if x == unique[1]]
        case "j":
            return sum(int(d) for x in arr for d in str(abs(x)))
        case "k":
            so = args[0]
            return arr.count(so)
        case "l":
            n = args[0]
            counter = Counter(arr)
            return [k for k, v in counter.items() if v == n]
        case "m":
            counter = Counter(arr)
            max_count = max(counter.values())
            return [k for k, v in counter.items() if v == max_count]
        case _:
            return "Chức năng không hợp lệ!"

# ── Menu nhập từ bàn phím ────────────────────────────────
def menu():
    print("\n===== MENU CHỨC NĂNG =====")
    print("a) Số lẻ không chia hết cho 5")
    print("b) Các số Fibonacci trong mảng")
    print("c) Số nguyên tố lớn nhất")
    print("d) Số Fibonacci bé nhất")
    print("e) Trung bình các số lẻ")
    print("f) Tích số lẻ không chia hết cho 3")
    print("g) Đổi chỗ 2 phần tử")
    print("h) Đảo ngược mảng")
    print("i) Số lớn thứ nhì")
    print("j) Tổng các chữ số")
    print("k) Đếm số lần xuất hiện của một số")
    print("l) Các số xuất hiện đúng n lần")
    print("m) Số xuất hiện nhiều nhất")
    print("q) Thoát")
    print("==========================")
    print(f"Mảng hiện tại: {arr}")

# ── Vòng lặp chính ──────────────────────────────────────
while True:
    menu()
    chon = input("Nhập chức năng (a-m, q để thoát): ").strip().lower()

    match chon:
        case "g":
            i = int(input("Nhập vị trí thứ nhất: "))
            j = int(input("Nhập vị trí thứ hai: "))
            print("Kết quả:", xu_ly_mang(arr, chon, i, j))
        case "h":
            cach = int(input("Chọn cách đảo ngược (1/2/3): "))
            print("Kết quả:", xu_ly_mang(arr, chon, cach))
        case "k":
            so = int(input("Nhập số cần đếm: "))
            print("Kết quả:", xu_ly_mang(arr, chon, so))
        case "l":
            n = int(input("Nhập số lần xuất hiện n: "))
            print("Kết quả:", xu_ly_mang(arr, chon, n))
        case "q":
            print("Thoát chương trình!")
            break
        case _:
            ket_qua = xu_ly_mang(arr, chon)
            if ket_qua == "Chức năng không hợp lệ!":
                print("⚠️  Vui lòng nhập từ a đến m!")
            else:
                print("Kết quả:", ket_qua)


