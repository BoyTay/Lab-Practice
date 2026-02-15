using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;


namespace QuanLyDanhBa
{
    internal class Program
    {
        public enum ThucDon//khai báo một enum có tên ThucDon với các giá trị được liệt kê trong ngoặc.
        {        
            NhapTuFile=1,
            Xuat,
            TimDSCacThanhPho,
            DemSoThueBaoTheoTP,
            TimTPCoNhieuThueBaoNhat,
            Them,
            TimTPCoSoTBBangX,
            Thoat
        }                       
        static void Main(string[] args)
        {
            DanhBa db = new DanhBa();
          
            //db.NhapTuFile();
            ////db.Xuat();
            //List<string> kq= db.TimDSCacThanhPho();//Dòng này khai báo một biến kq kiểu List<string> và gán cho nó kết quả của việc gọi hàm TimDSCacThanhPho. Hàm TimDSCacThanhPho được giả định là lấy danh sách tên thành phố từ cơ sở dữ liệu.
            ////foreach (var item in kq) //Dòng này bắt đầu vòng lặp foreach lặp qua từng phần tử trong danh sách kq. Biến item được sử dụng để truy cập từng phần tử trong danh sách.
            ////{ 
            ////    Console.WriteLine($"Thanh pho {item}");//Dòng này sử dụng phương thức Console.WriteLine để in ra nội dung chuỗi được định dạng. Chuỗi được định dạng bao gồm văn bản "Thanh pho " và giá trị của biến item.
            ////}
            ////foreach (var item in kq)
            ////{
            ////    Console.WriteLine(item + " co " + db.DemSoThueBaoTheoTP(item)+" so thue bao ");
            ////}
            //List<string> kq1 = db.TimTPCoNhieuThueBaoNhat();
            //foreach (var item in kq1)
            //{
            //    Console.WriteLine(item + " co so thue bao lon nhat la : " + db.DemSoThueBaoTheoTP(item));
            //}
            //Console.ReadKey();
            while (true) 
            {
                Console.Clear();
                Console.WriteLine("=============Chon chuc nang==========");
                Console.WriteLine($"Nhap {(int)ThucDon.NhapTuFile} de nhap file");
                Console.WriteLine($"Nhap {(int)ThucDon.Xuat} de xuat danh ba");
                Console.WriteLine($"Nhap {(int)ThucDon.TimDSCacThanhPho} de tim danh sach cac thanh pho");
                Console.WriteLine($"Nhap {(int)ThucDon.DemSoThueBaoTheoTP} de dem so thue bao theo thanh pho");
                Console.WriteLine($"Nhap {(int)ThucDon.TimTPCoNhieuThueBaoNhat} de tim thanh pho co nhieu thue bao nhat");
                Console.WriteLine($"Nhap {(int)ThucDon.Them}  de them 1 thue bao moi");
                Console.WriteLine($"Nhap {(int)ThucDon.TimTPCoSoTBBangX} de tim thanh pho co so thue bao bang x");
                Console.WriteLine($"Nhap {(int)ThucDon.Thoat} de thoat");
                Console.Write("Nhap 1 so de chon chuc nang : ");
                ThucDon chon=(ThucDon)int.Parse( Console.ReadLine() );
                switch (chon)
                {
                    case ThucDon.NhapTuFile:
                        db.NhapTuFile();
                        Console.WriteLine("\nNhap du lieu tu file thanh cong!!");
                        break;
                    case ThucDon.Xuat:
                        db.Xuat();
                        break;
                    case ThucDon .TimDSCacThanhPho:
                        List<string> kq = db.TimDSCacThanhPho();//Dòng này khai báo một biến kq kiểu List<string> và gán cho nó kết quả của việc gọi hàm TimDSCacThanhPho. Hàm TimDSCacThanhPho được giả định là lấy danh sách tên thành phố từ cơ sở dữ liệu.
                        foreach (var item in kq) //Dòng này bắt đầu vòng lặp foreach lặp qua từng phần tử trong danh sách kq. Biến item được sử dụng để truy cập từng phần tử trong danh sách.
                        {
                            Console.WriteLine($"Thanh pho {item}");//Dòng này sử dụng phương thức Console.WriteLine để in ra nội dung chuỗi được định dạng. Chuỗi được định dạng bao gồm văn bản "Thanh pho " và giá trị của biến item.
                        }
                        break;
                    case ThucDon.DemSoThueBaoTheoTP:
                        List<string> kq1=db.TimDSCacThanhPho();
                        foreach (var item in kq1)
                        {
                            Console.WriteLine(item + " co " + db.DemSoThueBaoTheoTP(item) + " so thue bao ");
                        }
                        break;
                    case ThucDon.TimTPCoNhieuThueBaoNhat:
                        List<string> kq2 = db.TimTPCoNhieuThueBaoNhat();
                        foreach (var item in kq2)
                        {
                            Console.WriteLine(item + " co so thue bao lon nhat la : " + db.DemSoThueBaoTheoTP(item));
                        }
                        break;
                    case ThucDon.Them:      
                        Console.WriteLine("\nNhap thong tin thue bao !!");
                        Console.Write("So CMND: ");
                        string soCMND = Console.ReadLine();
                        Console.Write("Ho va ten: ");
                        string hoTen = Console.ReadLine();
                        Console.Write("Ngay sinh (Year/Month/Day): ");
                        DateTime ngaySinh =DateTime.Parse(Console.ReadLine());
                        Console.Write("Gioi tinh: ");
                        GioiTinh gioiTinh = (GioiTinh)Enum.Parse(typeof(GioiTinh), Console.ReadLine());
                        Console.Write("So đien thoai: ");
                        string soDT = Console.ReadLine();
                        Console.Write("Đia chi: ");
                        string diaChi = Console.ReadLine();                   
                        ThueBao thueBaoMoi = new ThueBao(diaChi,gioiTinh,hoTen,ngaySinh,soDT,soCMND);
                        db.Them(thueBaoMoi);
                        Console.WriteLine("Them 1 thue bao thanh cong!!");
                        break;
                    case ThucDon.TimTPCoSoTBBangX:
                        Console.Write("Nhap so thue bao muon tim : ");
                        string x = Console.ReadLine();
                        List<string> kq3 = db.TimTPCoSoTBBangX(x);                    
                        foreach (var item in kq3)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    default:
                        return;
                }
                Console.WriteLine("\nBam 1 phim de tiep tuc ");
                Console.ReadKey ();

            }           
        }
    }
}
