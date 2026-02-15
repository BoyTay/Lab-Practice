using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuanLyDanhBa
{
    
    enum GioiTinh
    {
        Nam,
        Nu
    }
    internal class ThueBao
    {
        string diaChi;
        GioiTinh gioiTinh;
        string hoTen;
        DateTime ngaySinh;
        string soDT;
        string soCMND;
        public ThueBao()
        {
        }
        public ThueBao(string diaChi, GioiTinh gioiTinh, string hoTen, DateTime ngaySinh, string soDT, string soCMND)
        {
            this.diaChi = diaChi;
            this.gioiTinh = gioiTinh;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.soDT = soDT;
            this.soCMND = soCMND;
        }
        public ThueBao(string tb)
        {
            string[] s = tb.Split(',');
            soCMND = s[0];
            hoTen = s[1];
            ngaySinh = DateTime.Parse(s[2]);
            gioiTinh = (GioiTinh)(s[3]=="Nam"?1:0);
            soDT = s[4];
            diaChi = s[5];
        }
        public void Xuat()
        {
            Console.WriteLine("\nThong tin thue bao!!");
            Console.WriteLine("So CMND: " + soCMND);
            Console.WriteLine("Ho và ten: " + hoTen);
            Console.WriteLine("Ngay sinh: " + ngaySinh.ToString("dd/MM/yyyy"));
            Console.WriteLine("Gioi tinh: " + gioiTinh);
            Console.WriteLine("So đien thoai: " + soDT);
            Console.WriteLine("Đia chi: " + diaChi);
            Console.WriteLine();
        }
        public string ThanhPho
        {
            get 
            {
              int vt=diaChi.LastIndexOf('-');//Dòng này sử dụng phương thức LastIndexOf của lớp string để tìm vị trí xuất hiện cuối cùng của ký tự - trong biến diaChi. Vị trí này sẽ được lưu trữ trong biến vt.
              return diaChi.Substring(vt+1,diaChi.Length-vt-1);//Dòng này sử dụng phương thức Substring của lớp string để trích xuất tên thành phố từ biến diaChi. Phương thức này sẽ lấy chuỗi con bắt đầu từ vị trí vt + 1 (vị trí sau ký tự -) và có độ dài diaChi.Length - vt - 1 (chiều dài của chuỗi diaChi trừ đi vị trí vt và hai ký tự -)
            }
        }
    }

}
