using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhSachAnPham
{
    public class Program
    {
        public enum ThucDon
        {
            Thoat=0,
            DocFile,
            Xuat,
            SapXepTangTheoTen,
            TimAPCoGiaTienLonNhat,
        }
        private static ThucDon ChonMenu(int somenu)
        {
            int menu = 0;
            while (true)
            {
                Console.Write("Nhap so menu : ");
                if (int.TryParse(Console.ReadLine(), out menu))
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
                Console.WriteLine("===================================== CHON CHUC NANG ======================================");
                foreach (ThucDon option in Enum.GetValues(typeof(ThucDon)))
                {
                    Console.WriteLine($"{(int)option} . {option}");
                }
                Console.WriteLine("===========================================================================================");
                ThucDon chon = ChonMenu(10);
             
                switch (chon)
                {
                    case ThucDon.Thoat:
                        return;
                    case ThucDon.DocFile:
                        ds.DocFile("dsanpham.txt");
                        ds.Xuat();
                        break;
                    case ThucDon.Xuat:
                        ds.Xuat();
                        break;
                    case ThucDon.SapXepTangTheoTen:
                        Console.WriteLine("Danh sach ban dau !! ");
                        ds.Xuat();
                        Console.WriteLine("Danh sach sau khi duoc sap xep");
                        ds.ThuocTinh = Select.Ten;                     
                        ds.SapXep();
                        ds.Xuat();
                        break;
                    case ThucDon.TimAPCoGiaTienLonNhat:
                        Console.WriteLine("Danh sach ban dau !! ");
                        ds.Xuat();
                        Console.WriteLine("An phim co gia tien lon nhat !!\n ");
                        ds.TimAnPhamGiaMax(ds.TimGiaTienMax()).Xuat();
                        break;
                    default:
                        return;




                }
                Console.WriteLine("Nhan 1 phim bat ki de tiep tuc");
                Console.ReadKey();

            }
        }
    }
}
