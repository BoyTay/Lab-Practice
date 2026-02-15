using System;

namespace BT1_QuanLiThuVien
{
    class Program
    {
        static void Main(string[] args)
        {
            ChiNhanh cn1 = new ChiNhanh("CN01", "Thu vien Ha Noi", "1 Đinh Le");
            ChiNhanh cn2 = new ChiNhanh("CN02", "Thu vien TP.HCM", "250 Nguyen Đinh Chieu");
            ChiNhanh cn3 = new ChiNhanh("CN03", "Thu vien Đa Nang", "45 ong Ich Khiem");
            ChiNhanh cn4 = new ChiNhanh("CN04", "Thu vien Can Tho", "1A Tran Hung Đao");
            ChiNhanh cn5 = new ChiNhanh("CN05", "Thu vien Hue", "6 Le Loi");
            Sach sach1 = new Sach("S01", "C++ Primer", "Nha xuat ban Giao duc", "Bjarne Stroustrup");
            Sach sach2 = new Sach("S02", "Java: The Complete Reference", "Herbert Schildt", "Kathy Sierra");
            Sach sach3 = new Sach("S03", "C# in Depth", "Jon Skeet", "Anthony van der Hoeven");
            Sach sach4 = new Sach("S04", "Head First Python", "Paul Barry", "Kathy Sierra");
            Sach sach5 = new Sach("S05", "Think Like a Programmer", "V. Anton Spraul", "Scott E. Fahlman");
            NhaXuatBan nxb1 = new NhaXuatBan("Nha xuat ban Giao dục", "175 Tay Son", "024-3869-3245");
            NhaXuatBan nxb2 = new NhaXuatBan("Nha xuat ban McGraw-Hill", "1221 Avenue of the Americas, New York, NY 10020", "1-212-512-2000");
            NhaXuatBan nxb3 = new NhaXuatBan("Nha xuat ban O'Reilly", "1005 Gravenstein Highway North, Sebastopol, CA 95472", "1-800-998-9938");
            NhaXuatBan nxb4 = new NhaXuatBan("Nha xuat ban Pearson", "One Lake Street, Upper Saddle River, NJ 07458", "1-800-848-6777");
            NhaXuatBan nxb5 = new NhaXuatBan("Nha xuat ban Addison-Wesley", "75 Arlington Street, Suite 300, Boston, MA 02116", "1-800-624-0023");
            BanSaoSach bss1 = new BanSaoSach("S01", 5);
            BanSaoSach bss2 = new BanSaoSach("S02", 3);
            BanSaoSach bss3 = new BanSaoSach("S03", 2);
            BanSaoSach bss4 = new BanSaoSach("S04", 4);
            BanSaoSach bss5 = new BanSaoSach("S05", 1);
            NguoiMuon nm1 = new NguoiMuon("NM01", "Nguyen Van A", "123 Nguyen Trai", "0912345678");
            NguoiMuon nm2 = new NguoiMuon("NM02", "Tran Thi B", "456 Hai Ba Trung", "0987654321");
            NguoiMuon nm3 = new NguoiMuon("NM03", "Le Van C", "789 Xa Đan", "0123456789");
            NguoiMuon nm4 = new NguoiMuon("NM04", "Pham Thi D", "1011 Ba Trieu", "0908765432");
            NguoiMuon nm5 = new NguoiMuon("NM05", "Đang Van E", "1213 Ly Thai To", "0890123456");
            ThongTinMuon tm1 = new ThongTinMuon("NM01", "S01", new DateTime(2024, 3, 1), new DateTime(2024, 3, 11));
            ThongTinMuon tm2 = new ThongTinMuon("NM02", "S02", new DateTime(2024, 3, 2), new DateTime(2024, 3, 12));
            ThongTinMuon tm3 = new ThongTinMuon("NM03", "S03", new DateTime(2024, 3, 3), new DateTime(2024, 3, 13));
            ThongTinMuon tm4 = new ThongTinMuon("NM04", "S04", new DateTime(2024, 3, 4), new DateTime(2024, 3, 14));
            ThongTinMuon tm5 = new ThongTinMuon("NM05", "S05", new DateTime(2024, 3, 5), new DateTime(2024, 3, 15));
            
            Console.WriteLine("Danh sach cac chi nhanh : ");
            Console.WriteLine(cn1);
            Console.WriteLine();
            Console.WriteLine(cn2);
            Console.WriteLine();
            Console.WriteLine(cn3);
            Console.WriteLine();
            Console.WriteLine(cn4);
            Console.WriteLine();
            Console.WriteLine(cn5);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Danh sach cac sach : ");
            Console.WriteLine(sach1);
            Console.WriteLine();
            Console.WriteLine(sach2);
            Console.WriteLine();
            Console.WriteLine(sach3);
            Console.WriteLine();
            Console.WriteLine(sach4);
            Console.WriteLine();
            Console.WriteLine(sach5);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Danh sach cac nha xuat ban : ");
            Console.WriteLine(nxb1);
            Console.WriteLine();
            Console.WriteLine(nxb2);
            Console.WriteLine();
            Console.WriteLine(nxb3);
            Console.WriteLine();
            Console.WriteLine(nxb4);
            Console.WriteLine();
            Console.WriteLine(nxb5);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Danh sach cac ban sao sach : ");
            Console.WriteLine(bss1);
            Console.WriteLine();
            Console.WriteLine(bss2);
            Console.WriteLine();
            Console.WriteLine(bss3);
            Console.WriteLine();
            Console.WriteLine(bss4);
            Console.WriteLine();
            Console.WriteLine(bss5);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Danh sach cac nguoi muon : ");
            Console.WriteLine(nm1);
            Console.WriteLine();
            Console.WriteLine(nm2);
            Console.WriteLine();
            Console.WriteLine(nm3);
            Console.WriteLine();
            Console.WriteLine(nm4);
            Console.WriteLine();
            Console.WriteLine(nm5);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Danh sach cac thong tin muon : ");
            Console.WriteLine(tm1);
            Console.WriteLine();
            Console.WriteLine(tm2);
            Console.WriteLine();
            Console.WriteLine(tm3);
            Console.WriteLine();
            Console.WriteLine(tm4);
            Console.WriteLine();
            Console.WriteLine(tm5);

        }
    }
}
