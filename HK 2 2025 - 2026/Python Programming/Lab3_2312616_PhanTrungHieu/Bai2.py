import math

# Tổng n số nguyên đầu tiên
def sum_n(n):
    if n <= 0: return 0
    return n + sum_n(n - 1)

# Tính n!
def factorial(n):
    if n <= 1: return 1
    return n * factorial(n - 1)

# Kiểm tra số Fibonacci
def is_fib_recursive(n, a=0, b=1):
    if a == n: return True
    if a > n:  return False
    return is_fib_recursive(n, b, a + b)

# Số Fibonacci thứ n
def fib_n(n):
    if n <= 1: return n
    return fib_n(n - 1) + fib_n(n - 2)

# Tổng n số Fibonacci đầu tiên
def sum_fib(n):
    if n <= 0: return 0
    return fib_n(n - 1) + sum_fib(n - 1)

# Tổng căn bậc 2 của n số nguyên đầu tiên
def sum_sqrt(n):
    if n <= 0: return 0
    return math.sqrt(n) + sum_sqrt(n - 1)

# Test
print(sum_n(5))
print(factorial(5))
print(is_fib_recursive(13))
print(fib_n(7))
print(sum_fib(5))
print(round(sum_sqrt(4), 4))