using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De3_2312616_PhanTrungHieu
{
    public class DanhSachTour
    {
        public List<ITour> DanhSach = new List<ITour>();

        public void ThemTour(ITour tour)
        {
            DanhSach.Add(tour);
        }

        public void DocFile(string filename = "DsTour.txt")
        {
            StreamReader sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] s = line.Split(',');
                string maTour = s[0];
                int tongSoNgay = int.Parse(s[1]);
                Tour temp = new Tour(maTour, tongSoNgay);
                ThemTour(temp);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var i in DanhSach)
            {
                sb.AppendLine(i.ToString());
            }
            return sb.ToString();
        }

        public void Xuat()
        {
            Console.WriteLine(this);
        }


        //(a) Cho biết các tour du lịch có tổng số ngày của tour từ 3 đến 5 ngày.
        public DanhSachTour DSTourDuLichCoTongNgay3_5()
        {
            DanhSachTour kq = new DanhSachTour();
            foreach (var i in DanhSach)
            {
                if (i.TongSoNgay >= 3 && i.TongSoNgay <= 5)
                {
                    kq.ThemTour(i);
                }
            }
            return kq;
        }



    }
}
