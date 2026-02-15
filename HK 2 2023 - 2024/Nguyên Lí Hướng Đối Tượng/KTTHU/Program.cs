using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTTHU
{
    public class Program
    {
        enum ThucDon
        {
            Thoat=0,
            DocFile,
            Xuat,
            TimAPGiaTienMax,
            SapXep,
            TimTruyen,
            SapXepTangTheoGiaTien,
            TimAPCoGiaTienLonHon,
        }
        private static ThucDon ChonMenu(int somenu)
        {
            int menu = 0;
            while (true)
            {
                Console.Write("Nhap so de chon menu : ");
                if(int.TryParse(Console.ReadLine(),out menu))
                    return (ThucDon)menu;
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DanhSachAnPham ds = new DanhSachAnPham();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=============ChonChucNang===============");
                foreach (ThucDon option in Enum.GetValues(typeof(ThucDon)))
                {
                    Console.WriteLine($"{(int)option} . {option} ");
                }
                Console.WriteLine("=========================================");
                ThucDon chon = ChonMenu(10);
                var kq = new DanhSachAnPham();
                switch (chon) 
                {
                    case ThucDon.Thoat:
                        return;
                     case ThucDon.DocFile:
                        ds.DocFile("dsanpham.txt");
                        break;
                    case ThucDon.Xuat:
                        ds.Xuat();
                        break;
                    case ThucDon.TimAPGiaTienMax:
                        Console.WriteLine("Danh sach ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("An pham co gia tien lon nhat !!");
                        ds.TimAnPhamGiaTienMax(ds.TimGiaMaxAP()).Xuat();
                        break;
                    case ThucDon.SapXep:
                        Console.WriteLine("Danh sach ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("Danh sach sau khi duoc sap xep !!");
                        ds.ThuocTinh = SeLect.Ten;
                        ds.SapXep();
                        ds.Xuat();
                        break;
                    case ThucDon.TimTruyen:
                        Console.WriteLine("Danh sach ban dau !!");
                        ds.Xuat();
                        Console.Write("Nhap nha xuat ban can tim : ");
                        string nhaXBCanTim=Console.ReadLine();
                        kq=ds.TimTruyenTranh(nhaXBCanTim);
                        kq.Xuat();
                        break;
                    case ThucDon.SapXepTangTheoGiaTien:
                        Console.WriteLine("Danh sach ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("Danh sach sau khi duoc sap xep !!");
                        ds.ThuocTinh = SeLect.GiaTien;
                        ds.SapXep();
                        ds.Xuat();
                        break;
                    case ThucDon.TimAPCoGiaTienLonHon:
                        Console.WriteLine("Danh sach ban dau !!");
                        ds.Xuat();
                        Console.Write("Nhap gia tien y : ");
                        float giaTienCanTim=float.Parse(Console.ReadLine());
                        kq=ds.TimAPCoGiaTienLonHon(giaTienCanTim);
                        kq.Xuat();
                        break;
                    default:
                        return;
                
                
                
                }
                Console.WriteLine("Nhan 1 phim de tiep tuc !!");
                Console.ReadKey();
            }
        }
    }
}
