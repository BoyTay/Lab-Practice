from math import  gcd

class PhanSo:
    # __init__: Khởi tạo phân số tu/mau
    # Mặc định tu=0, mau=1  →  có thể gọi PhanSo() hoặc PhanSo(3,5)
    def __init__(self, tu: int = 0, mau: int = 1) -> None:
        if mau == 0:
            raise ValueError("Mẫu số không được bằng 0!")
        self.tu  = tu
        self.mau = mau
        self.rutGon()   # tự rút gọn ngay khi tạo

    # rutGon: Rút gọn phân số bằng UCLN (gcd)
    # Ví dụ: 4/6 → 2/3
    # Quy ước: dấu âm luôn nằm ở tử số

    def rutGon(self):
        #Dua dau am ve tu
        if self.mau < 0:
            self.tu = -self.tu
            self.mau = -self.mau
        uc = gcd(abs(self.tu), abs(self.mau))
        if uc != 0:
            self.tu //= uc
            self.mau //= uc

    # Ghi đè toán tử +, -, *, /

    def __add__(self, other: "PhanSo") -> "PhanSo":
        tu_moi = self.tu * other.mau + self.mau * other.tu
        mau_moi = self.mau * other.mau
        return PhanSo(tu_moi, mau_moi)  # tự rút gọn trong __init__

    def __sub__(self, other: "PhanSo") -> "PhanSo":
        tu_moi = self.tu * other.mau - self.mau * other.tu
        mau_moi = self.mau * other.mau
        return PhanSo(tu_moi, mau_moi)

    def __mul__(self, other: "PhanSo") -> "PhanSo":
        return PhanSo(self.tu * other.tu, self.mau * other.mau)

    def __truediv__(self, other: "PhanSo") -> "PhanSo":
        if other.tu == 0:
            raise ZeroDivisionError("Không thể chia cho phân số 0!")
        return PhanSo(self.tu * other.mau, self.mau * other.tu)

    # So sánh: dùng cho sắp xếp và tìm kiếm
    # Quy đổi về số thực để so sánh

    def _giaTri(self) -> float:
        return self.tu / self.mau

    def __eq__(self, other: "PhanSo") -> bool:
        # Hai phân số bằng nhau khi tử và mẫu sau rút gọn bằng nhau
        return self.tu == other.tu and self.mau == other.mau

    def __lt__(self, other: "PhanSo") -> bool:
        return self._giaTri() < other._giaTri()

    def __le__(self, other: "PhanSo") -> bool:
        return self._giaTri() <= other._giaTri()

    # __str__: hiển thị dạng "tu/mau", nếu mau=1 chỉ hiện tu
    def __str__(self) -> str:
        if self.mau == 1:
            return str(self.tu)
        return f"{self.tu}/{self.mau}"

    def __repr__(self) -> str:
        return self.__str__()


class DanhSachPhanSo:
    def __init__(self) -> None:
        self.ds = []

    def them(self, ps: PhanSo):
        self.ds.append(ps)

    def xuat(self):
        print("Danh sách phân số:")
        print("  ", [str(ps) for ps in self.ds])

    #Bai 4---------------------------------------------

    # 1. Đếm số phân số ÂM (giá trị < 0)
    def demPhanSoAm(self) -> int:
        return sum(1 for ps in self.ds if ps._giaTri() < 0)

    # 2. Tìm phân số DƯƠNG nhỏ nhất
    def timPhanSoDuongNhoNhat(self) -> PhanSo:
        duong = [ps for ps in self.ds if ps._giaTri() > 0]
        if not duong:
            return None
        return min(duong)

    # 3. Tìm TẤT CẢ vị trí của phân số x trong mảng
    def timViTriPhanSo(self, x: PhanSo) -> list:
        return [i for i, ps in enumerate(self.ds) if ps == x]

    # 4. Tổng tất cả phân số ÂM
    def tongPhanSoAm(self) -> PhanSo:
        tong = PhanSo(0, 1)
        for ps in self.ds:
            if ps._giaTri() < 0:
                tong = tong + ps
        return tong

    # 5. Xóa phân số x (xóa lần đầu tiên tìm thấy)
    def xoaPhanSo(self, x: PhanSo) -> bool:
        for i, ps in enumerate(self.ds):
            if ps == x:
                del self.ds[i]
                return True
        return False

    # 6. Xóa tất cả phân số có tử là x
    def xoaTheoTu(self, x: int):
        self.ds = [ps for ps in self.ds if ps.tu != x]

    # 7a. Sắp xếp TĂNG theo giá trị
    def sapTang(self):
        self.ds.sort()

    # 7b. Sắp xếp GIẢM theo giá trị
    def sapGiam(self):
        self.ds.sort(reverse=True)

    # 7c. Sắp xếp TĂNG theo mẫu, nếu bằng mẫu thì so tử
    def sapTangTheoMauTu(self):
        self.ds.sort(key=lambda ps: (ps.mau, ps.tu))

    # 7d. Sp xếp GIẢM theo mẫu, nếu bằng mẫu thì so tử
    def sapGiamTheoMauTu(self):
        self.ds.sort(key=lambda ps: (ps.mau, ps.tu), reverse=True)


if __name__ == "__main__":
    # ── Bài 3: kiểm tra phép tính ──────────────────────────────
    print("=" * 45)
    print("BÀI 3 – Kiểm tra phép tính phân số")
    print("=" * 45)

    a = PhanSo()  # PhanSo() → 0/1
    a.tu = 2
    a.mau = 3
    a.rutGon()  # 2/6 → 1/3

    b = PhanSo(3, 5)  # 3/5

    print(f"a = {a}")
    print(f"b = {b}")
    print(f"a + b = {a + b}")
    print(f"a - b = {a - b}")
    print(f"a * b = {a * b}")
    print(f"a / b = {a / b}")

    # ── Bài 4: danh sách phân số ───────────────────────────────
    print("\n" + "=" * 45)
    print("BÀI 4 – Danh sách phân số")
    print("=" * 45)

    ds = DanhSachPhanSo()
    for ps in [PhanSo(1, 3), PhanSo(-2, 5), PhanSo(3, 4),
               PhanSo(-1, 2), PhanSo(2, 3), PhanSo(1, 3),
               PhanSo(-3, 7), PhanSo(5, 6)]:
        ds.them(ps)

    ds.xuat()

    print(f"\n1. Số phân số âm       : {ds.demPhanSoAm()}")
    print(f"2. PS dương nhỏ nhất   : {ds.timPhanSoDuongNhoNhat()}")

    x = PhanSo(1, 3)
    print(f"3. Vị trí của {x}     : {ds.timViTriPhanSo(x)}")
    print(f"4. Tổng phân số âm     : {ds.tongPhanSoAm()}")

    print(f"\n5. Xóa phân số {x}:")
    ds.xoaPhanSo(x)
    ds.xuat()

    print(f"\n6. Xóa tất cả PS có tử = 3:")
    ds.xoaTheoTu(3)
    ds.xuat()

    print("\n7a. Sắp xếp TĂNG theo giá trị:")
    ds.sapTang()
    ds.xuat()

    print("\n7b. Sắp xếp GIẢM theo giá trị:")
    ds.sapGiam()
    ds.xuat()

    print("\n7c. Sắp xếp TĂNG theo mẫu rồi tử:")
    ds.sapTangTheoMauTu()
    ds.xuat()