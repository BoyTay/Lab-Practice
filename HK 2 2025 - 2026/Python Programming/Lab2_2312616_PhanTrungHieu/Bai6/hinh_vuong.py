from hinh_chu_nhat import HinhChuNhat

class HinhVuong(HinhChuNhat):
    def __init__(self, canh: float) -> None:
        super().__init__(canh, canh)  # dài = rộng = canh

    def xuat(self):
        print(f"Hình vuông - Cạnh: {self.canh} - Diện tích: {self.tinhDienTich():.2f}")

    def __str__(self) -> str:
        return f"Hình vuông    | c={self.canh} | S={self.tinhDienTich():.2f}"