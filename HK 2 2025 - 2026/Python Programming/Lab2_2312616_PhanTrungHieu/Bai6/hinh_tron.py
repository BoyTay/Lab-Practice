import math
from hinh_hoc import HinhHoc

class HinhTron(HinhHoc):
    def __init__(self, banKinh: float) -> None:
        super().__init__(banKinh)   # canh = banKinh
        self.banKinh = banKinh

    def tinhDienTich(self) -> float:
        return math.pi * self.banKinh ** 2

    def xuat(self):
        print(f"Hình tròn - Bán kính: {self.banKinh} - Diện tích: {self.tinhDienTich():.2f}")

    def __str__(self) -> str:
        return f"Hình tròn  | bk={self.banKinh} | S={self.tinhDienTich():.2f}"