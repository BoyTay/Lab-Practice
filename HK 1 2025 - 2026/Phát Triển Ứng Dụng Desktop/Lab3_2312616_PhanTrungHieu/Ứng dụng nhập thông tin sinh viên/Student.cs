using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ứng_dụng_nhập_thông_tin_sinh_viên
{
    public class Student
    {
        public string MSSV { get; set; }
        public string HoLot { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Lop { get; set; }
        public string GioiTinh { get; set; }  // "Nam" hoặc "Nữ"
        public string CMND { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public List<string> MonHoc { get; set; }
        public override string ToString()
        {
            return $"{MSSV} - {HoLot} {Ten} - Lớp {Lop}";
        }
    }
}
