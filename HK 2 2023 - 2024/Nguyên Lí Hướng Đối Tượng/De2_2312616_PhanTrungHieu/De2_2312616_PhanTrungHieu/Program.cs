using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De2_2312616_PhanTrungHieu
{
    class Program
    {   
        public enum ThucDon
        {
            Thoat=0,
            NhapThuCong,
            DocFile,
            Xuat,
            TimKiem,
            SapXep,
            Them,
            Xoa,
            CapNhat,
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
            DanhSachNhanVien ds=new DanhSachNhanVien();
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
                    case ThucDon.NhapThuCong:
                        Console.Write("Nhap so luong nhan vien : ");
                        int soluong=int.Parse(Console.ReadLine());
                        for (int i = 0; i < soluong; i++)
                        {
                            ds.NhapThuCong();
                        }                 
                        break;
                    case ThucDon.DocFile:
                        ds.DocFile("data.txt");
                        Console.WriteLine("Da doc file thanh cong!!");
                        break;
                     case ThucDon.Xuat:
                        ds.Xuat();
                        break;
                    case ThucDon.TimKiem:
                        Console.WriteLine("Danh sach ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("======Tim Kiem==========");
                        Console.WriteLine("Nhap 1 de tim theo ho");
                        Console.WriteLine("Nhap 2 de tim theo ten");
                        Console.WriteLine("Nhap 3 de tim theo id");
                        Console.WriteLine("Nhap 4 de tim theo phong");
                        Console.WriteLine("========================");
                        Console.Write("Nhap 1 so de chon menu : ");
                        int choice=int.Parse(Console.ReadLine());
                        if(choice == 1)
                        {
                            Console.Write("Nhap ho can tim : ");
                            string hoCanTim = Console.ReadLine();
                            ds.ThuocTinh = Select.Ho;
                            ds.TimKiem(hoCanTim).Xuat();
                        }
                        else if(choice == 2)
                        {
                            Console.Write("Nhap ten can tim : ");
                            string tenCanTim=Console.ReadLine();
                            ds.ThuocTinh= Select.Ten;
                            ds.TimKiem(tenCanTim).Xuat();
                        }
                        else if(choice == 3)
                        {
                            Console.Write("Nhap id can tim : ");
                            int idCanTim=int.Parse(Console.ReadLine());
                            ds.ThuocTinh = Select.NhanVienID;
                            ds.TimKiem(idCanTim).Xuat();
                        }
                        else if (choice == 4)
                        {
                            Console.Write("Nhap phong can tim : ");
                            string phongCanTim=Console.ReadLine();
                            ds.ThuocTinh=Select.Phong;
                            ds.TimKiem(phongCanTim).Xuat();                           
                        }                           
                        break;
                    case ThucDon.SapXep:
                        Console.WriteLine("Danh sach ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("============SapXep==========");
                        Console.WriteLine("Nhap 1 de sap xep theo ho");
                        Console.WriteLine("Nhap 2 de sap xep theo ten");
                        Console.WriteLine("Nhap 3 de sap xep theo ID");
                        Console.WriteLine("Nhap 4 de sap xep theo phong");
                        Console.WriteLine("=============================");
                        Console.Write("Nhap 1 so de chon menu : ");
                        int choice1=int.Parse(Console.ReadLine());
                        if(choice1==1)
                        {
                            Console.WriteLine("\nDanh sach sau khi sap xep!!\n");
                            ds.ThuocTinh = Select.Ho;
                            ds.SapXep();
                            ds.Xuat();

                        }
                        else if(choice1==2)
                        {
                            Console.WriteLine("\nDanh sach sau khi sap xep!!\n");
                            ds.ThuocTinh = Select.Ten;
                            ds.SapXep();
                            ds.Xuat() ;
                        }
                        else if(choice1==3)
                        {
                            Console.WriteLine("\nDanh sach sau khi sap xep!!\n");
                            ds.ThuocTinh = Select.NhanVienID;
                            ds.SapXep();
                            ds.Xuat() ;
                        }
                        else if(choice1==4)
                        {
                            Console.WriteLine("\nDanh sach sau khi sap xep!!\n");
                            ds.ThuocTinh = Select.Phong;
                            ds.SapXep();
                            ds.Xuat() ;
                        }
                        break;
                    case ThucDon.Them:
                        Console.Write("Nhap ho : ");
                        string ho = Console.ReadLine();
                        Console.Write("Nhap ten : ");
                        string ten = Console.ReadLine();
                        Console.Write("Nhap ID : ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Nhap phong : ");
                        string phong = Console.ReadLine();
                        QuanLy x = new QuanLy(ho, ten, id, phong);
                        ds.Them(x);
                        Console.WriteLine("Da them thanh cong!!");
                        break;
                    case ThucDon.Xoa:
                        Console.WriteLine("Danh sach ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("==============Xoa============");
                        Console.WriteLine("Nhap 1 de xoa theo ho");
                        Console.WriteLine("Nhap 2 de xoa theo ten");
                        Console.WriteLine("Nhap 3 de xoa theo id");
                        Console.WriteLine("Nhap 4 de xoa theo phong");
                        Console.WriteLine("=============================");
                        Console.Write("Nhap 1 so de chon menu : ");
                        int choice3 = int.Parse(Console.ReadLine());
                        if (choice3 == 1)
                        {
                            Console.Write("Nhap ho muon xoa : ");
                            string hoCanXoa = Console.ReadLine();
                            ds.ThuocTinh = Select.Ho;
                            ds.Xoa(hoCanXoa);
                            ds.Xuat();

                        }
                        else if(choice3==2)
                        {
                            Console.Write("Nhap ten muon xoa : ");
                            string tenCanXoa = Console.ReadLine();
                            ds.ThuocTinh=Select.Ten;
                            ds.Xoa(tenCanXoa);
                            ds.Xuat();
                        }
                        else if (choice3==3)
                        {
                            Console.Write("Nhap id muon xoa : ");
                            int idCanXoa=int.Parse(Console.ReadLine());
                            ds.ThuocTinh = Select.NhanVienID;
                            ds.Xoa(idCanXoa);
                            ds.Xuat();
                        }
                        else if (choice3==4)
                        {
                            Console.Write("Nhap phong muon xoa : ");
                            string phongCanXoa = Console.ReadLine();
                            ds.ThuocTinh = Select.Phong;
                            ds.Xoa(phongCanXoa);
                            ds.Xuat();                           
                        }                     
                        break;
                    case ThucDon.CapNhat:
                        Console.WriteLine("Danh sach ban dau !!");
                        ds.Xuat();
                        Console.Write("\nNhap id nhan vien can cap nhat : ");
                        int mnv = int.Parse(Console.ReadLine());
                        Console.Write("\nNhap ho moi: ");
                        string hoMoi=Console.ReadLine();
                        Console.Write("\nNhap ten moi : ");
                        string nameMoi = Console.ReadLine();                 
                        Console.Write("\nNhap phong moi : ");
                        string phongMoi=Console.ReadLine();                   
                        QuanLy y = new QuanLy(hoMoi,nameMoi,mnv,phongMoi);
                        Console.WriteLine("\nDa cap nhat danh sach thanh cong !! \n");
                        ds.CapNhatQuanLy(y);
                        ds.Xuat();
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
