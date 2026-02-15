using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Collections.Immutable;
namespace Lab1
{
    class Program
    {

        static void Main(string[] args)
        {

            int vtdt = 2;
            int gt = 2;
            int vtcc = 2;
            List<int> danhSach = new List<int>();
            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine());
            NhapTuBanPhim11(danhSach, n);
            //NhapNgauNhien12(danhSach, n);
            //NhapTuFile13(danhSach);
            //XuatRaFile15(danhSach);
            XuatRaConsole14(danhSach);
            // XuatRaFile15(danhSach);
            Console.Write("Nhap phan tu x muon dem : ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Nhap phan tu y muon kiem tra co trong ds khong : ");
            int y = int.Parse(Console.ReadLine());
            Console.Write("Nhap phan tu z muon tim vi tri : ");
            int z = int.Parse(Console.ReadLine());
            Console.Write("Nhap vao vt muon xoa phan tu : ");
            int vt = int.Parse(Console.ReadLine());

            Xuat(danhSach, n, x, gt, y, z, vtdt, vtcc, vt);
        }
        static void NhapTuBanPhim11(List<int> ds, int cd)
        {
            for (int i = 0; i < cd; i++)
            {
                Console.Write("Nhap phan tu thu {0}: ", i + 1);
                int number = int.Parse(Console.ReadLine());
                ds.Add(number);
            }

        }
        static void NhapNgauNhien12(List<int> ds, int cd)
        {

            Random r = new Random();
            for (int i = 0; i < cd; i++)
            {
                ds.Add(r.Next(10));
            }
        }
        static void XuatRaConsole14(List<int> ds)
        {
            Console.WriteLine("Danh sach mang vua nhap : ");
            foreach (int i in ds)
            {
                Console.WriteLine(i + "\t");

            }

        }
        static void NhapTuFile13(List<int> ds)
        {
            StreamReader sr = new StreamReader("a.txt");
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                ds.Add(int.Parse(s));
            }
        }
        static void XuatRaFile15(List<int> ds)
        {
            StreamWriter sw = new StreamWriter("b.txt");
            foreach (int i in ds)
                sw.WriteLine($"{i}");
            sw.Flush();
            sw.Close();
        }
        static int TongCacPhanTu21(List<int> ds, int cd)
        {
            int sum = 0;
            for (int i = 0; i < cd; i++)
            {
                sum += ds[i];

            }
            return sum;
        }
        static void Xuat(List<int> ds, int cd, int x, int gt, int y, int z, int vtdt, int vtcc, int vt)
        {

            //int sum = TongCacPhanTu21(ds, cd);
            //Console.WriteLine("Tong cac phan tu trong mang la : " + sum);
            //double tb = TrungBinhCacPhanTu22(ds);
            //Console.WriteLine("Trung binh cac phan tu trong mang la : " + tb);
            //int max = GiaTriLonNhat23(ds);
            //Console.WriteLine("Gia tri lon nhat trong mang la : " + max);
            //int min = GiaTriNhoNhat24(ds);
            //Console.WriteLine("Gia tri nho nhat trong mang la : " + min);
            //int count = SoLanXuatHienCua1GiaTri25(ds, cd);          
            //Console.WriteLine($"So lan xuat hien cua gia tri {gt} la :{count}");
            //int sumam = TongCacSoAm26(ds, cd);
            //Console.WriteLine("Tong cac phan tu am trong mang la : " + sumam);
            //int soduong = TongCacSoDuong27(ds, cd);
            //Console.WriteLine("Tong cac phan tu duong trong mang la : " + soduong);
            //int countchan=DemSoChan28(ds, cd);
            //Console.WriteLine("So luong so chan co trong mang la : " + countchan);
            //int countle = DemSoLe29(ds, cd);
            //Console.WriteLine("Soluong so le co trong mang la : " + countle);
            //int countx=DemPhanTuX210(ds, cd,x);
            //Console.WriteLine($"So lan xuat hien cua {x} trong mang la : {countx}");
            //bool ChuaY=KiemTraPhanTuX31(ds, cd,y);
            //Console.WriteLine(ChuaY ? $"Phan tu {y} co trong danh sach" : $"Phan tu {y} khong co trong danh sach ");
            //List<int> vitri=TimViTriCuaPhanTuX33(ds,cd,z);
            //Console.WriteLine($"Tat ca vi tri cua {z} trong mang la : ");
            //foreach (int vt in vitri)
            //{
            //    Console.WriteLine(vt+1);
            //}
            //int viTriDauTien = TimViTriDauTienCuaPhanTu34(ds, cd,vtdt);
            //if (viTriDauTien != -1)
            //{
            //    Console.WriteLine($"Vi tri dau tien cua phan tu {vtdt} la: {viTriDauTien+1}");
            //}
            //else
            //{
            //    Console.WriteLine($"Phan tu {vtdt} khong ton tai trong mang");
            //}
            //int viTriCuoiCung=TimViTriCuoiCungCuaPhanTu35(ds, cd,vtcc);
            //if (viTriCuoiCung != -1)
            //{
            //    Console.WriteLine($"Vi tri cuoi cung cua phan tu {vtcc} la: { viTriCuoiCung+1}");
            //}
            //else
            //{
            //    Console.WriteLine($"Phan tu {vtcc} khong ton tai trong mang");
            //}
            //List<int> positiveNumbers = TimViTriCuaCacSoDuong36(ds, cd);
            //Console.WriteLine($"Tat ca vi tri cua phan tu duong trong mang la : ");
            //foreach (int i in positiveNumbers )
            //{
            //    Console.WriteLine(i+1);
            //}
            //List<int> negativeNumbers=TimViTriCuaCacSoAm37(ds, cd);
            //Console.WriteLine($"Tat ca vi tri cua phan tu am trong mang la : ");
            //foreach (int i in negativeNumbers)
            //{
            //    Console.WriteLine(i + 1);
            //}
            //int vtmax=ViTriSoLonNhat38(ds, cd);
            //Console.WriteLine("Vi tri cua so lon nhat trong mang la : " + vtmax);
            //int vtmin=ViTriSoNhoNhat39(ds, cd);
            //Console.WriteLine("Vi tri cua so nho nhat trong mang la : " + vtmin);
            //List<int> sochan=TimTatCaSoChan310(ds,cd);
            //Console.WriteLine("Tat ca so chan trong mang la : ");
            //foreach (int i in sochan)
            //{
            //    Console.WriteLine(i);
            //}
            //List<int> sole = TimTatCaSoLe311(ds, cd);
            //Console.WriteLine("Tat ca so le trong mang la : ");
            //foreach (int i in sole)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine("Danh sach mang da duoc sap xep theo thu tu tang dan : ");
            //SapXepDSThuTuTangDan41(ds);
            //Console.WriteLine("Danh sach mang da duoc sap xep theo thu tu giam dan : ");
            //SapXepDSThuTuGiamDan42(ds);
            //Console.Write("Danh sach da duoc xoa : ");
            //XoaPhanTu51(ds, vt);
            //foreach (int i in ds)
            //{
            //    Console.Write(i + " ");
            //}
            //Console.Write("Danh sach da duoc xoa : ");
            //XoaPhanTuDauTien52(ds);
            //foreach (int i in ds) 
            //{
            //    Console.WriteLine(i);
            //}
            //Console.Write("Danh sach da duoc xoa : ");
            //XoaPhanTuCuoiCung53(ds);
            //foreach (var i in ds)
            //{
            //    Console.Write(i + " ");
            //}
            //Console.Write("Tat ca danh sach da duoc xoa!");
            //XoaTatCaDS54(ds);
            //foreach (var i in ds)
            //{
            //    Console.Write(i + " ");
            //}
            //Console.WriteLine("Tat ca so lon x la duoc xoa!");
            //XoaSoLonHonX55(ds);
            //foreach (var i in ds)
            //{
            //    Console.WriteLine(i + " ");
            //}
            //Console.WriteLine("Tat ca so duong da duoc xoa!");
            //XoaTatCaSoDuong56(ds);
            //foreach (var i in ds)
            //{
            //    Console.WriteLine(i + " ");
            //}
            //Console.WriteLine("Tat ca so chan da duoc xoa!");
            //XoaTatCaSoChan57(ds);
            //foreach (var i in ds)
            //{
            //    Console.WriteLine(i + " ");
            //}
            //Console.WriteLine("Tat ca so nguyen to da duoc xoa!");
            //XoaTatCaSoNguyenTo58(ds);
            //foreach (var i in ds)
            //{
            //    Console.WriteLine(i + " ");
            //}
            //Console.WriteLine("Them phan tu tai vt!");
            //Them1PhanTu59(ds);
            //foreach (var i in ds)
            //{
            //    Console.WriteLine(i + " ");
            //}
            //Console.WriteLine("Them phan tu dau tien!");
            //ThemPhanTuDauTien510(ds);
            //foreach (var i in ds)
            //{
            //    Console.WriteLine(i + " ");
            //}
            //Console.WriteLine("Them phan tu cuoi cung!");
            //ThemPhanTuCuoi511(ds);
            //foreach (var i in ds)
            //{
            //    Console.WriteLine(i + " ");
            //}
            //Console.WriteLine("Danh sach so nguyen da duoc them !");
            //Them1DSSoNguyen512(ds);
            //foreach (var i in ds)
            //{
            //    Console.WriteLine(i + " ");
            //}
            //Console.WriteLine("Danh sach so nguyen da duoc them vao cuoi ds !");
            //Them1DSSoNguyenCuoiDS513(ds);
            //foreach (var i in ds)
            //{
            //    Console.WriteLine(i + " ");
            //}
            //Console.WriteLine("Danh sach so nguyen da duoc them vao dau ds !");
            //Them1DSSoNguyenDauDS514(ds);
            //foreach (var i in ds)
            //{
            //    Console.WriteLine(i + " ");
            //}
            //Console.WriteLine("Cac phan tu da duoc dao nguoc !");
            //DaoNguocThuTu515(ds);
            //foreach (var i in ds)
            //{
            //    Console.WriteLine(i + " ");
            //}
            //Console.WriteLine("Cac phan tu da duoc dao lon trong danh sach ngau ngien !");
            //DaoLonCacViTriPhanTuNgauNhien516(ds);
            //foreach (var i in ds)
            //{
            //    Console.WriteLine(i + " ");
            //}
            Console.WriteLine("Thay the phan tu x thanh phan tu y !");
            ThayThePhanTu517(ds);
            foreach (var i in ds)
            {
                Console.WriteLine(i + " ");
            }

        }
        //static double TrungBinhCacPhanTu22(List<int> ds)
        //{
        //    return ds.Average();
        //}
        //static int GiaTriLonNhat23(List<int> ds)
        //{
        //    return ds.Max();
        //}
        //static int GiaTriNhoNhat24(List<int> ds)
        //{
        //    return ds.Min();
        //}
        //static int SoLanXuatHienCua1GiaTri25(List<int> ds, int cd)
        //{
        //    int count = 0;
        //    int gt = 2;
        //    for (int i = 0; i < cd; i++)
        //    {
        //        if (ds[i] == gt)
        //        {
        //            count++;
        //        }
        //    }
        //    return count;
        //}
        //static int TongCacSoAm26(List<int> ds, int cd)
        //{
        //    int sum = 0;
        //    for (int i = 0; i < cd; i++)
        //    {
        //        if (ds[i] < 0)
        //            sum += ds[i];
        //    }
        //    return sum;
        //}
        //static int TongCacSoDuong27(List<int> ds, int cd)
        //{
        //    int sum = 0;
        //    for (int i = 0; i < cd; i++)
        //    {
        //        if (ds[i] > 0)
        //        {
        //            sum += ds[i];
        //        }
        //    }
        //    return sum;
        //}
        //static int DemSoChan28(List<int> ds, int cd)
        //{
        //    int count = 0;
        //    for (int i = 0; i < cd; i++)
        //    {
        //        if (ds[i] % 2 == 0)
        //        {
        //            count++;
        //        }
        //    }
        //    return count;
        //}
        //static int DemSoLe29(List<int> ds, int cd)
        //{
        //    int count = 0;
        //    for (int i = 0; i < cd; i++)
        //    {
        //        if (ds[i] % 2 == 1)
        //        {
        //            count++;
        //        }
        //    }
        //    return count;
        //}
        //static int DemPhanTuX210(List<int> ds, int cd,int x)
        //{
        //    int count = 0;
        //    for (int i = 0; i < cd; i++)
        //    {
        //        if (ds[i] == x)
        //        {
        //            count++;
        //        }
        //    }
        //    return count;
        //}
        //static bool KiemTraPhanTuX31(List<int> ds, int cd,int y)
        //{
        //    for (int i = 0; i < cd; i++)
        //    {
        //        if (ds[i]==y)
        //            return true;
        //    }
        //    return false;
        //}
        // static List<int> TimViTriCuaPhanTuX33(List<int>ds,int cd,int z) 
        //{
        //    List<int> viTri = new List<int>();
        //    for (int i = 0; i < cd; i++)
        //    {
        //        if (ds[i]==z) 
        //        {
        //            viTri.Add(i);
        //        }
        //    }
        //    return viTri;
        //}
        //static int TimViTriDauTienCuaPhanTu34(List<int>ds,int cd,int vtdt)
        //{

        //    return ds.IndexOf(vtdt);
        //}
        //static int TimViTriCuoiCungCuaPhanTu35(List<int>ds, int cd,int vtcc)
        //{
        //    return ds.LastIndexOf(vtcc);
        //}
        //static List<int> TimViTriCuaCacSoDuong36(List<int>ds,int cd)
        //{
        //    List<int> positiveNumbers = new List<int>();
        //    for(int i = 0;i < cd;i++)
        //    {
        //        if (ds[i]>0)
        //        {
        //            positiveNumbers.Add(i);
        //        }
        //    }
        //    return positiveNumbers;

        //}
        //static List<int> TimViTriCuaCacSoAm37(List<int> ds, int cd)
        //{
        //    List<int> negativeNumbers = new List<int>();
        //    for (int i = 0; i < cd; i++)
        //    {
        //        if (ds[i] < 0)
        //        {
        //            negativeNumbers.Add(i);
        //        }
        //    }
        //    return negativeNumbers;
        //}
        //static int ViTriSoLonNhat38(List<int>ds, int cd) 
        //{
        //    int max=0;
        //    int vt = 0;
        //    for (int i = 0; i < cd; i++)
        //    {
        //        if (ds[i] > max)
        //        {
        //            max = ds[i];
        //            vt = i;

        //        }
        //    }
        //    return vt+1;
        // }
        //static int ViTriSoNhoNhat39(List<int> ds, int cd)
        //{
        //    int min = ds[0];
        //    int vt = 0;
        //    for (int i = 0; i < cd; i++)
        //    {
        //        if (ds[i] < min)
        //        {
        //            min = ds[i];
        //            vt = i;

        //        }
        //    }
        //    return vt + 1;
        // }
        //static List<int> TimTatCaSoChan310(List<int>ds,int cd)
        //{
        //   List<int> sochan=new List<int>();
        //    for (int i = 0; i < cd; i++)
        //    {
        //        if (ds[i]%2==0)
        //        {
        //            sochan.Add(ds[i]);
        //        }
        //    }
        //    return sochan;
        //}
        //static List<int> TimTatCaSoLe311(List<int> ds, int cd)
        //{
        //    List<int> sole = new List<int>();
        //    for (int i = 0; i < cd; i++)
        //    {
        //        if (ds[i] % 2 == 1)
        //        {
        //            sole.Add(ds[i]);
        //        }
        //    }
        //    return sole;
        //}
        static void SapXepDSThuTuTangDan41(List<int> ds)
        {
            ds.Sort();
            foreach (int i in ds)
            {
                Console.WriteLine(i);
            }
        }
        static void SapXepDSThuTuGiamDan42(List<int> ds)
        {
            var DSSapXep = ds.OrderByDescending(x => x);
            foreach (int i in DSSapXep)
            {
                Console.WriteLine(i);
            }
        }
        static void XoaPhanTu51(List<int> ds, int vt)
        {
            ds.RemoveAt(vt - 1);
        }
        static void XoaPhanTuDauTien52(List<int> ds)
        {
            ds.RemoveAt(0);
        }
        static void XoaPhanTuCuoiCung53(List<int> ds)
        {
            ds.RemoveAt(ds.Count - 1);
        }
        static void XoaTatCaDS54(List<int> ds)
        {
            ds.Clear();
        }
        static void XoaSoLonHonX55(List<int> ds)
        {
            int x = 5;
            ds.RemoveAll(so => so > x);
        }
        static void XoaTatCaSoDuong56(List<int> ds)
        {
            ds.RemoveAll(so => so > 0);
        }
        static void XoaTatCaSoChan57(List<int> ds)
        {
            ds.RemoveAll(so => so % 2 == 0);
        }
        static bool KiemTraSNT(int so)
        {
            if (so <= 1)
                return false;
            for (int i = 2; i <= Math.Sqrt(so); i++)
            {
                if (so % i == 0)
                    return false;
            }
            return true;
        }
        static void XoaTatCaSoNguyenTo58(List<int> ds)
        {
            ds.RemoveAll(so => KiemTraSNT(so));
        }
        static void Them1PhanTu59(List<int> ds)
        {
            int vt = 2;
            int phanTuMoi = 10;
            ds.Insert(vt - 1, phanTuMoi);
        }
        static void ThemPhanTuDauTien510(List<int> ds)
        {
            int phanTuMoi = 10;
            ds.Insert(0, phanTuMoi);
        }
        static void ThemPhanTuCuoi511(List<int> ds)
        {
            int phanTuMoi = 10;
            ds.Insert(ds.Count, phanTuMoi);
        }
        static void Them1DSSoNguyen512(List<int> ds)
        {
            List<int> danhSach1 = new List<int>() { 6, 7, 8, 9, 10 };

            int vt = 2;

            ds.InsertRange(vt - 1, danhSach1);
        }
        static void Them1DSSoNguyenCuoiDS513(List<int> ds)
        {
            List<int> danhSach1 = new List<int>() { 6, 7, 8, 9, 10 };
            ds.InsertRange(ds.Count, danhSach1);
        }
        static void Them1DSSoNguyenDauDS514(List<int> ds)
        {
            List<int> danhSach1 = new List<int>() { 6, 7, 8, 9, 10 };
            ds.InsertRange(0, danhSach1);
        }
        static void DaoNguocThuTu515(List<int> ds)
        {
            ds.Reverse();
        }
        static void DaoLonCacViTriPhanTuNgauNhien516(List<int> ds)
        {
            Random random = new Random();
            for (int i = 0; i < ds.Count; i++)
            {
                int viTriNgauNhien = random.Next(ds.Count);
                int temp = ds[i];
                ds[i] = ds[viTriNgauNhien];
                ds[viTriNgauNhien] = temp;
            }

        }
        static void ThayThePhanTu517(List<int> ds)
        {
            int oldValue = 10;
            int newValue = 20;
            int index = ds.IndexOf(oldValue);
            if (index != -1)
            {
                ds[index] = newValue;
            }

        }
    }
}

