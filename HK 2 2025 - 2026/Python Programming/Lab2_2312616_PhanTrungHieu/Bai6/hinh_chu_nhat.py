from hinh_hoc import HinhHoc

class HinhChuNhat(HinhHoc):
    def __init__(self, dai: float, rong: float) -> None:
        super().__init__(dai)   # canh = chiều dài
        self.rong = rong

    @property
    def chieuDai(self) -> float:
        return self.canh

    @property
    def chieuRong(self) -> float:
        return self.rong

    def tinhDienTich(self) -> float:
        return self.canh * self.rong

    def xuat(self):
        print(f"Hình chữ nhật - Dài: {self.canh}, Rộng: {self.rong} - Diện tích: {self.tinhDienTich():.2f}")

    def __str__(self) -> str:
        return f"Hình chữ nhật | d={self.canh}, r={self.rong} | S={self.tinhDienTich():.2f}"