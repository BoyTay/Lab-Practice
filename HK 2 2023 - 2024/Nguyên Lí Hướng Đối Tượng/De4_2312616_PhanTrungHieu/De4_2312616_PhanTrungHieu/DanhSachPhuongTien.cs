using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace De4_2312616_PhanTrungHieu
{
    public enum Loai
    {
        Car,
        Ship,
        Submarine,
        Seaplane,
    }
    public enum Selector
    {
        Ten,
        Hang,
        TocDo

    }
    public class DanhSachPhuongTien
    {
        public Loai LoaiThuocTinh { get; set; }
        public Selector ThuocTinh { get; set; }
        List<Vehicle> collection = new List<Vehicle>();
        Vehicle vehicle = null;
        public void Them(Vehicle vehicle) => collection.Add(vehicle);
        public void DocFile(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            string t;
            while ((t = sr.ReadLine()) != null)
            {
                string[] s = t.Split(',');
                if (s[0] == "Car")
                    vehicle = new Car(s[0], s[1], s[2], float.Parse(s[3]), int.Parse(s[4]));
                else if (s[0] == "Seaplane")
                    vehicle = new Seaplane(s[0], s[1], s[2], float.Parse(s[3]), int.Parse(s[4]), int.Parse(s[5]), float.Parse(s[6]), int.Parse(s[7]), int.Parse(s[8]));
                else if (s[0] == "Ship")
                    vehicle = new Ship(s[0], s[1], s[2], float.Parse(s[3]), int.Parse(s[4]), int.Parse(s[5]));
                else if (s[0] == "Submarine")
                    vehicle = new Submarine(s[0], s[1], s[2], float.Parse(s[3]), int.Parse(s[4]), int.Parse(s[4]), float.Parse(s[5]));
                collection.Add(vehicle);
            }
        }
        public void Xuat()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(new string('-', 100));
            sb.AppendLine($"{"Loai",-15} {"Ten",-16}{"Hang",-20} {"Toc Do",-8}{"NhienLieu",-11}{"Buom",-10}{"DoSau&Cao",-12}{"PhanLuc",-10} {"Canh",-10}");
            sb.AppendLine(new string('-', 100));
            foreach (var i in collection)
            {
                sb.AppendLine(i.ToString());
            }
            return sb.ToString();
        }

        public DanhSachPhuongTien TimLoaiPT()
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var i in collection)
            {
                switch (LoaiThuocTinh)
                {
                    case Loai.Car:
                        if (i is Car) kq.Them(i);
                        break;
                    case Loai.Ship:
                        if (i is Ship) kq.Them(i);
                        break;
                    case Loai.Submarine:
                        if (i is Submarine) kq.Them(i);
                        break;
                    case Loai.Seaplane:
                        if (i is Seaplane) kq.Them(i);
                        break;
                }
            }
            return kq;
        }

        public DanhSachPhuongTien SapXepGiam(string tt)
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                {
                    var laygiatri = collection[i].GetType().GetProperty(tt);
                    IComparable va1 = laygiatri.GetValue(collection[i]) as IComparable;
                    IComparable va2 = laygiatri.GetValue(collection[j]) as IComparable;
                    if (va1.CompareTo(va2) < 0) Swap(i, j);

                }
            return this;
        }

        public void Swap(int i, int j)
        {
            Vehicle c = collection[i];
            collection[i] = collection[j];
            collection[j] = c;
        }

        public DanhSachPhuongTien SapXepTang(string tt)
        {
            for (int i = 0; i < collection.Count - 1; i++)
                for (int j = i + 1; j < collection.Count; j++)
                {
                    var laygiatri = collection[i].GetType().GetProperty(tt);
                    IComparable va1 = laygiatri.GetValue(collection[i]) as IComparable;
                    IComparable va2 = laygiatri.GetValue(collection[j]) as IComparable;
                    if (va1.CompareTo(va2) > 0) Swap(i, j);
                }
            return this;
        }

        public DanhSachPhuongTien CapNhat(int vt, object needed)
        {
            Vehicle vehicle = collection[vt];
            switch (ThuocTinh)
            {
                case Selector.Ten:
                    vehicle.Ten.Equals((string)needed);
                    break;
                case Selector.Hang:
                    vehicle.Hang.Equals((string)needed);
                    break;
                case Selector.TocDo:
                    vehicle.TocDo.Equals((int)needed);
                    break;
            }
            return this;
        }

        public DanhSachPhuongTien TimKiem(object x)
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var i in collection)
                switch (ThuocTinh)
                {
                    case Selector.Ten:
                        if (i.Ten.Equals((string)x)) kq.Them(i);
                        break;
                    case Selector.Hang:
                        if (i.Hang.Equals((string)x)) kq.Them(i);
                        break;
                    case Selector.TocDo:
                        if (i.TocDo.Equals((int)x)) kq.Them(i);
                        break;
                }
            return kq;
        }

        public void Xoa(int vt) => collection.RemoveAt(vt);


        public void XoaTheoPTu(object x)
        {
            List<Vehicle> kq = TimKiem(x).collection;
            foreach (var i in kq)
                collection.Remove(i);
        }
        /* public int TinhTongNhienLieu()
         {
             int kq = 0;
             foreach (var i in collection)
                 switch (LoaiThuocTinh)
                 {
                     case Loai.Car:
                         if (i is Car) kq += i.NhienLieu;
                         break;
                     case Loai.Ship:
                         if (i is Ship) kq += i.NhienLieu;
                         break;
                     case Loai.Submarine:
                         if (i is Submarine) kq += i.NhienLieu;
                         break;
                     case Loai.Seaplane:
                         if (i is Seaplane) kq += i.NhienLieu;
                         break;
                 }
             return kq;
         }*/

        public void CheckVehicle(string vehicle)
        {
            int dem = 0;
            foreach (var i in collection)
            {
                if (i.Loai.ToString() == vehicle)
                    dem++;
            }
            if (dem > 0)
                Console.WriteLine("Ton tai " + vehicle + "trong danh sach");
            else Console.WriteLine("Khong ton tai " + vehicle + "trong danh sach");
        }
        public int DemPT(string pt)
        {
            int kq = 0;
            foreach (var i in collection)
                if (i.Loai.ToString() == pt)
                    kq++;
            return kq;
        }



        public int TinhTongPT()
        {
            int kq = 0;
            foreach (var i in collection)
                kq++;
            return kq;
            //return collection.count;
        }
        public float TocDoCaoNhat()
        {
            float speed = 0;
            foreach (var i in collection)
                if (i.TocDo > speed)
                    speed = i.TocDo;
            return speed;
        }

        public DanhSachPhuongTien TimPTCoTocDoCaoNhat()
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var i in collection)
                if (i.TocDo == TocDoCaoNhat())
                    kq.Them(i);
            return kq;
        }
        public int NhienLieuThapNhat()
        {
            int nhienlieu = collection[0].NhienLieu;
            foreach (var i in collection)
                if (i.NhienLieu < nhienlieu)
                    nhienlieu = i.NhienLieu;
            return nhienlieu;
        }

        public DanhSachPhuongTien TimPTCoNhienLieu()
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var i in collection)
                if (i.NhienLieu == NhienLieuThapNhat())
                    kq.Them(i);
            return kq;
        }
        public DanhSachPhuongTien TimPTNhanhNhatTheoLoai()
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var i in collection)
                switch (LoaiThuocTinh)
                {
                    case Loai.Car:
                        if (i is Car && i.TocDo.Equals(TocDoCaoNhat())) kq.Them(i);
                        break;
                    case Loai.Ship:
                        if (i is Ship && i.TocDo.Equals(TocDoCaoNhat())) kq.Them(i);
                        break;
                    case Loai.Submarine:
                        if (i is Submarine && i.TocDo.Equals(TocDoCaoNhat())) kq.Them(i);
                        break;
                    case Loai.Seaplane:
                        if (i is Seaplane && i.TocDo.Equals(TocDoCaoNhat())) kq.Them(i);
                        break;
                }
            return kq;
        }

        public DanhSachPhuongTien TimPTTieuThuItNhienLieuNhatTheoLoai()
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var i in collection)
                switch (LoaiThuocTinh)
                {
                    case Loai.Car:
                        if (i is Car && i.NhienLieu.Equals(NhienLieuThapNhat())) kq.Them(i);
                        break;
                    case Loai.Ship:
                        if (i is Ship && i.NhienLieu.Equals(NhienLieuThapNhat())) kq.Them(i);
                        break;
                    case Loai.Submarine:
                        if (i is Submarine && i.NhienLieu.Equals(NhienLieuThapNhat())) kq.Them(i);
                        break;
                    case Loai.Seaplane:
                        if (i is Seaplane && i.NhienLieu.Equals(NhienLieuThapNhat())) kq.Them(i);
                        break;
                }
            return kq;
        }

        public float TinhTongKm(float thoiGian)
        {
            float kq = 0;
            foreach (var i in collection)
            {
                kq += i.TocDo / 60;
            }
            return kq * thoiGian;
        }

        public int NhienLieuCaoNhat()
        {
            int nhienlieu = 0;
            foreach (var i in collection)
                if (i.NhienLieu > nhienlieu)
                    nhienlieu = i.NhienLieu;
            return nhienlieu;
        }

        public DanhSachPhuongTien TimPTTieuThuNhieuNhienLieuNhatTheoLoai()
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var i in collection)
                switch (LoaiThuocTinh)
                {
                    case Loai.Car:
                        if (i is Car && i.NhienLieu.Equals(NhienLieuCaoNhat())) kq.Them(i);
                        break;
                    case Loai.Ship:
                        if (i is Ship && i.NhienLieu.Equals(NhienLieuCaoNhat())) kq.Them(i);
                        break;
                    case Loai.Submarine:
                        if (i is Submarine && i.NhienLieu.Equals(NhienLieuCaoNhat())) kq.Them(i);
                        break;
                    case Loai.Seaplane:
                        if (i is Seaplane && i.NhienLieu.Equals(NhienLieuCaoNhat())) kq.Them(i);
                        break;
                }
            return kq;
        }

        public float TinhTBTocDo(string tt)
        {
            float count = 0;
            float tocdo = 0;
            foreach (var i in collection)
            {
                if (i.Loai.ToString().Equals(tt))
                {
                    tocdo = i.TocDo;
                    count++;
                }
            }
            return tocdo / count;
        }


        public DanhSachPhuongTien LocPTTheoTocDo(int x, int y)
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var i in collection)
                if (i.TocDo < y && i.TocDo > x)
                    kq.Them(i);
            return kq;
        }

        public DanhSachPhuongTien LocPTTCoTheBayTHeoNguongNhienLieu(int x, int y)
        {
            DanhSachPhuongTien kq1 = new DanhSachPhuongTien();
            DanhSachPhuongTien kq = LocPTTheoNhienLieu(x, y);
            foreach (var i in kq.collection)
                if (i is IFlyable)
                    kq1.Them(i);
            return kq1;
        }
        public DanhSachPhuongTien LocPTTheoNhienLieu(int x, int y)
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var i in collection)
                if (i.NhienLieu < y && i.NhienLieu > x)
                    kq.Them(i);
            return kq;
        }
        /* public void BaoCao()
         {
             switch (LoaiThuocTinh)
             {
                 case Loai.Car:
                     Console.WriteLine("Car");
                     Console.Write("So luong: ");
                     DemPT("Car");
                     Console.Write("\nToc do trung binh: ");
                     TinhTBTocDo("Car");
                     break;
                 case Loai.Ship:
                     Console.WriteLine("Ship");
                     Console.Write("So luong: ");
                     DemPT("Ship");
                     Console.Write("\nToc do trung binh: ");
                     TinhTBTocDo("Ship");
                     break;
                 case Loai.Submarine:
                     Console.WriteLine("Submarine");
                     Console.Write("So luong: ");
                     DemPT("Submarine");
                     Console.Write("\nToc do trung binh: ");
                     TinhTBTocDo("Submarine");
                     break;
                 case Loai.Seaplane:
                     Console.WriteLine("Seaplane");
                     Console.Write("So luong: ");
                     DemPT("Seaplane");
                     Console.Write("\nToc do trung binh: ");
                     TinhTBTocDo("Seaplane");
                     break;
             }
         }*/
        public void BaoCao()
        {
            Console.WriteLine("Car");
            Console.Write("So luong: " + DemPT("Car"));
            Console.WriteLine("\nToc do trung binh: " + TinhTBTocDo("Car"));
            Console.WriteLine("Ship");
            Console.Write("So luong: " + DemPT("Ship"));
            Console.WriteLine("\nToc do trung binh: ");
            TinhTBTocDo("Ship");
            Console.WriteLine("Submarine");
            Console.Write("So luong: " + DemPT("Submarine"));
            Console.WriteLine("\nToc do trung binh: " + TinhTBTocDo("Submarine"));
            Console.WriteLine("Seaplane");
            Console.Write("So luong: " + DemPT("Seaplane"));
            Console.WriteLine("\nToc do trung binh: " + TinhTBTocDo("Seaplane"));
        }


        public DanhSachPhuongTien LocPTTCoTheLaiTHeoNguongTocDo(int x, int y)
        {
            DanhSachPhuongTien kq1 = new DanhSachPhuongTien();
            DanhSachPhuongTien kq = LocPTTheoTocDo(x, y);
            foreach (var i in kq.collection)
                if (i is IDriveable)
                    kq1.Them(i);
            return kq1;
        }

        public DanhSachPhuongTien LocPTTheoKhoangCach(int x, int y, int thoiGian)
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            float temp = 0;
            foreach (var i in collection)
            {
                temp = i.TocDo / thoiGian;
                if (temp < y && temp > x)
                    kq.Them(i);
            }
            return kq;
        }

        public float TimTocDoTHapNhat()
        {
            float tocdo = collection[0].TocDo;
            foreach (var i in collection)
            {
                if (i.TocDo < tocdo)
                    tocdo = i.TocDo;
            }
            return tocdo;
        }
        public DanhSachPhuongTien TimDSPTCoTOcDoThapNhatTheoLoai(string tt)
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            float min = TimTocDoTHapNhat();
            foreach (var i in collection)
                if (i.Loai.ToString().Equals(tt) && i.TocDo == min) kq.Them(i);
            return kq;
        }
        public int TinhTongMucNhienLieu()
        {
            int kq = 0;
            foreach (var i in collection)
                kq += i.NhienLieu;
            return kq;
        }
        public float TinhTongNhienLieuTheoLoai(string tt)
        {
            float kq = 0;
            foreach (var i in collection)
                if (i.Loai.ToString().Equals(tt)) kq += i.NhienLieu; ;
            return kq;
        }


    }
}