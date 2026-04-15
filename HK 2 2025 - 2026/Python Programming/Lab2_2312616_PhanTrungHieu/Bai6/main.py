from hinh_tron import HinhTron
from hinh_chu_nhat import HinhChuNhat
from hinh_vuong import HinhVuong
from ds_hinh_hoc import DanhSachHinhHoc
from loai_hinh import LoaiHinh

ds = DanhSachHinhHoc()
ds.themHinh(HinhTron(5))
ds.themHinh(HinhTron(3))
ds.themHinh(HinhChuNhat(4, 6))
ds.themHinh(HinhChuNhat(2, 8))
ds.themHinh(HinhVuong(4))
ds.themHinh(HinhVuong(7))

print("=== Toàn bộ danh sách ===")
ds.xuat()

print("\n=== Diện tích lớn nhất ===")
print(ds.timHinhCoDienTichLonNhat())

print("\n=== Diện tích nhỏ nhất ===")
print(ds.timHinhCoDienTichNhoNhat())

print("\n=== Hình tròn lớn nhất ===")
print(ds.timHinhTronLonNhat())

print("\n=== Đếm số hình tròn ===")
print(ds.demSoLuongHinh(LoaiHinh.HinhTron))

print("\n=== Tổng diện tích tất cả ===")
print(f"{ds.tinhTongDienTich():.2f}")

print("\n=== Tổng diện tích hình vuông ===")
print(f"{ds.tinhTongDTTheoKieuHinh(LoaiHinh.HinhVuong):.2f}")

print("\n=== Sắp giảm theo diện tích ===")
ds.sapGiamTheoDienTich()
ds.xuat()

print("\n=== Xuất hình chữ nhật tăng dần ===")
ds.xuatHinhTheoChieuTangGiam(LoaiHinh.HinhChuNhat, tang=True)

print("\n=== Xóa hình theo loại: HinhTron ===")
ds.xoaHinhTheoLoai(LoaiHinh.HinhTron)
ds.xuat()