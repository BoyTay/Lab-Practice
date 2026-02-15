using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    public class Program
    {
        public enum ThucDon
        {
            Thoat = 0,
            NhapThuCong,
            NhapTuFile,
            Xuat,
            TimKiem,       
            SapXep,
            Them,
            Xoa,        
            CapNhat
        }

        private static ThucDon ChonMenu(int soMenu)
        {
            int menu = 0;
            while (true)
            {
                Console.Write("Nhập số Menu : ");
                if (int.TryParse(Console.ReadLine(), out menu))
                    return (ThucDon)menu;
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            QuanLyNhanVien ds = new QuanLyNhanVien();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===================================== CHỌN CHỨC NĂNG ======================================");
                foreach (ThucDon option in Enum.GetValues(typeof(ThucDon)))
                {
                    Console.WriteLine($"{(int)option}. {option}");
                }
                Console.WriteLine("===========================================================================================");
                string ten, maNV;
                ThucDon chon = ChonMenu(10);
                switch (chon)
                {
                    case ThucDon.NhapTuFile:
                        ds.DocFile("data.txt");
                        break;
                    case ThucDon.Xuat:
                        ds.Xuat();
                        break;
                    case ThucDon.NhapThuCong:
                        Console.Write("Nhập số lượng người muốn thêm:");
                        int soLuong = int.Parse(Console.ReadLine());
                        for (int i = 0; i < soLuong; i++)
                        {
                            ds.NhapThongTinThuCong();
                        }
                        break;
                    case ThucDon.TimKiem:
                        Console.WriteLine("Danh sach ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("======Tim Kiem==========");
                        Console.WriteLine("Nhap 1 de tim theo ten");
                        Console.WriteLine("Nhap 2 de tim theo tuoi");
                        Console.WriteLine("Nhap 3 de tim theo ma nhan vien");
                        Console.WriteLine("Nhap 4 de tim theo phong");
                        Console.WriteLine("========================");
                        Console.Write("Nhap 1 so de chon menu : ");
                        int choice = int.Parse(Console.ReadLine());
                        if (choice == 1)
                        {
                            Console.Write("Nhap ten can tim : ");
                            string tenCanTim = Console.ReadLine();
                            ds.ThuocTinh = Selector.Ten;
                            ds.TimKiem(tenCanTim).Xuat();
                        }
                        else if (choice == 2)
                        {
                            Console.Write("Nhap tuoi can tim : ");
                            int tuoiCanTim=int.Parse(Console.ReadLine());
                            ds.ThuocTinh = Selector.Tuoi;
                            ds.TimKiem(tuoiCanTim).Xuat();
                        }
                        else if (choice == 3)
                        {
                            Console.Write("Nhap ma nhan vien can tim : ");
                           string idCanTim=Console.ReadLine();   
                            ds.ThuocTinh = Selector.MaNhanVien;
                            ds.TimKiem(idCanTim).Xuat();
                        }
                        else if (choice == 4)
                        {
                            Console.Write("Nhap phong can tim : ");
                            string phongCanTim = Console.ReadLine();
                            ds.ThuocTinh = Selector.Phong;
                            ds.TimKiem(phongCanTim).Xuat();
                        }
                        break;
                    case ThucDon.SapXep:
                        Console.WriteLine("Danh sach ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("============SapXep==========");
                        Console.WriteLine("Nhap 1 de sap xep theo ten");
                        Console.WriteLine("Nhap 2 de sap xep theo tuoi");
                        Console.WriteLine("Nhap 3 de sap xep theo ma nhan vien");
                        Console.WriteLine("Nhap 4 de sap xep theo phong");
                        Console.WriteLine("=============================");
                        Console.Write("Nhap 1 so de chon menu : ");
                        int choice1 = int.Parse(Console.ReadLine());
                        if (choice1 == 1)
                        {
                            Console.WriteLine("\nDanh sach sau khi sap xep!!\n");
                            ds.ThuocTinh = Selector.Ten;
                            ds.SapXep();
                            ds.Xuat();

                        }
                        else if (choice1 == 2)
                        {
                            Console.WriteLine("\nDanh sach sau khi sap xep!!\n");
                            ds.ThuocTinh = Selector.Tuoi;
                            ds.SapXep();
                            ds.Xuat();
                        }
                        else if (choice1 == 3)
                        {
                            Console.WriteLine("\nDanh sach sau khi sap xep!!\n");
                            ds.ThuocTinh = Selector.MaNhanVien;
                            ds.SapXep();
                            ds.Xuat();
                        }
                        else if (choice1 == 4)
                        {
                            Console.WriteLine("\nDanh sach sau khi sap xep!!\n");
                            ds.ThuocTinh = Selector.Phong;
                            ds.SapXep();
                            ds.Xuat();
                        }
                        break;
                    case ThucDon.Them:
                        Console.WriteLine("Danh sach ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("=======Them========");
                        Console.WriteLine("Nhan 1 de them nhan vien");
                        Console.WriteLine("Nhan 2 de them quan ly");
                        Console.WriteLine("=============================");
                        Console.Write("Nhap 1 so de chon menu : ");
                        int choice2 = int.Parse(Console.ReadLine());
                        if (choice2 == 1)
                        {
                            Console.Write("\nNhập mã nhân viên: ");
                            string mnv1 = Console.ReadLine();
                            Console.Write("\nNhập Tên: ");
                            string name1 = Console.ReadLine();
                            Console.Write("\nNhập tuổi: ");
                            int age1 = int.Parse(Console.ReadLine());                       
                            Console.Write("\nNhập địa chỉ: ");
                            string dc1 = Console.ReadLine();
                            Console.Write("\nNhập vị trí: ");
                            string vt1 = Console.ReadLine();
                            Console.Write("\nNhập lương: ");
                            decimal luong1 = decimal.Parse(Console.ReadLine());
                            NhanVien nv = new NhanVien(luong1, mnv1, vt1, dc1, name1, age1);
                            ds.Them(nv);
                            Console.WriteLine("\nDa them thanh cong!!");
                        }
                        else if (choice2 == 2)
                        {
                            Console.Write("\nNhập mã nhân viên: ");
                            string mnv1 = Console.ReadLine();
                            Console.Write("\nNhập Tên: ");
                            string name1 = Console.ReadLine();
                            Console.Write("\nNhập tuổi: ");
                            int age1 = int.Parse(Console.ReadLine());
                            Console.Write("\nNhập phòng: ");
                            string phong1 = Console.ReadLine();
                            Console.Write("\nNhập địa chỉ: ");
                            string dc1 = Console.ReadLine();
                            Console.Write("\nNhập vị trí: ");
                            string vt1 = Console.ReadLine();
                            Console.Write("\nNhập lương: ");
                            decimal luong1 = decimal.Parse(Console.ReadLine());
                            QuanLy ql = new QuanLy(phong1, luong1, mnv1, vt1, dc1, name1, age1);
                            ds.Them(ql);
                            Console.WriteLine("\nDa them thanh cong!!");
                        }                    
                        break;
                    case ThucDon.Xoa:
                        Console.WriteLine("Danh sach ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("==============Xoa============");
                        Console.WriteLine("Nhap 1 de xoa theo ten");
                        Console.WriteLine("Nhap 2 de xoa theo tuoi");
                        Console.WriteLine("Nhap 3 de xoa theo ma nhan vien");
                        Console.WriteLine("Nhap 4 de xoa theo phong");
                        Console.WriteLine("=============================");
                        Console.Write("Nhap 1 so de chon menu : ");
                        int choice3 = int.Parse(Console.ReadLine());
                        if (choice3 == 1)
                        {
                            Console.Write("Nhap ten muon xoa : ");
                            string tenCanXoa = Console.ReadLine();
                            ds.ThuocTinh = Selector.Ten;
                            ds.Xoa(tenCanXoa);
                            ds.Xuat();

                        }
                        else if (choice3 == 2)
                        {
                            Console.Write("Nhap tuoi muon xoa : ");
                            int tuoiCanXoa=int.Parse(Console.ReadLine());
                            ds.ThuocTinh = Selector.Tuoi;
                            ds.Xoa(tuoiCanXoa);
                            ds.Xuat();
                        }
                        else if (choice3 == 3)
                        {
                            Console.Write("Nhap ma nhan vien muon xoa : ");
                           string mnvCanXoa=Console.ReadLine();
                            ds.ThuocTinh = Selector.MaNhanVien;
                            ds.Xoa(mnvCanXoa);
                            ds.Xuat();
                        }
                        else if (choice3 == 4)
                        {
                            Console.Write("Nhap phong muon xoa : ");
                            string phongCanXoa = Console.ReadLine();
                            ds.ThuocTinh = Selector.Phong;
                            ds.Xoa(phongCanXoa);
                            ds.Xuat();
                        }
                        break;


                   
                    //case ThucDon.CapNhatTheoTen:                   
                    //    Console.WriteLine("Danh sách ban đầu");
                    //    ds.Xuat();
                    //    Console.Write("Nhap vi tri muon them : ");
                    //    int vtCanNhap = int.Parse(Console.ReadLine());                       
                    //    Console.Write("Nhap ten nhan vien : ");
                    //    string tenMoi = Console.ReadLine();       
                    //    ds.ThuocTinh=Selector.Ten;
                    //    //ds.CapNhat(vtCanNhap - 1, tenMoi);
                    //    Console.WriteLine("Danh sách sau cap nhat");
                    //    ds.Xuat();
                    //    break;
                    //case ThucDon.CapNhatTheoTuoi:
                    //    Console.WriteLine("Danh sách ban đầu");
                    //    ds.Xuat();
                    //    Console.Write("Nhap vi tri muon them : ");
                    //    int vtCanNhap1 = int.Parse(Console.ReadLine());
                    //    Console.Write("Nhập tuổi:");
                    //    ds.ThuocTinh = Selector.Tuoi;
                    //    int tuoi = int.Parse(Console.ReadLine());
                    //    //ds.CapNhat(vtCanNhap1 - 1, tuoi);
                    //    Console.WriteLine("Danh sách sau cap nhat");
                    //    ds.Xuat();
                    //    break;
                    case ThucDon.CapNhat:
                        Console.WriteLine("Danh sách ban đầu");
                        ds.Xuat();
                        Console.WriteLine("============Cap Nhat===========");
                        Console.WriteLine("Nhap 1 de cap nhat thong tin cho nhan vien");
                        Console.WriteLine("Nhap 2 de cap nhat thong tin cho quan ly");
                        Console.WriteLine("=============================");
                        Console.Write("Nhap 1 so de chon menu : ");
                        int choice4 = int.Parse(Console.ReadLine());
                        if(choice4==1)
                        {
                            Console.Write("\nNhập mã nhân viên của nhân viên cần cập nhật : ");
                            string mnv = Console.ReadLine();
                            Console.Write("\nNhập tên mới: ");
                            string name = Console.ReadLine();
                            Console.Write("\nNhập tuổi mới: ");
                            int age = int.Parse(Console.ReadLine());
                            Console.Write("\nNhập địa chỉ mới: ");
                            string dc = Console.ReadLine();
                            Console.Write("\nNhập vị trí mới: ");
                            string vt = Console.ReadLine();
                            Console.Write("\nNhập lương mới: ");
                            decimal luong = decimal.Parse(Console.ReadLine());
                            NhanVien nv = new NhanVien(luong, mnv, vt, dc, name, age);
                            ds.CapNhatNhanVien(nv);
                            Console.WriteLine("\nDa cap nhat thanh cong!!");
                            ds.Xuat();
                        }
                        else if(choice4==2)
                        {
                            Console.Write("\nNhập mã nhân viên của quản lý cần cập nhật: ");
                            string mnv = Console.ReadLine();
                            Console.Write("\nNhập tên mới: ");
                            string name = Console.ReadLine();
                            Console.Write("\nNhập tuổi mới: ");
                            int age = int.Parse(Console.ReadLine());
                            Console.Write("\nNhập phòng mới: ");
                            string phong = Console.ReadLine();
                            Console.Write("\nNhập địa chỉ mới: ");
                            string dc = Console.ReadLine();
                            Console.Write("\nNhập vị trí mới: ");
                            string vt = Console.ReadLine();
                            Console.Write("\nNhập lương mới: ");
                            decimal luong = decimal.Parse(Console.ReadLine());
                            QuanLy ql=new QuanLy(phong,luong,mnv,vt,dc,name,age); 
                            ds.CapNhatQuanLy(ql);
                            Console.WriteLine("\nDa cap nhat thanh cong!!");
                            ds.Xuat();
                        }
                        break;
                    case ThucDon.Thoat:
                        return;
                    default:
                        return;
                }
                Console.WriteLine("Nhap 1 phim de tiep tuc ");
                Console.ReadKey();
            }
        }

       
    }
}
