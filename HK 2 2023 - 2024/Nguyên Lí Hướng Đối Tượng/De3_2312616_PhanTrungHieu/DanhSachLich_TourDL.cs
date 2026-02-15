using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De3_2312616_PhanTrungHieu
{
    public class DanhSachLich_TourDL
    {
        List<ITour> ds = new List<ITour>();

        public void Them(ITour temp)
        {
            ds.Add(temp);
        }

        public void DocFile(string filename = "DsLich_TourDL.txt")
        {
            StreamReader sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] s = line.Split(',');
                string maTour = s[0];
                DateTime ngaykh = DateTime.Parse(s[1]);
                string tenHDV = s[2];
                int soNguoi = int.Parse(s[3]);
                string tenKH = s[4];
                ITour temp = new Lich_TourDL(maTour, ngaykh, tenHDV, soNguoi, tenKH, 0);
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

        //(b) Cho biết thông tin các tour được tổ chức trong tháng 2 năm 2017.
        public DanhSachLich_TourDL DSCacTourToChucTrongThang2_2017()
        {
            DanhSachLich_TourDL kq = new DanhSachLich_TourDL();
            foreach (var lichTour in ds)
            {
                if ((lichTour as Lich_TourDL).NgayKH.Month == 2 && (lichTour as Lich_TourDL).NgayKH.Year == 2017)
                {
                    kq.Them((lichTour as Lich_TourDL));
                }
            }
            return kq;
        }

        //(e)	Cho biết số lượng tour du lịch mỗi hướng dẫn viên hướng dẫn. 

        public class DemSLTourCuaHuongDanVien
        {
            public string HDV { get; set; }
            public int SLTour { get; set; }
            public DemSLTourCuaHuongDanVien(string hdv, int slTour)
            {
                HDV = hdv;
                SLTour = slTour;
            }
        }

        public List<DemSLTourCuaHuongDanVien> SLTourCuaHuongDanVien()
        {
            List<DemSLTourCuaHuongDanVien> kq = new List<DemSLTourCuaHuongDanVien>();
            foreach (var lichTour in ds)
            {
                bool found = false;
                foreach (var item in kq)
                {
                    if (item.HDV == (lichTour as Lich_TourDL).TenHDV)
                    {
                        found = true;
                        item.SLTour++;
                        break;
                    }
                }
                if (!found)
                {
                    kq.Add(new DemSLTourCuaHuongDanVien((lichTour as Lich_TourDL).TenHDV, 1));
                }
            }
            return kq;
        }


    }
}
