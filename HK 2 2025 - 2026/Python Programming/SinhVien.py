from datetime import datetime


class SinhVien:
    #Biến của lớp, chung cho tất cả đối tượng của lớp
    truong ="Đại học Đà Lạt"

    #Hàm khởi tạo, hàm tạo lập: khởi gán các thuộc tính của đối tượng
    def __init__(self, maSo: int, hoTen: str, ngaySinh: datetime) ->None:
        self.__maSo = maSo # thuộc tính private
        self.__hoTen = hoTen
        self.__ngaySinh = ngaySinh

    #Cho phep truy xuất tới thuộc tính từ bên ngoài thông qua trường maSo
    @property
    def maSo(self):
        return self.__maSo

    @property
    def hoTen(self):
        return self.__hoTen

    @property
    def ngaySinh(self):
        return self.__ngaySinh

    #Cho phép thay đổi giá trị thuộc tính maSo
    @maSo.setter
    def maSo(self, maso):
        if self.laMaSoHopLe(maso):
            self.__maSo = maso

    @hoTen.setter
    def hoTen(self, hoTen: str):
        if hoTen.strip():  # không cho phép chuỗi rỗng
            self.__hoTen = hoTen

    @ngaySinh.setter
    def ngaySinh(self, ngaySinh: datetime):
        self.__ngaySinh = ngaySinh


    #Phương thức tĩnh: các phương thức không truy xuất gì đến thuộc tính, hành vi
    #những phương thức này không cần truyền tham số mặc định self
    #đây không phải là một hành vi (phương thức) của một đối tượng thuộc lớp
    @staticmethod
    def laMaSoHopLe(maso: int):
        return len(str(maso)) == 7

    #Phuong thuc cua lop, chi truy xuat toi cac bien thanh vien cua lop
    #Khong truy xuat duoc cac thuoc tinh rieng cua doi tuong
    @classmethod
    def doiTenTruong(self, tenmoi):
        self.truong = tenmoi

    #Tuong tu ghi de phuong thuc toString()
    def __str__(self) ->str:
        return f"{self.__maSo}\t{self.__hoTen}\t{self.__ngaySinh}"

    #Hanh vi cua doi tuong sinh vien
    def xuat(self):
        print(f"{self.__maSo}\t{self.__hoTen}\t{self.__ngaySinh}")

class DanhSachSv:
    def __init__(self) -> None:
        self.dssv = []

    def themSinhVien(self, sv: SinhVien):
        self.dssv.append(sv)

    def xuat(self):
        print(f"{'Mã số':<10} {'Họ tên':<25} {'Ngày sinh'}")
        print("-" * 50)
        for sv in self.dssv:
            print(sv)

    #Tim sinh vien theo mssv, neu co tra ve sinh vien
    def timSvTheoMssv(self, mssv: int):
        return [ sv for sv in self.dssv if sv.maSo == mssv]

    #Tim sinh vien theo mssv, neu co tra ve vi tri cua sinh vien trong danh sach
    def timVTSvTheoMssv(self, mssv: int):
        for i in range(len(self.dssv)):
            if self.dssv[i].maSo == mssv:
                return i
        return -1

    #Xoa sinh vien co ma so mssv, thog bao xoa dc hoac ko
    def xoaSvTheoMssv(self, maSo: int) -> bool:
        vt = self.timVTSvTheoMssv(maSo)
        if vt != -1:
            del self.dssv[vt]
            return True
        else:
            return False
    #Bai 1-----------------------------------------
    #Tim sinh vien ten "Nam"
    def timSvTheoTen(self, ten: str):
        return [sv for sv in self.dssv if ten.lower() in sv.hoTen.lower()]

    def timSvSinhTruocNgay(self, ngay: datetime):
        return [sv for sv in self.dssv if sv.ngaySinh < ngay]

    #Bai 2-----------------------------------------
    def docTuFile(self, duongDan: str):
        with open(duongDan, encoding="utf-8") as f:
            for dong in f:
                dong = dong.strip()
                if not dong:  # bỏ qua dòng trống
                    continue
                phan = dong.split(",")
                if len(phan) < 3:
                    continue
                maSo = int(phan[0].strip())
                hoTen = phan[1].strip()
                ngaySinh = datetime.strptime(phan[2].strip(), "%d/%m/%Y")
                self.dssv.append(SinhVien(maSo, hoTen, ngaySinh))

    def sapXepTheoHoTenTang(self):
        """Sắp xếp tăng dần theo họ tên (A → Z)"""
        self.dssv.sort(key=lambda sv: sv.hoTen)

    def sapXepTheoHoTenGiam(self):
        """Sắp xếp giảm dần theo họ tên (Z → A)"""
        self.dssv.sort(key=lambda sv: sv.hoTen, reverse=True)


if __name__ == "__main__":
    ds = DanhSachSv()

    # Tạo một vài sinh viên
    ds.docTuFile("DataSv.csv") #r"C:\Users\Admin\Downloads\DataSV.csv"

    print("=== DANH SÁCH GỐC ===")
    ds.xuat()

    print("\n=== SẮP XẾP TĂNG THEO HỌ TÊN ===")
    ds.sapXepTheoHoTenTang()
    ds.xuat()

    print("\n=== SẮP XẾP GIẢM THEO HỌ TÊN ===")
    ds.sapXepTheoHoTenGiam()
    ds.xuat()

    print("\n=== TÌM THEO TÊN 'Nam' ===")
    ket_qua = ds.timSvTheoTen("Nam")
    for sv in ket_qua:
        print(sv)

    print("\n=== TÌM SV SINH TRƯỚC 01/01/2004 ===")
    ngay = datetime(2004, 1, 1)
    ket_qua = ds.timSvSinhTruocNgay(ngay)
    for sv in ket_qua:
        print(sv)

    print("\n=== XÓA SV MÃ 2004568 ===")
    ds.xoaSvTheoMssv(2004568)
    ds.xuat()

    print(f"\nTên trường: {SinhVien.truong}")
    SinhVien.doiTenTruong("Đại học Đà Lạt (mới)")
    print(f"Sau khi đổi: {SinhVien.truong}")