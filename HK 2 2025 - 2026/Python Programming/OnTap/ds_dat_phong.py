import pandas as pd
from datetime import datetime
from dat_phong import DatPhong

class DsDatPhong:
    # Hàm khởi tạo danh sách đặt phòng
    # Đầu vào : ds (list hoặc None, mặc định là [])
    # Đầu ra : không có
    def __init__(self, ds: list | None = []) -> None:
        self.ds_dat_phong = ds

    # Hàm xuất danh sách đặt phòng
    # Đầu vào : không có
    # Đầu ra : không có (in ra màn hình)
    def xuat_ds(self):
        for dp in self.ds_dat_phong:
            print(dp)

    # Hàm thêm một đối tượng DatPhong vào danh sách
    # Đầu vào : dp (DatPhong)
    # Đầu ra : không có
    def them_dp(self, dp: DatPhong):
        self.ds_dat_phong.append(dp)

    def tim_theo_ma_phong(self, ma_phong: str) -> list:
        # Tìm tất cả đặt phòng có mã phòng trùng với đầu vào
        # Đầu vào: ma_phong (str) – mã phòng cần tìm
        # Đầu ra: danh sách (list) các DatPhong có cùng mã phòng
        ket_qua = []
        for dp in self.ds_dat_phong:
            if dp.ma_phong == ma_phong:
                ket_qua.append(dp)
        return ket_qua

    def doc_tu_file(self, file_name):
        data = pd.read_csv(file_name, delimiter=',', encoding='ISO-8859-1')
        for index, row in data.iterrows():
            dp = DatPhong(row['MAPHONG'], row['SDT'], row['TenNV'],
                          datetime.strptime(row['NgayNhanPhong'], "%m/%d/%Y"),
                          int(row['SoNgay']), float(row['GiaTien']))
            self.them_dp(dp)

    def luu_xuong_file(self, file_name, dp: DatPhong):
        # Ghi thêm 1 dòng đặt phòng mới vào cuối file CSV
        # Đầu vào: file_name (str), dp (DatPhong)
        # Đầu ra: không có
        with open(file_name, 'a', encoding='ISO-8859-1') as f:
            f.write(f"\n{dp.ma_phong},{dp.so_dt},{dp.ten_nv},"
                    f"{dp.ngay_nhan.strftime('%m/%d/%Y')},"
                    f"{dp.so_ngay},{dp.gia_tien}")