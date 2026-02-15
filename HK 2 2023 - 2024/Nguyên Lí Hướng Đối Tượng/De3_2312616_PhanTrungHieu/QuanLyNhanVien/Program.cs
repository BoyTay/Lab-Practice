using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CacDsCanThiet ds = new CacDsCanThiet();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===========Chon Chuc Nang===========");
                foreach (ThucDon i in Enum.GetValues(typeof(ThucDon)))
                {
                    Console.WriteLine($"{(int)i}. {i}");
                }
                Console.WriteLine("====================================");
                ThucDon chon = chonMenu(0);
                switch (chon)
                {
                    case ThucDon.Thoat:
                        return;
                    case ThucDon.NhapDuLieu:
                        ds.NVinput();
                        ds.NVKNinput();
                        ds.KNinput();
                        ds.CNinput();
                        break;
                    case ThucDon.TruyVanLuaChonTrenNhieuBang:
                        Console.WriteLine("Hien thi ma so nhan vien ho ten nam lam viec");
                        ds.HienTHiMSNV_HoTen_SoNamLamViec();
                        Console.WriteLine("Liet ke thong tin ve nhan vien:");
                        ds.LietKeThongTinNhanVien();
                        Console.WriteLine("Liet ke cac nhan vien");
                        ds.LietKeCacNhanVien();
                        Console.WriteLine("Liet Ke cac ki nang");
                        ds.XuatTenKNVaMucDoTheoMSNV(ds.TimMSNVTheoHoVaTen("Le Anh Tuan"));
                        break;
                    case ThucDon.TruyVanLong:

                        break;
                    default:
                        return;
                }
                Console.ReadKey();


            }
        }

        static ThucDon chonMenu(int soMenu)
        {
            int menu = 0;
            while (true)
            {
                Console.Write("Nhap so Menu : ");
                if (int.TryParse(Console.ReadLine(), out menu))
                {
                    return (ThucDon)menu;
                }
            }
        }
        enum ThucDon
        {
            Thoat,
            NhapDuLieu,
            TruyVanLuaChonTrenNhieuBang,
            TruyVanLong,


        }


    }
}
