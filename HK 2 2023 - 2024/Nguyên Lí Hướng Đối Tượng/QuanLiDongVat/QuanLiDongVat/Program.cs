using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Collections.ObjectModel;

namespace QuanLiDongVat
{
    internal class Program
    {
        public enum ThucDon
        {
            DocFile = 1,
            Them,
            Xuat,
            DemSLDVLion,
            DemSLDVBat,
            DemSLDVBird,
            DemSLDVBietBay,
            DemSLDVKhongBietBay,
            DemSLDVKhongBietBayTheoTen,
            DemSLDVKhongBietBayTheoTuoi,
            DemSLDVBietBayTheoTen,
            DemSLDVBietBayTheoTuoi,
            TimDongVatCoSoLuongNhieuItNhat,
            TimAllDongVat,
            TimAllDongVatCoTenDaiNganNhat,
            TimAllDVCoTuoiLonNhoNhat,
            TimAllDVCoTenNganDaiTheoLoai,
            TimAllDVCoTuoiLonNhoNhatTheoLoai,
            DanhSachDVBietBay,
            DanhSachDVKhongBietBay,
            SapSepTangGiamTheoTenTuoi,
            XoaAllDVTheoLoai,
            XoaAllDVBietBay,
            XoaAllDVKhongBietBay,
            XoaAllDVBietBayTheoTenTuoi,
            XoaAllDVKhongBietBayTheoTenTuoi,
            XoaAllDVCoTuoiLonNhat,
            XoaAllDVCoTuoiNhoNhat,
            XoaAllDVTheoLoaiCoTuoiLonNhoNhat,
            XoaDVTaiViTriX,
            TinhTongTuoiTheoLoai,
            TinhTongTuoiDVBietKhongBietBay,
            ThemDVVaoViTri,
            HienThiDSTangGiamTheoTenTuoi,
            HienThiDanhSachBatBirdLion,
            HienThiDSBatBirdLionTangGiamTheoTenTuoi






    }
    public static void Main(string[] args)
        {
            QuanLiDongVat ds = new QuanLiDongVat();
            List<IAnimal> dsdv = new List<IAnimal>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("========Chon chuc nang=========");
                Console.WriteLine($"Nhap {(int)ThucDon.DocFile} de nhap tu file");
                Console.WriteLine($"Nhap {(int)ThucDon.Them} de them dong vat");
                Console.WriteLine($"Nhap {(int)ThucDon.Xuat} de xuat");
                Console.WriteLine($"Nhap {(int)ThucDon.DemSLDVLion} de dem so luong Lion");
                Console.WriteLine($"Nhap {(int)ThucDon.DemSLDVBat} de dem so luong Bat");
                Console.WriteLine($"Nhap {(int)ThucDon.DemSLDVBird} de dem so luong Bird");
                Console.WriteLine($"Nhap {(int)ThucDon.DemSLDVBietBay} de dem so luong DV biet bay");
                Console.WriteLine($"Nhap {(int)ThucDon.DemSLDVKhongBietBay} de dem so luong DV khong biet bay");
                Console.WriteLine($"Nhap {(int)ThucDon.DemSLDVKhongBietBayTheoTen} de dem so luong loai khong biet bay theo ten");
                Console.WriteLine($"Nhap {(int)ThucDon.DemSLDVKhongBietBayTheoTuoi} de dem so luong loai  khong biet bay theo tuoi");
                Console.WriteLine($"Nhap {(int)ThucDon.DemSLDVBietBayTheoTen} de dem so luong loai biet bay theo ten");
                Console.WriteLine($"Nhap {(int)ThucDon.DemSLDVBietBayTheoTuoi} de dem so luong loai biet bay theo tuoi");
                Console.WriteLine($"Nhap {(int)ThucDon.TimDongVatCoSoLuongNhieuItNhat} de tim dong vat co so luong nhieu it nhat");   
                Console.WriteLine($"Nhap {(int)ThucDon.TimAllDongVat} de tim tat ca dong vat thuoc loai Bat,Lion,Bird");
                Console.WriteLine($"Nhap {(int)ThucDon.TimAllDongVatCoTenDaiNganNhat} de tim tat ca dong vat co ten dai ngan nhat");
                Console.WriteLine($"Nhap {(int)ThucDon.TimAllDVCoTuoiLonNhoNhat} de tim dong vat co tuoi lon nhat nho nhat");
                Console.WriteLine($"Nhap {(int)ThucDon.TimAllDVCoTenNganDaiTheoLoai} de tim dong vat co ten dai ngan theo loai");
                Console.WriteLine($"Nhap {(int)ThucDon.TimAllDVCoTuoiLonNhoNhatTheoLoai} de tim tat ca dong vat co tuoi lon nho nhat theo loai");
                Console.WriteLine($"Nhap {(int)ThucDon.DanhSachDVBietBay} de tim danh sach cac dong vat biet bay");
                Console.WriteLine($"Nhap {(int)ThucDon.DanhSachDVKhongBietBay} de tim danh sach cac dong vat khong biet bay");
                Console.WriteLine($"Nhap {(int)ThucDon.SapSepTangGiamTheoTenTuoi} de sap sep tang giam theo ten tuoi");
                Console.WriteLine($"Nhap {(int)ThucDon.XoaAllDVTheoLoai} de xoa tat ca dong vat theo loai");
                Console.WriteLine($"Nhap {(int)ThucDon.XoaAllDVBietBay} de xoa dong vat biet bay");
                Console.WriteLine($"Nhap {(int)ThucDon.XoaAllDVKhongBietBay} de xoa dong vat khong biet bay");
                Console.WriteLine($"Nhap {(int)ThucDon.XoaAllDVBietBayTheoTenTuoi} de xoa tat ca dong vat biet bay theo ten tuoi");
                Console.WriteLine($"Nhap {(int)ThucDon.XoaAllDVKhongBietBayTheoTenTuoi} de xoa tat ca dong vat khong biet bay theo ten tuoi");
                Console.WriteLine($"Nhap {(int)ThucDon.XoaAllDVCoTuoiLonNhat} de xoa tat ca dong vat co tuoi lon nhat");
                Console.WriteLine($"Nhap {(int)ThucDon.XoaAllDVCoTuoiNhoNhat} de xoa tat ca dong vat co tuoi nho nhat");
                Console.WriteLine($"Nhap {(int)ThucDon.XoaAllDVTheoLoaiCoTuoiLonNhoNhat} de xoa tat ca dong vat theo loai lon nho nhat");
                Console.WriteLine($"Nhap {(int)ThucDon.XoaDVTaiViTriX} de xoa dong vat tai vi tri x");
                Console.WriteLine($"Nhap {(int)ThucDon.TinhTongTuoiTheoLoai} de tinh tong tuoi theo loai");
                Console.WriteLine($"Nhap {(int)ThucDon.TinhTongTuoiDVBietKhongBietBay} de tinh tong tuoi dong vat biet bay va khong biet bay");
                Console.WriteLine($"Nhap {(int)ThucDon.ThemDVVaoViTri} de them dong vat vao vi tri");
                Console.WriteLine($"Nhap {(int)ThucDon.HienThiDSTangGiamTheoTenTuoi} de hien thi danh sach tang giam theo ten tuoi");
                Console.WriteLine($"Nhap {(int)ThucDon.HienThiDanhSachBatBirdLion} de hien thi danh sach Bat Bird Lion");
                Console.WriteLine($"Nhap {(int)ThucDon.HienThiDSBatBirdLionTangGiamTheoTenTuoi} de hien thi danh sach Bat Bird Lion tang giam theo ten tuoi"); 
                
                
                Console.Write("\nNhap 1 so de chon menu : ");
                
                ThucDon chon = (ThucDon)int.Parse(Console.ReadLine());
                switch(chon)
                {
                    case ThucDon.DocFile:
                        ds.DocFile("data.txt");
                        Console.WriteLine("Nhap tu file thanh cong!!");
                        StreamWriter sw = new StreamWriter("filera.txt");
                        sw.WriteLine("em hieu ngu ngoc");
                        sw.Close();
                        break;                 
                    case ThucDon.Them:
                    
                        Console.Write("Nhap ten loai ban muon them (Lion, Bat, Bird): ");
                        string animalType = Console.ReadLine();
                        Console.Write("Nhap ten cua loai: ");
                        string name = Console.ReadLine();
                        Console.Write("Nhap tuoi cua loai: ");
                        int age = int.Parse(Console.ReadLine());                       
                        IAnimal newAnimal;
                        switch (animalType.ToLower()) //  ToLower() Chuyển đổi tất cả các chữ cái viết hoa (AZ) trong chuỗi thành các chữ cái viết thường (az).
                        {
                            case "lion":
                                newAnimal = new Lion { Name = name, Age = age };
                                break;
                            case "bat":
                                newAnimal = new Bat { Name = name, Age = age };
                                break;
                            case "bird":
                                newAnimal = new Bird { Name = name, Age = age };
                                break;                           
                            default:
                                Console.WriteLine("Khong co loai nay trong danh sach.Vui long nhap lai!!");
                                Console.ReadKey();
                                return; 
                        }                     
                        ds.Them(newAnimal);
                        Console.WriteLine("Da them dong vat thanh cong!!");                   
                        break;
                    case ThucDon.Xuat:
                        ds.Xuat();
                        break;

                    case ThucDon.DemSLDVLion:
                        Console.Write("So luong loai Lion :"+ds.DemSLDVLion());
                       
                        break;
                    case ThucDon.DemSLDVBat:
                        Console.Write("So luong loai Bat :" + ds.DemSLDVBat());
                        break;
                    case ThucDon.DemSLDVBird:
                        Console.Write("So luong loai Bird :" + ds.DemSLDVBird());
                        break;
                    case ThucDon.DemSLDVBietBay:
                        Console.Write("So luong loai biet bay :" + ds.DemSLDVBietBay());
                        break;
                    case ThucDon.DemSLDVKhongBietBay:
                        Console.Write("So luong loai khong biet bay :" + ds.DemSLDVKhongBietBay());
                        break;
                    case ThucDon.DemSLDVKhongBietBayTheoTen:
                        Console.Write("Nhap ten dong vat khong biet bay can dem : "); 
                        string ten=Console.ReadLine();
                        Console.WriteLine($"So luong loai khong biet bay theo ten {ten} :" + ds.DemSLDVKhongBietBayTheoTen(ten));
                        break;
                    case ThucDon.DemSLDVKhongBietBayTheoTuoi:
                        Console.Write("Nhap tuoi dong vat khong biet bay can dem : ");
                        int tuoi =int.Parse(Console.ReadLine());
                        Console.WriteLine($"So luong loai khong biet bay theo tuoi {tuoi} :" + ds.DemSLDVKhongBietBayTheoTuoi(tuoi));
                        break;
                    case ThucDon.DemSLDVBietBayTheoTen:
                        Console.Write("Nhap ten dong vat biet bay can dem : ");
                        string t = Console.ReadLine();
                        Console.WriteLine($"So luong loai khong biet bay theo ten {t} :" + ds.DemSLDVBietBayTheoTen(t));
                        break;
                    case ThucDon.DemSLDVBietBayTheoTuoi:
                        Console.Write("Nhap tuoi dong vat biet bay can dem : ");
                        int y = int.Parse(Console.ReadLine());
                        Console.WriteLine($"So luong loai khong biet bay theo tuoi {y} :" + ds.DemSLDVBietBayTheoTuoi(y));
                        break;
                    case ThucDon.TimDongVatCoSoLuongNhieuItNhat:
                        Console.Write("Dong vat co so luong lon nhat: ");
                        Console.WriteLine(ds.TimDongVatCoSoLuongNhieuNhat());
                        Console.Write("Dong vat co so luong it nhat: ");
                        Console.WriteLine(ds.TimDongVatCoSoLuongItNhat());
                        break;                                    
                    case ThucDon.TimAllDongVat:
                        Console.WriteLine("Danh sach cac dong vat thuoc loai Lion:");
                        dsdv = ds.TimAllDongVatLion();
                        ds.DanhSachList(dsdv);
                        Console.WriteLine("Danh sach cac dong vat thuoc loai Bat:");
                        dsdv = ds.TimAllDongVatBat();
                        ds.DanhSachList(dsdv);
                        Console.WriteLine("Danh sach cac dong vat thuoc loai Bird:");
                        dsdv = ds.TimAllDongVatBird();
                        ds.DanhSachList(dsdv);
                        break;
                    case ThucDon.TimAllDongVatCoTenDaiNganNhat:
                        Console.WriteLine("Dong vat co ten dai nhat :");
                        dsdv=ds.TimAllDVCoTenDaiNhat();
                        ds.DanhSachList(dsdv);
                        Console.WriteLine("Dong vat co ten ngan nhat : ");
                        dsdv=ds.TimAllDVCoTenNganNhat();
                        ds.DanhSachList(dsdv);
                        break;
                    case ThucDon.TimAllDVCoTuoiLonNhoNhat:
                        Console.WriteLine("Dong vat co tuoi lon nhat : ");
                        dsdv=ds.TimAllDVCoTuoiLonNhat();
                        ds.DanhSachList(dsdv);
                        Console.WriteLine("Dong vat co tuoi nho nhat : ");
                        dsdv=ds.TimAllDVCoTuoiNhoNhat();
                        ds.DanhSachList(dsdv);
                        break;
                    case ThucDon.TimAllDVCoTenNganDaiTheoLoai:
                        Console.Write("Nhap loai muon tim ten dai nhat (Lion,Bat,Bird) :");
                        string loail = Console.ReadLine();
                        Console.Write("Nhap loai muon tim ten ngan nhat (Lion,Bat,Bird) :");
                        string loais = Console.ReadLine();
                        Console.WriteLine($"\nDong vat co ten dai nhat theo loai {loail} !! ");
                        dsdv = ds.TimDVCoTenDaiNhatTheoLoai(loail);
                        ds.DanhSachList(dsdv);
                        Console.WriteLine($"\nDong vat co ten ngan nhat theo loai {loais} !! ");
                        dsdv = ds.TimDVCoTenNganNhatTheoLoai(loais);
                        ds.DanhSachList(dsdv);
                        break;

                    case ThucDon.TimAllDVCoTuoiLonNhoNhatTheoLoai:
                        Console.Write("Nhap loai muon tim tuoi lon nhat (Lion,Bat,Bird) :");
                        string loaib = Console.ReadLine();
                        Console.Write("Nhap loai muon tim tuoi nho nhat (Lion,Bat,Bird) :");
                        string loain=Console.ReadLine();
                        Console.WriteLine($"\nDong vat co tuoi lon nhat theo loai {loaib} !! ");
                        dsdv = ds.TimAllDVCoTuoiLonNhatTheoLoai(loaib);
                        ds.DanhSachList(dsdv);
                        Console.WriteLine($"\nDong vat co tuoi nho nhat theo loai {loain} !! ");
                        dsdv = ds.TimAllDVCoTuoiNhoNhatTheoLoai(loain);
                        ds.DanhSachList(dsdv);
                        break;
                    case ThucDon.DanhSachDVBietBay:
                        Console.WriteLine("Danh sach cac dong vat biet bay !!");
                        dsdv= ds.DanhSachDVBietBay();
                        ds.DanhSachList(dsdv);
                        break;
                    case ThucDon.DanhSachDVKhongBietBay:
                        Console.WriteLine("Danh sach cac dong vat khong biet bay !!");
                        dsdv=ds.DanhSachDVKhongBietBay();
                        ds.DanhSachList(dsdv);
                        break;
                    case ThucDon.SapSepTangGiamTheoTenTuoi:
                        Console.WriteLine("Danh sach tang theo ten !!");
                        ds.SapSepDVTangTheoTen();
                        Console.WriteLine("Danh sach giam theo ten !!");
                        ds.SapSepDVGiamTheoTen();
                        Console.WriteLine("Danh sach tang theo tuoi !!");
                        ds.SapSepDVTangTheoTuoi();
                        Console.WriteLine("Danh sach giam theo tuoi !!");
                        ds.SapSepDVGiamTheoTuoi();
                        break;
                    case ThucDon.XoaAllDVTheoLoai:
                        Console.Write("Nhap loai dong vat muon xoa (Lion,Bat,Bird): ");
                        string loair= Console.ReadLine();
                        Console.WriteLine($"Dong vat loai {loair} da duoc xoa thanh cong !!");
                        ds.XoaAllDVTheoLoai(loair);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaAllDVBietBay:
                        Console.WriteLine("Cac dong vat biet bay da duoc xoa thanh cong !!");
                        ds.XoaAllDVBietBay();
                        ds.Xuat();
                        break;
                    case ThucDon.XoaAllDVKhongBietBay:
                        Console.WriteLine("Cac dong vat khong biet bay da duoc xoa thanh cong!!");
                        ds.XoaAllDVKhongBietBay();
                        ds.Xuat();
                        break;
                    case ThucDon.XoaAllDVBietBayTheoTenTuoi:
                        Console.Write("Nhap ten dong vat biet bay muon xoa :");
                        string Name= Console.ReadLine();
                        Console.Write("Nhap tuoi dong vat biet bay muon xoa : ");
                        int Age=int.Parse(Console.ReadLine());
                        Console.WriteLine("\nDa xoa thanh cong !!");
                        ds.XoaAllDVBietBayTheoTenTuoi(Name, Age);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaAllDVKhongBietBayTheoTenTuoi:
                        Console.Write("Nhap ten dong vat khong biet bay muon xoa :");
                        string Name1 = Console.ReadLine();
                        Console.Write("Nhap tuoi dong vat khong biet bay muon xoa : ");
                        int Age1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nDa xoa thanh cong !!");
                        ds.XoaAllDVKhongBietBayTheoTenTuoi(Name1, Age1);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaAllDVCoTuoiLonNhat:
                        Console.WriteLine("Dong vat co tuoi lon nhat da duoc xoa !!");
                        ds.XoaAllDVCoTuoiLonNhat();
                        ds.Xuat();
                        break;
                    case ThucDon.XoaAllDVCoTuoiNhoNhat:
                        Console.WriteLine("Dong vat co tuoi nho nhat da duoc xoa !!");
                        ds.XoatAllDVCoTuoiNhoNhat();
                        ds.Xuat(); 
                        break;
                    case ThucDon.XoaAllDVTheoLoaiCoTuoiLonNhoNhat:
                        Console.Write("Nhap loai dong vat muon xoa : ");
                        string loaim = Console.ReadLine();
                        Console.WriteLine($"Loai {loaim} co tuoi lon nhat da duoc xoa !!\n");
                        ds.XoaAllDVTheoLoaiCoTuoiLonNhat(loaim);
                        ds.Xuat();
                        Console.WriteLine($"Loai {loaim} co tuoi nho nhat da duoc xoa !!\n");
                        ds.XoaAllDVTheoLoaiCoTuoiNhoNhat(loaim);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaDVTaiViTriX:
                        Console.Write("Nhap vao vi tri x muon xoa dong vat : ");
                        int x=int.Parse(Console.ReadLine());
                        ds.XoaDVTaiViTriX(x);
                        Console.WriteLine($"Dong vat tai vi tri {x} da duoc xoa !!\n");
                        ds.Xuat();
                        break;
                    case ThucDon.TinhTongTuoiTheoLoai:
                        Console.Write("Nhap loai muon tinh tong tuoi (Lion,Bat,Bird) : ");
                        string loai = Console.ReadLine();
                        Console.Write($"Tong tuoi theo loai {loai} la : " + ds.TinhTongTuoiTheoLoai(loai));
                        break;
                    case ThucDon.TinhTongTuoiDVBietKhongBietBay:
                        Console.Write("Tong tuoi dong vat biet bay la : " + ds.TinhTongTuoiDVBietBay());
                        Console.Write("\nTong tuoi dong vat khong biet bay la : " + ds.TinhTongTuoiDVKoBietBay());
                        break;
                    case ThucDon.ThemDVVaoViTri:
                        Console.Write("Nhap vi tri muon them : ");
                        int z=int.Parse(Console.ReadLine());
                        Console.Write("Nhap ten loai ban muon them (Lion, Bat, Bird): ");
                        string Type = Console.ReadLine();
                        Console.Write("Nhap ten cua loai: ");
                        string name2 = Console.ReadLine();
                        Console.Write("Nhap tuoi cua loai: ");
                        int age2 = int.Parse(Console.ReadLine());
                        IAnimal newAnimals;
                        switch (Type) 
                        {
                            case "Lion":
                                newAnimals = new Lion { Name = name2, Age = age2 };
                                break;
                            case "Bat":
                                newAnimals = new Bat { Name = name2, Age = age2 };
                                break;
                            case "Bird":
                                newAnimals = new Bird { Name = name2, Age = age2 };
                                break;
                            default:
                                Console.WriteLine("Khong the them loai dong vat nay !!");
                                Console.ReadKey();
                                return;                                                           
                        }
                        ds.ThemVaoViTri(z-1, newAnimals);
                        Console.WriteLine("Da them dong vat thanh cong!!\n");
                        ds.Xuat();
                        break;
                    case ThucDon.HienThiDSTangGiamTheoTenTuoi:
                        ds.HienThiDSTangGiamTenTuoi();
                        break;
                    case ThucDon.HienThiDanhSachBatBirdLion:
                        ds.HienThiDSNhomBatBirdLion();
                        break;
                    case ThucDon.HienThiDSBatBirdLionTangGiamTheoTenTuoi:
                        ds.HienThiDSNhomBirdBatLionTangTheoTen();
                        break;
                    default:
                        return;

                }
                Console.WriteLine("\nBam 1 phim de tiep tuc ");
                Console.ReadKey();
            }
        }
    }
}
