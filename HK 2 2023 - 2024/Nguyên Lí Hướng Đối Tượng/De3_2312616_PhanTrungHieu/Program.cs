using De3_2312616_PhanTrungHieu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace De3_2312616_PhanTrungHieu
{
    public class Program
    {
        private static ThucDon ChonMenu(int soMenu)
        {
            int menu = 0;
            while (true)
            {
                Console.Write("Chọn số Menu : ");
                if (int.TryParse(Console.ReadLine(), out menu))
                {
                    return (ThucDon)menu;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DanhSachLich_TourDL dslich = new DanhSachLich_TourDL();
            DanhSachThanhPho dstp = new DanhSachThanhPho();
            DanhSachTour dsTour = new DanhSachTour();
            DanhSachTour_TP dstourtp = new DanhSachTour_TP();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=========================================================");
                foreach (ThucDon option in Enum.GetValues(typeof(ThucDon)))
                {
                    Console.WriteLine($"{(int)option}. {option}");
                }
                Console.WriteLine("=========================================================");
                ThucDon chon = ChonMenu(10);
                switch (chon)
                {
                    case ThucDon.Thoat:
                        return;

                    case ThucDon.DocFile:
                        dslich.DocFile();
                        dsTour.DocFile();
                        dstourtp.DocFile();
                        dstp.DocFile();
                        break;
                    case ThucDon.Xuat:
                        dslich.Xuat();
                        Console.WriteLine();
                        dsTour.Xuat();
                        Console.WriteLine();
                        dstourtp.Xuat();
                        Console.WriteLine();
                        dstp.Xuat();
                        break;
                    case ThucDon.TourDuLichCoTongNgay3_5:
                        dsTour.DSTourDuLichCoTongNgay3_5().Xuat();
                        break;
                    case ThucDon.DSCacTourToChucTrongThang2_2017:
                        dslich.DSCacTourToChucTrongThang2_2017().Xuat();
                        break;
                    case ThucDon.DSTourKhongDiQuaNhaTrang:
                        dstourtp.DSTourKhongDiQuaNhaTrang().Xuat();
                        break;
                    case ThucDon.SoLuongThanhPhoMoiTourDuLichDiQua:
                        var soLuong = dstourtp.SoLuongThanhPhoMoiTourDuLichDiQua();
                        foreach (var x in soLuong)
                        {
                            Console.WriteLine($"Tour {x.MaTour}  đi qua {x.SLTP} thành phố ");
                        }
                        break;
                    case ThucDon.SLTourCuaHuongDanVien:
                        var dem = dslich.SLTourCuaHuongDanVien();
                        foreach (var x in dem)
                        {
                            Console.WriteLine($"Số Lượng tour HDV {x.HDV} hướng dẫn là : {x.SLTour}");
                        }
                        break;
                    case ThucDon.ThanhPhoNhieuTourNhat:
                        Console.WriteLine(dstp.ThanhPhoNhieuTourNhat());
                        break;
                }
                Console.WriteLine("Nhấn phím bất kỳ để tiếp tục");
                Console.ReadKey();
            }
        }

        public enum ThucDon
        {
            Thoat,
            DocFile,
            Xuat,
            TourDuLichCoTongNgay3_5,
            DSCacTourToChucTrongThang2_2017,
            DSTourKhongDiQuaNhaTrang,
            SoLuongThanhPhoMoiTourDuLichDiQua,
            SLTourCuaHuongDanVien,
            ThanhPhoNhieuTourNhat
        }
    }
}
