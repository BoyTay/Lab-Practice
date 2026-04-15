from hinh_hoc import HinhHoc
from hinh_tron import HinhTron
from hinh_chu_nhat import HinhChuNhat
from hinh_vuong import HinhVuong
from loai_hinh import LoaiHinh

class DanhSachHinhHoc:
    def __init__(self):
        self.dshh = []

    # ── Thêm / xuất ──────────────────────────────────────────
    def themHinh(self, hh: HinhHoc):
        self.dshh.append(hh)

    def xuat(self):
        for hh in self.dshh:
            print(hh)

    # ── Tìm lớn nhất / nhỏ nhất ──────────────────────────────
    def timHinhCoDienTichLonNhat(self) -> HinhHoc:
        return max(self.dshh, key=lambda h: h.tinhDienTich(), default=None)

    def timHinhCoDienTichNhoNhat(self) -> HinhHoc:
        return min(self.dshh, key=lambda h: h.tinhDienTich(), default=None)

    def timHinhTronLonNhat(self) -> HinhHoc:
        ds = [h for h in self.dshh if isinstance(h, HinhTron)]
        return max(ds, key=lambda h: h.tinhDienTich(), default=None)

    # ── Sắp xếp ──────────────────────────────────────────────
    def sapGiamTheoDienTich(self):
        self.dshh.sort(key=lambda h: h.tinhDienTich(), reverse=True)

    # ── Đếm / tổng ───────────────────────────────────────────
    def demSoLuongHinh(self, kieu: LoaiHinh) -> int:
        if kieu == LoaiHinh.TatCa:
            return len(self.dshh)
        loai = self._layLoai(kieu)
        return sum(1 for h in self.dshh if isinstance(h, loai))

    def tinhTongDienTich(self) -> float:
        return sum(h.tinhDienTich() for h in self.dshh)

    def tinhTongDTTheoKieuHinh(self, kieu: LoaiHinh) -> float:
        loai = self._layLoai(kieu)
        return sum(h.tinhDienTich() for h in self.dshh if isinstance(h, loai))

    # ── Tìm theo loại / diện tích ─────────────────────────────
    def timHinhCoDienTichLonNhatTheoLoai(self, kieu: LoaiHinh) -> HinhHoc:
        loai = self._layLoai(kieu)
        ds = [h for h in self.dshh if isinstance(h, loai)]
        return max(ds, key=lambda h: h.tinhDienTich(), default=None)

    def timHinhTheoDTich(self, dt: float):
        return [h for h in self.dshh if abs(h.tinhDienTich() - dt) < 1e-6]

    # ── Tìm vị trí ───────────────────────────────────────────
    def timViTriCuaHinh(self, h: HinhHoc) -> int:
        for i, hh in enumerate(self.dshh):
            if hh is h:
                return i
        return -1

    # ── Xóa ──────────────────────────────────────────────────
    def xoaTaiViTri(self, viTri: int) -> bool:
        if 0 <= viTri < len(self.dshh):
            del self.dshh[viTri]
            return True
        return False

    def xoaHinh(self, hh: HinhHoc) -> bool:
        vt = self.timViTriCuaHinh(hh)
        return self.xoaTaiViTri(vt)

    def xoaHinhTheoLoai(self, kieu: LoaiHinh):
        loai = self._layLoai(kieu)
        self.dshh = [h for h in self.dshh if not isinstance(h, loai)]

    # ── Xuất theo loại và thứ tự ─────────────────────────────
    def xuatHinhTheoChieuTangGiam(self, kieu: LoaiHinh, tang: bool):
        loai = self._layLoai(kieu)
        ds = [h for h in self.dshh if isinstance(h, loai)]
        ds.sort(key=lambda h: h.tinhDienTich(), reverse=not tang)
        for h in ds:
            print(h)

    # ── Helper nội bộ ─────────────────────────────────────────
    def _layLoai(self, kieu: LoaiHinh):
        """Chuyển LoaiHinh enum → class Python tương ứng"""
        if kieu == LoaiHinh.HinhTron:
            return HinhTron
        if kieu == LoaiHinh.HinhVuong:
            return HinhVuong
        if kieu == LoaiHinh.HinhChuNhat:
            return HinhChuNhat
        return HinhHoc   # TatCa