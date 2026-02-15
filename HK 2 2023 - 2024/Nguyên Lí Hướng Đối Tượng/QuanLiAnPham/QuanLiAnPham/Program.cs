using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiAnPham
{
    public class Program
    {
        public enum ThucDon
        {
            Thoat=0,
            DocFile,
            Xuat,
            Them,
            Xoa,
            TimKiem,
            SapXep,
            CapNhat,
        }
        public static ThucDon ChonMenu(int somenu)
        {
            int menu = 0;
            while (true)
            {
                Console.Write("Nhap so chon menu : ");
                if (int.TryParse(Console.ReadLine(), out menu))
                    return (ThucDon)menu;
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DanhSachAnPham ds=new DanhSachAnPham();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===================================== CHỌN CHỨC NĂNG ======================================");
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
                        ds.DocFile("data.txt");                     
                        break;
                    case ThucDon.Xuat:
                        ds.Xuat();
                        break;
                    case ThucDon.Them:
                        Console.Write("Nhap so luong can them : ");
                        int sl=int.Parse(Console.ReadLine());
                        for (int i = 0; i < sl; i++)
                        {
                            ds.NhapThuCong();
                        }
                        break;
                    case ThucDon.Xoa:
                        Console.WriteLine("Danh sach ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("==============Xoa============");
                        Console.WriteLine("Nhap 1 de xoa theo nam");
                        Console.WriteLine("Nhap 2 de xoa theo nha xuat ban");
                        Console.WriteLine("Nhap 3 de xoa theo tac gia ");
                        Console.WriteLine("Nhap 4 de xoa theo tua de");
                        Console.WriteLine("=============================");
                        Console.Write("Nhap 1 so de chon menu : ");
                        int choice = int.Parse(Console.ReadLine());
                        if (choice==1)
                        {
                            Console.Write("Nhap nam muon xoa : ");
                            int namCanXoa=int.Parse(Console.ReadLine());
                            ds.ThuocTinh = Select.Nam;
                            ds.Xoa(namCanXoa);
                            ds.Xuat();
                        }
                        if (choice ==2)
                        {
                            Console.Write("Nhap nha xuat ban can xoa : ");
                            string nhaXBCanXoa=Console.ReadLine();
                            ds.ThuocTinh=Select.NhaXuatBan;
                            ds.Xoa(nhaXBCanXoa); 
                            ds.Xuat();
                        }
                        if (choice==3)
                        {
                            Console.Write("Nhap tac gia can xoa : ");
                            string tgCanXoa=Console.ReadLine();
                            ds.ThuocTinh = Select.TacGia;
                            ds.Xoa(tgCanXoa);
                            ds.Xuat();
                        }
                        if (choice ==4)
                        {
                            Console.Write("Nhap tua de can xoa : ");
                            string tuaDeCanXoa=Console.ReadLine();
                            ds.ThuocTinh = Select.TuaDe;
                            ds.Xoa(tuaDeCanXoa); 
                            ds.Xuat();
                        }
                        break;
                    case ThucDon.TimKiem:
                        Console.WriteLine("Danh sach ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("======Tim Kiem========");
                        Console.WriteLine("Nhap 1 de tim theo nam");
                        Console.WriteLine("Nhap 2 de tim theo nha xuat ban ");
                        Console.WriteLine("Nhap 3 de tim theo tac gia");
                        Console.WriteLine("Nhap 4 de tim theo tua de");
                        Console.WriteLine("========================");
                        Console.Write("Nhap 1 so de chon menu : ");
                        int choice2 = int.Parse(Console.ReadLine());
                        var kq= new DanhSachAnPham();
                        if (choice2==1)
                        {
                            Console.Write("Nhap nam can tim : ");
                            int namCanTim=int.Parse(Console.ReadLine());
                            ds.ThuocTinh = Select.Nam;
                            kq= ds.TimKiem(namCanTim);
                            kq.Xuat();                           
                        }
                        if (choice2==2)
                        {
                            Console.Write("Nhap nha xuat ban can tim : ");
                            string nhaXBCanTim=Console.ReadLine();
                            ds.ThuocTinh = Select.NhaXuatBan;
                            kq=ds.TimKiem(nhaXBCanTim);
                            kq.Xuat();
                        }
                        if (choice2==3)
                        {
                            Console.Write("Nhap tac gia can tim : ");
                            string tacGiaCanTim=Console.ReadLine();
                            ds.ThuocTinh = Select.TacGia;
                            kq= ds.TimKiem(tacGiaCanTim); 
                            kq.Xuat();
                        }
                        if(choice2==4) 
                        {
                            Console.Write("Nhap tua de can tim : ");
                            string tuaDeCanTim=Console.ReadLine();
                            ds.ThuocTinh = Select.TuaDe;
                            kq = ds.TimKiem(tuaDeCanTim); 
                            kq.Xuat();
                        }
                        break;
                    case ThucDon.CapNhat:
                        Console.WriteLine("Danh sach ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("========Cap Nhat===========");
                        Console.WriteLine("Nhan 1 de cap nhat theo sach ");
                        Console.WriteLine("Nhan 2 de cap nhat theo tap chi");                   
                        Console.WriteLine("========================");
                        Console.Write("Nhap 1 so de chon menu : ");
                        int choice3 = int.Parse(Console.ReadLine());
                        switch(choice3)
                        {
                            case 1:
                                Console.Write("Nhap tua de can cap nhat : ");
                                string tuaDe = Console.ReadLine();
                                Console.Write("Nhap nam: ");
                                int nam = int.Parse(Console.ReadLine());
                                Console.Write("Nhap nha xuat ban : ");
                                string nhaXB = Console.ReadLine();                       
                                Console.Write("Nhap isbn : ");
                                string isbn = Console.ReadLine();
                                Console.Write("Nhap tac gia : ");
                                string tacGia = Console.ReadLine();
                                Sach s = new Sach(nam, nhaXB, tuaDe, isbn, tacGia);
                                ds.CapNhatSach(s);                            
                                ds.Xuat();
                                break;
                            case 2:
                                Console.Write("Nhap tua de can cap nhat : ");
                                string tuaDe1 = Console.ReadLine();
                                Console.Write("Nhap nam: ");
                                int nam1 = int.Parse(Console.ReadLine());
                                Console.Write("Nhap nha xuat ban : ");
                                string nhaXB1 = Console.ReadLine();                   
                                Console.Write("Nhap so : ");
                                int so = int.Parse(Console.ReadLine());
                                Console.Write("Nhap tap : ");
                                int tap = int.Parse(Console.ReadLine());
                                TapChi tc = new TapChi(nam1, nhaXB1, tuaDe1, so, tap);
                                ds.CapNhatTapChi(tc);
                                break;
                                ds.Xuat();
                            default:
                                return;
                        }
                        break;
                    case ThucDon.SapXep:
                        Console.WriteLine("Danh sach ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("========Sap xep===========");
                        Console.WriteLine("Nhan 1 de sap xep theo nam ");
                        Console.WriteLine("Nhan 2 de sap xep theo nha xuat ban");
                        Console.WriteLine("Nhan 3 de sap xep theo tac gia");
                        Console.WriteLine("Nhan 4 de sap xep theo tua de");
                        Console.WriteLine("========================");
                        Console.Write("Nhap 1 so de chon menu : ");
                        int choice4 = int.Parse(Console.ReadLine());
                        switch(choice4)
                        {
                            case 1:
                                ds.ThuocTinh = Select.Nam;
                                ds.SapXep();
                                ds.Xuat();
                                break;
                            case 2:
                                ds.ThuocTinh= Select.NhaXuatBan;
                                ds.SapXep();
                                ds.Xuat();
                                break;
                            case 3:
                                ds.ThuocTinh = Select.TacGia;
                                ds.SapXep();
                                ds.Xuat();
                                break;
                            case 4:
                                ds.ThuocTinh = Select.TuaDe;
                                ds.SapXep();
                                ds.Xuat();
                                break;
                            default:
                                return;
                        }
                        break;
                    default:
                        return;
                        break;
                }
                Console.WriteLine("Nhap 1 phim bat ki de tiep tuc !! ");
                Console.ReadKey();
            }


        }
    }
}
