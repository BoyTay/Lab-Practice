using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De2_2312616_PhanTrungHieu
{
   public class QuanLy :INhanVien,INguoi,IKhaNangQuanLy
    {
        public string Ho { get; set; }
        public string Ten { get; set; }
        public int NhanVienID { get; set; }
        public string Phong { get; set; }
        public QuanLy(string ho,string ten,int nhanVienID,string phong)
        {
            Ho = ho;
            Ten = ten;
            NhanVienID = nhanVienID;
            Phong = phong;
        }
        public void LayTenDayDu()
        {
            Console.WriteLine(this);
        }
        public void LayThongTinChiTiet()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            return $"{Ho,-8} | {Ten,-5} | {NhanVienID,-8} | {Phong} |";
        }
        public void GanNhiemVu(string nhiemVu)
        {
            Console.WriteLine(this);
        }

    }
}
