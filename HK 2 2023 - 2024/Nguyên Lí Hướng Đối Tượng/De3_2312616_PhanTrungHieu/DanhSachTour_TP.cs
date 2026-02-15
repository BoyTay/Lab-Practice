using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De3_2312616_PhanTrungHieu
{
    public class DanhSachTour_TP
    {
        List<ITour> ds = new List<ITour>();
        public void Them(ITour temp)
        {
            ds.Add(temp);
        }

        public void DocFile(string filename = "DsTour_TP.txt")
        {
            StreamReader sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] s = line.Split(',');
                string maTour = s[0];
                string maTp = s[1];
                int soNgay = int.Parse(s[2]);
                Tour_TP temp = new Tour_TP(maTp, soNgay, maTour);
                Them(temp);
            }
            sr.Close();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var i in ds)
            {
                sb.AppendLine(i.ToString());
            }
            return sb.ToString();
        }

        public void Xuat()
        {
            Console.WriteLine(this);
        }

        //(c) Cho biết các tour không đi qua thành phố 'Nha Trang'. 
        public DanhSachTour_TP DSTourKhongDiQuaNhaTrang()
        {
            DanhSachTour_TP kq = new DanhSachTour_TP();
            foreach (var it in ds)
            {
                if ((it as Tour_TP).MaTP != "02")
                {
                    kq.Them(it as Tour_TP);
                }
            }
            return kq;
        }

        //(d)	Cho biết số lượng thành phố mà mỗi tour du lịch đi qua.
        public class DemTourTP
        {
            public string MaTour { get; set; }
            public int SLTP { get; set; }

            public DemTourTP(string maTour, int slTP)
            {
                MaTour = maTour;
                SLTP = slTP;
            }
        }
        public List<DemTourTP> SoLuongThanhPhoMoiTourDuLichDiQua()
        {
            List<DemTourTP> result = new List<DemTourTP>();

            foreach (var tourTP in ds)
            {
                bool found = false;

                foreach (var item in result)
                {
                    if (item.MaTour == tourTP.MaTour)
                    {
                        item.SLTP++;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    result.Add(new DemTourTP(tourTP.MaTour, 1));
                }
            }
            return result;
        }


    }
}
