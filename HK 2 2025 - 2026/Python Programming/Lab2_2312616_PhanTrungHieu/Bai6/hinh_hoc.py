import math

class HinhHoc:
    def __init__(self, canh: float) -> None:
        self.canh = canh

    def tinhDienTich(self) -> float:
        return 0.0   # lớp con sẽ ghi đè

    def xuat(self):
        print(f"Diện tích: {self.tinhDienTich():.2f}")

    def __str__(self) -> str:
        return f"Diện tích: {self.tinhDienTich():.2f}"