from datetime import datetime


class Sach:
    def __init__(self, ten_sach: str, ten_tac_gia: str, ngay_xb: datetime, so_trang: int, gia_bia: int):
        self.ten_sach = ten_sach
        self.ten_tac_gia = ten_tac_gia
        self.ngay_xb = ngay_xb
        self.so_trang = so_trang
        self.gia_bia = gia_bia

    def tinh_gia_ban(self):
        raise NotImplementedError("Phương thức tinh_gia_ban() phải được cài đặt ở lớp con.")

    def __str__(self):
        return (f"{self.ten_sach:<25} {self.ten_tac_gia:<20} {self.ngay_xb.year:<15} "
                f"{self.gia_bia:<12} {self.tinh_gia_ban():<10}")


class SachGiay(Sach):
    def __init__(self, ten_sach, ten_tac_gia, ngay_xb, so_trang, gia_bia, trong_luong: int):
        super().__init__(ten_sach, ten_tac_gia, ngay_xb, so_trang, gia_bia)
        self.trong_luong = trong_luong  # đơn vị: gram

    def tinh_gia_ban(self) -> int:
        chiet_khau = 0.05 * self.gia_bia
        phi_van_chuyen = self.trong_luong * 100
        return int(self.gia_bia - chiet_khau + phi_van_chuyen)


class SachDienTu(Sach):
    def __init__(self, ten_sach, ten_tac_gia, ngay_xb, so_trang, gia_bia, dung_luong: float):
        super().__init__(ten_sach, ten_tac_gia, ngay_xb, so_trang, gia_bia)
        self.dung_luong = dung_luong  # đơn vị: MB

    def tinh_gia_ban(self) -> int:
        chiet_khau = 0.25 * self.gia_bia
        phu_thu = 10000 if self.dung_luong > 10 else 0
        return int(self.gia_bia - chiet_khau + phu_thu)


class DsSach:
    def __init__(self):
        self.ds = []

    def them(self, sach: Sach):
        self.ds.append(sach)

    def timSachTheoTacGia(self, ten_tg: str) -> 'DsSach':
        ket_qua = DsSach()
        for s in self.ds:
            if s.ten_tac_gia.lower() == ten_tg.lower():
                ket_qua.them(s)
        return ket_qua

    def timSachTheoNamXb(self, nam_xb: int) -> 'DsSach':
        ket_qua = DsSach()
        for s in self.ds:
            if s.ngay_xb.year == nam_xb:
                ket_qua.them(s)
        return ket_qua

    def timSachTheoSoTrang(self, trang: int) -> 'DsSach':
        ket_qua = DsSach()
        for s in self.ds:
            if s.so_trang > trang:
                ket_qua.them(s)
        return ket_qua

    def sapXepTheoTenTacGia(self):
        self.ds.sort(key=lambda s: s.ten_tac_gia.lower())

    def sapXepTheoNamXb(self):
        self.ds.sort(key=lambda s: s.ngay_xb.year)

    def timSachTheoGiaBan(self, gia_min: int, gia_max: int) -> 'DsSach':
        ket_qua = DsSach()
        for s in self.ds:
            gb = s.tinh_gia_ban()
            if gia_min <= gb <= gia_max:
                ket_qua.them(s)
        return ket_qua

    def in_danh_sach(self, tieu_de="DANH SÁCH SÁCH"):
        print(f"\n{'='*90}")
        print(f"  {tieu_de}")
        print(f"{'='*90}")
        print(f"{'Tên sách':<25} {'Tên tác giả':<20} {'Năm xuất bản':<15} {'Giá bìa':<12} {'Giá bán':<10}")
        print(f"{'-'*90}")
        for s in self.ds:
            print(s)
        print(f"{'='*90}")

    def sach_giay_gia_cao_nhat(self):
        sach_giay = [s for s in self.ds if isinstance(s, SachGiay)]
        if not sach_giay:
            return None
        return max(sach_giay, key=lambda s: s.tinh_gia_ban())

    def sach_dien_tu_dung_luong_lon_nhat(self):
        sach_dt = [s for s in self.ds if isinstance(s, SachDienTu)]
        if not sach_dt:
            return None
        return max(sach_dt, key=lambda s: s.dung_luong)


# ──────────────────────────────────────────────
# Tạo danh sách 5 quyển sách (2 loại khác nhau)
# ──────────────────────────────────────────────
ds = DsSach()

ds.them(SachGiay("Romeo and Juliet",   "Shakespeare",   datetime(1597, 1, 1), 200, 80000,  300))
ds.them(SachGiay("Hai số phận",         "Jeffrey Archer", datetime(1979, 1, 1), 450, 95000,  500))
ds.them(SachGiay("Hamlet",              "Shakespeare",   datetime(1603, 1, 1), 180, 75000,  250))
ds.them(SachDienTu("Đắc nhân tâm",      "Dale Carnegie", datetime(2000, 6, 1), 320, 60000,  8.5))
ds.them(SachDienTu("Nhà giả kim",       "Paulo Coelho",  datetime(1988, 1, 1), 224, 70000, 15.0))

# ──────────────────────────────────────────────
# Yêu cầu 3: Tìm sách xuất bản năm 2000
# ──────────────────────────────────────────────
ds.timSachTheoNamXb(2000).in_danh_sach("Sách xuất bản năm 2000")

# ──────────────────────────────────────────────
# Yêu cầu 4: Tìm sách của tác giả "Shakespeare"
# ──────────────────────────────────────────────
ds.timSachTheoTacGia("Shakespeare").in_danh_sach('Sách của tác giả "Shakespeare"')

# ──────────────────────────────────────────────
# Yêu cầu 5: Tìm sách trên 100 trang
# ──────────────────────────────────────────────
ds.timSachTheoSoTrang(100).in_danh_sach("Sách trên 100 trang")

# ──────────────────────────────────────────────
# Yêu cầu 6 & 7: Sắp xếp và xuất danh sách
# ──────────────────────────────────────────────
ds.sapXepTheoTenTacGia()
ds.sapXepTheoNamXb()
ds.in_danh_sach("Danh sách sắp xếp theo Tên tác giả, Năm xuất bản")

# ──────────────────────────────────────────────
# Yêu cầu 8: Tìm sách có giá bán 100000 – 200000
# ──────────────────────────────────────────────
ds.timSachTheoGiaBan(100000, 200000).in_danh_sach("Sách có giá bán 100,000 – 200,000đ")

# ──────────────────────────────────────────────
# Yêu cầu 9: Sách giấy có giá cao nhất
# ──────────────────────────────────────────────
sg_cao = ds.sach_giay_gia_cao_nhat()
print("\n>>> Sách giấy có giá bán cao nhất:")
if sg_cao:
    print(f"    {sg_cao.ten_sach} - {sg_cao.tinh_gia_ban():,}đ")

# ──────────────────────────────────────────────
# Yêu cầu 10: Sách điện tử dung lượng lớn nhất
# ──────────────────────────────────────────────
sdt_lon = ds.sach_dien_tu_dung_luong_lon_nhat()
print("\n>>> Sách điện tử có dung lượng lớn nhất:")
if sdt_lon:
    print(f"    {sdt_lon.ten_sach} - {sdt_lon.dung_luong} MB")