using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    internal class CacDsCanThiet
    {
        Dictionary<string, ChiNhanh> dscn = new Dictionary<string, ChiNhanh>();
        Dictionary<string, NhanVien> dsnv = new Dictionary<string, NhanVien>();
        Dictionary<string, KiNang> dskn = new Dictionary<string, KiNang>();
        Dictionary<string, NhanVienKyNang> dsnvkn = new Dictionary<string, NhanVienKyNang>();

        public void CNinput()
        {

            StreamReader sr = new StreamReader("ChiNhanh.txt");
            string line = "";
            string[] s = null;
            while ((line = sr.ReadLine()) != null)
            {
                s = line.Split(',');
                dscn[s[0]] = new ChiNhanh(line);
            }
        }
        public void NVinput()
        {

            StreamReader sr = new StreamReader("NhanVien.txt");
            string line = "";
            string[] s = null;
            while ((line = sr.ReadLine()) != null)
            {
                s = line.Split(',');
                dsnv[s[0]] = new NhanVien(line);
            }
        }
        public void KNinput()
        {
            StreamReader sr = new StreamReader("KiNang.txt");
            string line = "";
            string[] s = null;
            while ((line = sr.ReadLine()) != null)
            {
                s = line.Split(',');
                dskn[s[0]] = new KiNang(line);
            }
        }
        public void NVKNinput()
        {
            StreamReader sr = new StreamReader("NhanVienKyNang.txt");
            string line = "";
            string[] s = null;
            while ((line = sr.ReadLine()) != null)
            {
                s = line.Split(',');
                if (!dsnvkn.ContainsKey(s[0]))
                {
                    dsnvkn[s[0]] = new NhanVienKyNang(line);
                }
                dsnvkn[s[0]].ThemKiNang(line);
            }
        }
        public void HienTHiMSNV_HoTen_SoNamLamViec()
        {
            Console.WriteLine("{0,-10}{1,-15}{2,-5}", "MANV", "Ho va Ten ", "Nam lam viec ");
            foreach (var i in dsnv)
            {


                string hovten = i.Value.Ho + " " + i.Value.Ten;

                Console.WriteLine("{0,-10}{1,-15}{2,-5}", i.Key, hovten, 2024 - int.Parse(i.Value.NgayVaoLam.Substring(i.Value.NgayVaoLam.Length - 4, 4)));
            }
        }
        public string LietKeKiNangTheoMSNV(string msnv)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var i in dsnvkn[msnv].KiNang)
            {
                sb.AppendLine(string.Format("{0,-15}{1,-10}", dskn[i.Key].TenKN, i.Value));
            }
            return sb.ToString();
        }

        public void LietKeThongTinNhanVien()
        {
            Console.WriteLine("{0,-10}{1,-15}{2,-15}{3,-10}", "MANV", "Ho va Ten ", "Ngay sinh ", "Ngay lam viec");
            foreach (var i in dsnv)
            {
                string hovten = i.Value.Ho + " " + i.Value.Ten;
                Console.WriteLine("{0,-10}{1,-15}{2,-15}{3,-10}", i.Key, hovten, i.Value.NgaySinh, i.Value.NgayVaoLam);

            }
        }
        public void LietKeCacNhanVien()
        {

            Console.WriteLine("{0,-20}{1,-15}{2,-10}", "Ho va Ten ", "Ten ki nang ", "Muc do ");
            foreach (var i in dsnvkn)
            {
                string s = LietKeKiNangTheoMSNV(i.Key);
                string hovten = dsnv[i.Key].Ho + " " + dsnv[i.Key].Ten;
                Console.WriteLine("{0,-20}{1,-15}", hovten, s);
            }
        }
        public string TimMSNVTheoHoVaTen(string hvt)
        {
            foreach (var i in dsnv)
            {
                string hovten = i.Value.Ho + " " + i.Value.Ten;
                if (hovten == hvt)
                {
                    return i.Value.MANV;
                }
            }
            return "";
        }

        public void XuatTenKNVaMucDoTheoMSNV(string msnv)
        {

            string s = LietKeKiNangTheoMSNV(msnv);

            string hovten = dsnv[msnv].Ho + " " + dsnv[msnv].Ten;
            Console.WriteLine("{0,-20}{1,-15}{2,-10}", "Ho va Ten ", "Ten ki nang ", "Muc do ");
            Console.WriteLine("{0,-20}{1,-15}", hovten, s);


        }

    }
}
