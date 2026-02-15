using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3
{
    internal class XuLy
    {
        public static void TinhTongN(int n, out int tong)
        {
            tong = 0;
            for (int i = 1; i <= n; i++)
            {
                tong += i;
            }
        }

        public static void TinhGiaiThuaN(int n, out int giaiThua)
        {
            giaiThua = 1;
            for (int i = 1; i <= n; i++)
            {
                giaiThua *= i;
            }
        }

        public static void TachChuoi(string hoten, out string s1, out string s2)
        {
            hoten = hoten.Trim();//loại bỏ khoảng trắng đầu và cuối
            int lastSpace = hoten.LastIndexOf(' ');//Tìm vị trí khoảng trắng cuối cùng trong chuỗi họ tên.
            if (lastSpace > 0)
            {
                s1 = hoten.Substring(0, lastSpace); //Lấy phần từ đầu chuỗi đến trước khoảng trắng cuối cùng
                s2 = hoten.Substring(lastSpace + 1); //Lấy phần sau khoảng trắng cuối cùng
            }
            else
            {
                s1 = "";
                s2 = hoten;
            }
        }

        // Hàm kiểm tra hai số nguyên liên tiếp
        public static bool ThuTu(int n1, int n2)
        {
            return n2 == n1 + 1;
        }

    }
}
