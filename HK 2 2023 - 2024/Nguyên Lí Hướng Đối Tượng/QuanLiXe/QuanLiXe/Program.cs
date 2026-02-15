using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiXe
{
    internal class Program
    {
        public enum ThucDon
        {
            DocFile=1,
            Them,
            Xuat,
            TangTocGiamToc,
            DongCua,
            DemSLTheoLoaiKetHop,
            TimDSCar,
            TimDSMotorcycle,
            TimDSCarHoacMotorcycle,
            TimDSCarVaMotorcycle,
            TimDSTheoTen,
            TimDSTheoSoChoNgoi,
            TimDSTheoTocDo,
            TimDSTheoTenSoChoNgoi,
            TimDSTheoTenTocDo,
            TimDSTheoSoChoNgoiTocDo,
            TimDSTheoTenSoChoNgoiTocDo,
            TimXeCoTenDaiNhat,
            TimXeCoTenNganNhat,
            TimXeCoSoChoNgoiLonNhat,
            TimXeCoSoChoNgoiItNhat,
            TimXeCoTocDoLonNhat,
            TimXeCoTocDoNhoNhat,
        }
        
        
        public static void Main(string[] args)
        {
            QuanLiXe ds = new QuanLiXe();
            List<IVehicle> dsXe = new List<IVehicle>();
            while (true) 
            {
              Console.Clear();
                Console.WriteLine("========Chon chuc nang=========");
                Console.WriteLine($"Nhap {(int)ThucDon.DocFile} de nhap tu file");
                Console.WriteLine($"Nhap {(int)ThucDon.Them} de them xe");
                Console.WriteLine($"Nhap {(int)ThucDon.Xuat} de xuat");
                Console.WriteLine($"Nhap {(int)ThucDon.TangTocGiamToc} de tang toc giam toc");
                Console.WriteLine($"Nhap {(int)ThucDon.DongCua} de dong cua ");
                Console.WriteLine($"Nhap {(int)ThucDon.DemSLTheoLoaiKetHop} de dem so luong theo loai ket hop");
                Console.WriteLine($"Nhap {(int)ThucDon.TimDSCar} de tim Car");
                Console.WriteLine($"Nhap {(int)ThucDon.TimDSMotorcycle} de tim Motorcycle");
                Console.WriteLine($"Nhap {(int)ThucDon.TimDSCarHoacMotorcycle} de tim Car hoac Motorcycle");
                Console.WriteLine($"Nhap {(int)ThucDon.TimDSCarVaMotorcycle} de tim Car va Motorcycle");
                Console.WriteLine($"Nhap {(int)ThucDon.TimDSTheoTen} de tim xe theo ten");
                Console.WriteLine($"Nhap {(int)ThucDon.TimDSTheoSoChoNgoi} de tim xe theo so cho ngoi");
                Console.WriteLine($"Nhap {(int)ThucDon.TimDSTheoTocDo} de tim xe theo toc do");
                Console.WriteLine($"Nhap {(int)ThucDon.TimDSTheoTenSoChoNgoi} de tim xe theo ten , so cho ngoi");
                Console.WriteLine($"Nhap {(int)ThucDon.TimDSTheoTenTocDo} de tim xe theo ten , toc do");
                Console.WriteLine($"Nhap {(int)ThucDon.TimDSTheoSoChoNgoiTocDo} de tim xe theo so cho ngoi , toc do");
                Console.WriteLine($"Nhap {(int)ThucDon.TimDSTheoTenSoChoNgoiTocDo} de tim xe theo ten , so cho ngoi , toc do");
                Console.WriteLine($"Nhap {(int)ThucDon.TimXeCoTenDaiNhat} de tim xe co ten dai nhat");
                Console.WriteLine($"Nhap {(int)ThucDon.TimXeCoTenNganNhat} de tim xe co ten ngan nhat");
                Console.WriteLine($"Nhap {(int)ThucDon.TimXeCoSoChoNgoiLonNhat} de tim xe co so cho ngoi lon nhat");
                Console.WriteLine($"Nhap {(int)ThucDon.TimXeCoSoChoNgoiItNhat} de tim xe co so cho ngoi it nhat");
                Console.WriteLine($"Nhap {(int)ThucDon.TimXeCoTocDoLonNhat} de tim xe co toc do lon nhat");
                Console.WriteLine($"Nhap {(int)ThucDon.TimXeCoTocDoNhoNhat} de tim xe co toc do nho nhat");

                Console.Write("\nNhap 1 so de chon menu : ");

                ThucDon chon = (ThucDon)int.Parse(Console.ReadLine());
                switch (chon) 
                {
                   case ThucDon.DocFile:
                        ds.DocFile("data.txt");
                        Console.WriteLine("Nhap tu file thanh cong!!");
                        break;
                        case ThucDon.Them:
                        Console.Write("Nhap loai xe ban muon them (Car,Motorcycle) : ");
                        string vehicleType=Console.ReadLine();
                        Console.Write("Nhap ten xe  : ");
                        string ten =Console.ReadLine();
                        Console.Write("Nhap toc do xe :");
                        int tocDo=int.Parse(Console.ReadLine());
                        IVehicle newVehicle;
                        switch (vehicleType.ToLower()) 
                        {
                            case "car":
                                newVehicle = new Car { Ten = ten, TocDo = tocDo };
                                break;
                            case "motorcycle":
                                newVehicle = new Motorcycle { Ten = ten, TocDo = tocDo };
                                break;
                            default:
                                Console.WriteLine("Khong co loai xe nay trong danh sach.Vui long thu lai");
                                Console.ReadKey();
                                return;
                        }
                        ds.Them(newVehicle);
                        Console.WriteLine("Da them xe thanh cong !!");
                        break;
                        case ThucDon.Xuat:
                        ds.Xuat();
                        break;
                    case ThucDon.TangTocGiamToc:
                        Motorcycle xeMay = new Motorcycle();
                        xeMay.TangToc();
                        xeMay.GiamToc();
                        break;
                    case ThucDon.DongCua:
                        Car xeHoi = new Car();
                        xeHoi.SoChoNgoi = 8; 
                        xeHoi.DongCua();
                        Car xeHoi2 = new Car();
                        xeHoi2.SoChoNgoi = 5; 
                        xeHoi2.DongCua();
                        break;
                    case ThucDon.DemSLTheoLoaiKetHop:
                        //Console.Write("\nSo luong phuong tien Car la : " + ds.DemSLCar());
                        //Console.Write("\nSo luong phuong tien Motorcycle la : " + ds.DemSLMotorcycle());
                        //Console.Write("\nSo luong phuong Car hoac Motorcycle la : " + ds.DemSLCarHoacMotorcycle());
                        //Console.Write("\nSo luong phuong tien Car va Motorcycle la : " + ds.DemSLCarVaMotorcycle());
                        //Console.Write("\nNhap ten xe can dem : ");
                        //string ten1 = Console.ReadLine();
                        //Console.Write($"\nSo luong xe theo ten {ten1} la : "+ds.DemSLTheoTen(ten1));
                        //Console.Write("\nNhap so cho ngoi can dem : ");
                        //int soChoNgoi1 = int.Parse(Console.ReadLine());
                        //Console.Write($"\nSo luong xe theo so cho ngoi {soChoNgoi1} la : " + ds.DemSoChoNgoi(soChoNgoi1));
                        //Console.Write("\nNhap toc do xe can dem : ");
                        //int tocDo1 = int.Parse(Console.ReadLine());
                        //Console.Write($"\nSo luong xe theo toc do {tocDo1} km/h la : " + ds.DemSLTheoTocDo(tocDo1));
                        //Console.WriteLine("Dem so luong xe theo ten va so cho ngoi!!");
                        //Console.Write("\nNhap ten xe can dem : ");
                        //string ten2 = Console.ReadLine();				
                        //Console.Write("\nNhap so cho ngoi can dem : ");
                        //int soChoNgoi2 = int.Parse(Console.ReadLine());
                        //Console.Write($"\nSo luong xe theo ten {ten2} va so cho ngoi {soChoNgoi2} la : " + ds.DemSLTheoTenSoChoNgoi(ten2, soChoNgoi2));
                        //Console.WriteLine("Dem so luong xe theo ten va toc do !!");
                        //Console.Write("\nNhap ten xe can dem : ");
                        //string ten3 = Console.ReadLine();
                        //Console.Write("\nNhap toc do can dem : ");
                        //int tocDo2 = int.Parse(Console.ReadLine());
                        //Console.Write($"\nSo luong xe theo ten {ten3} va toc do {tocDo2} km/h la : " + ds.DemSLTheoTenTocDo(ten3, tocDo2));
                        //Console.WriteLine("Dem so luong theo so cho ngoi va toc do !!");
                        //Console.Write("\nNhap so cho ngoi can dem : ");
                        //int soChoNgoi3 = int.Parse(Console.ReadLine());
                        //Console.Write("\nNhap toc do can dem : ");
                        //int tocDo3 = int.Parse(Console.ReadLine());
                        //Console.Write($"\nSo luong xe theo so cho ngoi {soChoNgoi3} va toc do {tocDo3} km/h la : " + ds.DemSLTheoSoChoNgoiTocDo(soChoNgoi3, tocDo3));
                        //Console.WriteLine("Dem so luong theo ten,  so cho ngoi va toc do !!");
                        //Console.Write("\nNhap ten xe can dem : ");
                        //string ten4 = Console.ReadLine();
                        //Console.Write("\nNhap so cho ngoi can dem : ");
                        //int soChoNgoi4 = int.Parse(Console.ReadLine());
                        //Console.Write("\nNhap toc do can dem : ");
                        //int tocDo4 = int.Parse(Console.ReadLine());
                        //Console.Write($"\nSo luong xe theo ten {ten4} , so cho ngoi {soChoNgoi4} va toc do {tocDo4} km/h la : " +ds.DemSLTheoTenSoChoNgoiTocDo(ten4,tocDo4,soChoNgoi4));
                        //Console.WriteLine("So xe co ten dai nhat : "+ds.DemXeTenDaiNhat());
                        //Console.WriteLine("So xe co ten ngan nhat : " + ds.DemXeTenNganNhat());
                        //Console.WriteLine("So xe co cho ngoi lon nhat : " + ds.DemXeSoChoNgoiLonNhat());
                        //Console.WriteLine("So xe co cho ngoi it nhat : " + ds.DemXeSoChoNgoiItNhat());
                        Console.WriteLine("So xe co toc do lon nhat : " + ds.DemXeTocDoLonNhat());
                        Console.WriteLine("So xe co toc do nho nhat : " + ds.DemXeTocDoNhoNhat());
                        break;
                    case ThucDon.TimDSCar:
                        Console.WriteLine("\nDanh sach cac xe ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("==============================");
                        Console.WriteLine("\nDanh sach xe Car !!");
                        dsXe = ds.TimDSCar();
                        ds.DanhSachList(dsXe);
                        break;
                    case ThucDon.TimDSMotorcycle:
                        Console.WriteLine("\nDanh sach cac xe ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("==============================");
                        Console.WriteLine("\nDanh sach xe Motorcycle !!");
                        dsXe = ds.TimDSMotorcycle();
                        ds.DanhSachList(dsXe);
                        break;
                    case ThucDon.TimDSCarHoacMotorcycle:
                        Console.WriteLine("\nDanh sach cac xe ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("==============================");
                        Console.WriteLine("\nDanh sach xe Car hoac Motorcycle !!");
                        dsXe = ds.TimDSCarHoacMotorcycle();
                        ds.DanhSachList(dsXe);
                        break;
                    case ThucDon.TimDSCarVaMotorcycle:
                        Console.WriteLine("\nDanh sach cac xe ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("==============================");
                        Console.WriteLine("\nDanh sach xe Car va Motorcycle !!");
                        dsXe = ds.TimDSCarVaMotorcycle();
                        ds.DanhSachList(dsXe);
                        break;
                    case ThucDon.TimDSTheoTen:
                        Console.WriteLine("\nDanh sach cac xe ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("==============================");                   
                        Console.Write("\nNhap ten xe can tim : ");
                        string tenXe = Console.ReadLine();
                        Console.WriteLine($"\nDanh sach xe theo ten {tenXe} !!\n ");                    
                        dsXe = ds.TimDSTheoTen(tenXe);
                        ds.DanhSachList(dsXe);
                        break;
                    case ThucDon.TimDSTheoSoChoNgoi:
                        Console.WriteLine("\nDanh sach cac xe ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("==============================");
                        Console.Write("\nNhap so cho ngoi can tim : ");
                        int soChoNgoi = int.Parse(Console.ReadLine());
                        Console.WriteLine($"\nDanh sach xe theo so cho ngoi {soChoNgoi} !!\n");
                        dsXe = ds.TimDSTheoSoChoNgoi(soChoNgoi);
                        ds.DanhSachList(dsXe);
                        break;
                    case ThucDon.TimDSTheoTocDo:
                        Console.WriteLine("\nDanh sach cac xe ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("==============================");
                        Console.Write("\nNhap  toc do can tim : ");
                        int tocDon=int.Parse(Console.ReadLine());
                        Console.WriteLine($"\nDanh sach xe theo toc do {tocDon} km/h !!\n");
                        dsXe=ds.TimDSTheoTocDo(tocDon);
                        ds.DanhSachList(dsXe);
                        break;
                    case ThucDon.TimDSTheoTenSoChoNgoi:
                        Console.WriteLine("\nDanh sach cac xe ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("==============================");
                        Console.Write("\nNhap ten xe can tim : ");
                        string tenXen=Console.ReadLine();
                        Console.Write("\nNhap so cho ngoi : ");
                        int soChoNgoin=int.Parse(Console.ReadLine());
                        Console.WriteLine($"\nDanh sach xe theo ten xe {tenXen} va so cho ngoi {soChoNgoin} !!\n");
                        dsXe=ds.TimDSTheoTenSoChoNgoi(tenXen,soChoNgoin);
                        ds.DanhSachList(dsXe);
                        break;
                    case ThucDon.TimDSTheoTenTocDo:
                        Console.WriteLine("\nDanh sach cac xe ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("==============================");
                        Console.Write("\nNhap ten xe can tim : ");
                        string tenXem = Console.ReadLine();
                        Console.Write("\nNhap toc do km/h : ");
                        int tocDom = int.Parse(Console.ReadLine());
                        Console.WriteLine($"\nDanh sach xe theo ten xe {tenXem} va toc do {tocDom} km/h !!\n");
                        dsXe = ds.TimDSTheoTenTocDo(tenXem,tocDom);
                        ds.DanhSachList(dsXe);
                        break;
                    case ThucDon.TimDSTheoSoChoNgoiTocDo:
                        Console.WriteLine("\nDanh sach cac xe ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("==============================");
                        Console.Write("\nNhap so cho ngoi can tim : ");
                        int soChoNgoix=int.Parse(Console.ReadLine());
                        Console.Write("\nNhap toc do km/h : ");
                        int tocDox=int.Parse(Console.ReadLine());
                        Console.WriteLine($"\nDanh sach xe theo so cho ngoi {soChoNgoix} va toc do {tocDox} km/h !!\n");
                        dsXe=ds.TimDSTheoSoChoNgoiTocDo(soChoNgoix,tocDox);
                        ds.DanhSachList(dsXe);
                        break;
                    case ThucDon.TimDSTheoTenSoChoNgoiTocDo:
                        Console.WriteLine("\nDanh sach cac xe ban dau !!");
                        ds.Xuat();
                        Console.WriteLine("==============================");
                        Console.Write("\nNhap ten xe can tim : ");
                        string tenXey = Console.ReadLine();
                        Console.Write("\nNhap so cho ngoi can tim : ");
                        int soChoNgoiy = int.Parse(Console.ReadLine());
                        Console.Write("\nNhap toc do km/h : ");
                        int tocDoy = int.Parse(Console.ReadLine());
                        Console.WriteLine($"\nDanh sach xe theo ten xe {tenXey} , so cho ngoi {soChoNgoiy} va toc do {tocDoy} km/h !!\n");
                        dsXe = ds.TimDSTheoTenSoChoNgoiTocDo(tenXey, soChoNgoiy, tocDoy);
                        ds.DanhSachList(dsXe);
                        break;
                    case ThucDon.TimXeCoTenDaiNhat:
                        Console.WriteLine("Xe co ten dai nhat !! \n");
                        dsXe = ds.TimXeCoTenDaiNhat();
                        ds.DanhSachList(dsXe);
                        break;
                    case ThucDon.TimXeCoTenNganNhat:
                        Console.WriteLine("Xe co ten ngan nhat !!\n ");
                        dsXe=ds.TimXeCoTenNganNhat();
                        ds.DanhSachList(dsXe);
                        break;
                        case ThucDon.TimXeCoSoChoNgoiLonNhat:
                        Console.WriteLine("Xe co so cho ngoi lon nhat !!\n ");
                        dsXe=ds.TimXeCoSoChoNgoiLonNhat();
                        ds.DanhSachList(dsXe);
                        break;
                        case ThucDon.TimXeCoSoChoNgoiItNhat:
                        Console.WriteLine("Xe co so cho ngoi it nhat !!\n ");
                        dsXe=ds.TimXeCoSoChoNgoiItNhat();
                        ds.DanhSachList(dsXe);
                        break;
                    case ThucDon.TimXeCoTocDoLonNhat:
                        Console.WriteLine("Xe co toc do lon nhat !!\n ");
                        dsXe=ds.TimXeCoTocDoLonNhat();
                        ds.DanhSachList(dsXe);
                        break;
                    case ThucDon.TimXeCoTocDoNhoNhat:
                        Console.WriteLine("Xe co toc do nho nhat !!\n ");
                        dsXe=ds.TimXeCoTocDoNhoNhat();
                        ds.DanhSachList(dsXe);
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
