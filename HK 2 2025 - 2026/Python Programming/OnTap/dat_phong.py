from datetime import datetime

class DatPhong:
    # Hàm khởi tạo đối tượng đặt phòng
    # Đầu vào : ma_phong (str), sdt (str), ten_nv (str), ngay_nhan (datetime), so_ngay (int), gia_tien (float, mặc định 0)
    # Đầu ra : Không có
    def __init__(self, ma_phong: str, sdt: str, ten_nv: str,
                 ngay_nhan: datetime, so_ngay: int, gia_tien=0) -> None:
        self.ma_phong   = ma_phong
        self.so_dt      = sdt
        self.ten_nv     = ten_nv
        self.ngay_nhan  = ngay_nhan
        self.so_ngay    = so_ngay
        self.gia_tien   = gia_tien

    def __str__(self) -> str:
        # Hàm trả về chuỗi đại diện cho đối tượng
        # Đầu vào : không có
        # Đầu ra : chuỗi gồm các thông tin phòng cách nhau bằng dấu tab
        return (f"{self.ma_phong}\t{self.so_dt}\t"
                f"{self.ngay_nhan.strftime('%d/%m/%Y')}\t"
                f"{self.so_ngay}\t{self.gia_tien}\t{self.ten_nv}")
