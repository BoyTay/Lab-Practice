using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De3_2312616_PhanTrungHieu
{
    public class DanhSachThanhPho
    {
        List<IThanhPho> ds = new List<IThanhPho>();
        public void Them(IThanhPho tp)
        {
            ds.Add(tp);
        }

        public void DocFile(string filename = "DsThanhPho.txt")
        {
            StreamReader sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] s = line.Split(',');
                string maTP = s[0];
                string tenTP = s[1];
                ThanhPho temp = new ThanhPho(maTP, tenTP);
                Them(temp);
            }
            sr.Close();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var it in ds)
            {
                sb.AppendLine(it.ToString());
            }
            return sb.ToString();
        }

        public void Xuat()
        {
            Console.WriteLine(this);
        }

        //(f) Cho biết tên thành phố có nhiều tour du lịch đi qua nhất.
        public string ThanhPhoNhieuTourNhat()
        {
            Dictionary<string, int> DemTour = new Dictionary<string, int>();

            // Đếm số lượng tour đi qua mỗi thành phố
            foreach (var tourTP in ds)
            {
                if (DemTour.ContainsKey(tourTP.MaTP))
                {
                    DemTour[tourTP.TenTP]++;
                }
                else
                {
                    DemTour[tourTP.TenTP] = 1;
                }
            }

            // Tìm thành phố có nhiều tour đi qua nhất
            string mostVisitedCity = null;
            int maxCount = 0;
            foreach (var kvp in DemTour)
            {
                if (kvp.Value > maxCount)
                {
                    maxCount = kvp.Value;
                    mostVisitedCity = kvp.Key;
                }
            }

            return mostVisitedCity;
        }


    }
}
