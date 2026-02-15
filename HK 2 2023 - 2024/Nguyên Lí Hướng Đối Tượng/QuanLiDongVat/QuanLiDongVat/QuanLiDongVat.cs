using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;


namespace QuanLiDongVat
{
    public class QuanLiDongVat
    {
        List<IAnimal> collection = new List<IAnimal>();
        IAnimal x = null;
        public void DocFile(string filename)
        {
            
            StreamReader sr = new StreamReader("data.txt");
            string s = "";
           
            while ((s = sr.ReadLine()) != null)
            {
                string[] t = s.Split(',');
                if (t[0] == "Bat")
                {
                    x = new Bat(s);
                }
                else if (t[0] == "Lion")
                {
                    x = new Lion(s);
                }
                else if (t[0] == "Bird")
                {
                    x = new Bird(s);
                }
                collection.Add(x);
            }
        }
        public void Xuat()
        {
            foreach (var i in collection)
            {
                Console.WriteLine(i);
            }
        }
        public void Them(IAnimal x)
        {
            collection.Add(x);
        }

        public int DemSLDVLion()
        {
            return collection.Count(x => x is Lion);
        }
        public int DemSLDVBat()
        {
            return collection.Count(x => x is Bat);
        }
        public int DemSLDVBird()
        {
            return collection.Count(x => x is Bird);
        }
        public int DemSLDVBietBay()
        {
            return collection.Count(x => x is IFlyable);
        }
        public int DemSLDVKhongBietBay()
        {
            return collection.Count(x => !(x is IFlyable));
        }
        public int DemSLDVKhongBietBayTheoTen(string ten)
        {
            return collection.Count(x => x.Name == ten && !(x is IFlyable));
        }
        public int DemSLDVKhongBietBayTheoTuoi(int tuoi)
        {
            return collection.Count(x => x.Age==tuoi && !(x is IFlyable));
        }
        public int DemSLDVBietBayTheoTen(string ten)
        {
            return collection.Count(x => x.Name == ten && (x is IFlyable));
        }
        public int DemSLDVBietBayTheoTuoi(int tuoi)
        {
            return collection.Count(x => x.Age == tuoi && (x is IFlyable));
        }     
        public int DemDVTheoLoai(string Species)
        {
            int count = 0;
            foreach (var a in collection)
            {
                if (a.Species == Species)
                {
                    count++;
                }
            }
            return count;
        }
        public List<string> TenDV()
        {
            var list = new List<string>();
            foreach (var a in collection)
            {
                if (!list.Contains(a.Species))
                {
                    list.Add(a.Species);
                }
            }
            return list;
        }
        public Dictionary<string, int> DanhSachDV()
        {
            Dictionary<string, int> animals = new Dictionary<string, int>();
            foreach (var i in TenDV())
            {
                animals[i] = DemDVTheoLoai(i);
            }

            return animals;
        }
        public string TimDongVatCoSoLuongNhieuNhat()
        {
            int max = 0;
            string species = "";
            Dictionary<string, int> Animals = DanhSachDV();
            foreach (var a in TenDV())
            {
                if (Animals[a] > max)
                {
                    max = Animals[a];
                    species = a;
                }
            }
            return species;
        }
        public string TimDongVatCoSoLuongItNhat()
        { 
            int min = int.MaxValue;
            string species = "";
            Dictionary<string, int> Animals = DanhSachDV();
            foreach (var a in TenDV())
            {
                if (Animals[a] < min)
                {
                    min = Animals[a];
                    species = a;
                }
            }
            return species;

        }
        public List<IAnimal> TimAllDongVatBat()
        {
            List<IAnimal> kq = new List<IAnimal>();
            foreach (var i in collection)
                if (i is Bat)
                    kq.Add(i);
            return kq;
        }

        public List<IAnimal> TimAllDongVatBird()
        {
            List<IAnimal> kq = new List<IAnimal>();
            foreach (var i in collection)
                if (i is Bird)
                    kq.Add(i);
            return kq;
        }

        public List<IAnimal> TimAllDongVatLion()
        {
            List<IAnimal> kq = new List<IAnimal>();
            foreach (var i in collection)
                if (i is Lion)
                    kq.Add(i);
            return kq;
        }
        public void DanhSachList(List<IAnimal> x)
        {
            foreach (var i in x)
            {
                Console.WriteLine(i);
            }
        }
        public QuanLiDongVat TimLoaiDV(string loai)
        {
            QuanLiDongVat result =new QuanLiDongVat();
            foreach (var i in collection)
            {
                if (loai.ToLower() == "bat")
                    if (i is Bat) result.Them(i);
                if (loai.ToLower() == "bird")
                    if (i is Bird) result.Them(i);
                if (loai.ToLower() == "lion")
                    if (i is Lion) result.Them(i);
            }
            return result;
        }
        public List<IAnimal> TimAllDVCoTenDaiNhat()
        {
            List<IAnimal> result = new List<IAnimal>();
            int lengthNameMax = collection.Max(x => x.Name.Length);
            foreach (var i in collection)
                if (i.Name.Length == lengthNameMax)
                    result.Add(i);
            return result;
        }
        public List<IAnimal> TimAllDVCoTenNganNhat()
        {
            List<IAnimal> result = new List<IAnimal>();
            int lengthNameMax = collection.Min(x => x.Name.Length);
            foreach (var i in collection)
                if (i.Name.Length == lengthNameMax)
                    result.Add(i);
            return result;
        }
        public List<IAnimal> TimAllDVCoTuoiLonNhat()
        {
            List<IAnimal> kq = new List<IAnimal>();
            int maxAge = collection.Max(x => x.Age);

            foreach (var i in collection)
            {
                if (i.Age == maxAge) 
                {
                    kq.Add(i);
                }
            }

            return kq;
        }

        public List<IAnimal> TimAllDVCoTuoiNhoNhat()
        {
            List<IAnimal> kq = new List<IAnimal>();
            int minAge = collection.Min(x => x.Age);
            foreach (var i in collection)
                if (i.Age == minAge)
                    kq.Add(i);
            return kq;
        }
        public List<IAnimal> TimDVCoTenDaiNhatTheoLoai(string loai)
        {

            QuanLiDongVat result = TimLoaiDV(loai);
            return result.TimAllDVCoTenDaiNhat();
        }
        public List<IAnimal> TimDVCoTenNganNhatTheoLoai(string loai)
        {
            QuanLiDongVat result = TimLoaiDV(loai);
            return result.TimAllDVCoTenNganNhat();
        }
        public List<IAnimal> TimAllDVCoTuoiLonNhatTheoLoai(string loai)
        {

            QuanLiDongVat kq = TimLoaiDV(loai);
            return kq.TimAllDVCoTuoiLonNhat();
        }
        public List<IAnimal> TimAllDVCoTuoiNhoNhatTheoLoai(string loai)
        {
            QuanLiDongVat kq = TimLoaiDV(loai);
            return kq.TimAllDVCoTuoiNhoNhat();
        }
        public List<IAnimal> DanhSachDVBietBay()
        {
            List<IAnimal> result = new List<IAnimal>();
            foreach (var i in collection)
            {
                if(i is IFlyable)
                {
                    result.Add(i);
                }
            }
            return result;
        }
        public List<IAnimal> DanhSachDVKhongBietBay() 
        {
             List<IAnimal> result= new List<IAnimal>();
            foreach (var i in collection)
            {
                if (!(i is IFlyable))
                {
                    result.Add(i);
                }
            }
            return result;
        }
        public void SapSepDVTangTheoTen()
        {
            var tangTheoTen = collection.OrderBy(x => x.Name);
            foreach (var i in tangTheoTen)
            {
                Console.WriteLine(i);
            }
        }
        public void SapSepDVGiamTheoTen()
        {
            var giamTheoTen = collection.OrderByDescending(x => x.Name);
            foreach (var i in giamTheoTen)
            {
                Console.WriteLine(i);
            }
        }
        public void SapSepDVTangTheoTuoi()
        {
            var tangTheoTuoi = collection.OrderBy(x => x.Age);
            foreach (var i in tangTheoTuoi)
            {
                Console.WriteLine(i);
            }
        }
        public void SapSepDVGiamTheoTuoi()
        {
            var giamTheoTuoi = collection.OrderByDescending(x => x.Age);
            foreach (var i in giamTheoTuoi)
            {
                Console.WriteLine(i);
            }
        }
        public void XoaAllDVTheoLoai(string loai)
        {
            if (loai.ToLower() == "bat")
                collection.RemoveAll(x => x is Bat);
            else if (loai.ToLower() == "bird")
                collection.RemoveAll(x => x is Bird);
            else if (loai.ToLower()== "lion")
                collection.RemoveAll(x => x is Lion);
        }
        public void XoaAllDVBietBay()
        {

            collection.RemoveAll(x => x is IFlyable);
        }

        public void XoaAllDVKhongBietBay()
        {
            collection.RemoveAll(x => !(x is IFlyable));
        }
        public void XoaAllDVBietBayTheoTenTuoi(string ten, int tuoi)
        {
            collection.RemoveAll(x => (x is IFlyable) && ten.ToLower() == x.Name.ToLower() && tuoi == x.Age);
        }

        public void XoaAllDVKhongBietBayTheoTenTuoi(string ten, int tuoi)
        {
            collection.RemoveAll(x => !(x is IFlyable) && ten.ToLower() == x.Name.ToLower() && tuoi == x.Age);
        }
        public void XoaAllDVCoTuoiLonNhat()
        {

            int ageMax = collection.Max(x => x.Age);

            collection.RemoveAll(x => x.Age == ageMax);
        }

        public void XoatAllDVCoTuoiNhoNhat()
        {
            int ageMin = collection.Min(x => x.Age);

            collection.RemoveAll(x => x.Age == ageMin);
        }
        public void XoaAllDVTheoLoaiCoTuoiNhoNhat(string loai)
        {
            int ageMin = TimLoaiDV(loai).collection.Min(x => x.Age);
            if (loai.ToLower() == "bat")
                collection.RemoveAll(x => x is Bat && x.Age == ageMin);
            else if (loai.ToLower() == "bird")
                collection.RemoveAll(x => x is Bird && x.Age == ageMin);
            else if (loai.ToLower() == "lion")
                collection.RemoveAll(x => x is Lion && x.Age == ageMin);
        }
        public void XoaAllDVTheoLoaiCoTuoiLonNhat(string loai)
        {
            int ageMax = TimLoaiDV(loai).collection.Max(x => x.Age);
            if (loai.ToLower() == "bat")
                collection.RemoveAll(x => x is Bat && x.Age == ageMax);
            else if (loai.ToLower() == "bird")
                collection.RemoveAll(x => x is Bird && x.Age == ageMax);
            else if (loai.ToLower() == "lion")
                collection.RemoveAll(x => x is Lion && x.Age == ageMax);
        }
        public void XoaDVTaiViTriX(int x)
        {
            collection.RemoveAt(x-1);
        }
        public int TinhTongTuoiTheoLoai(string loai)
        {
            QuanLiDongVat result = TimLoaiDV(loai);
            return result.collection.Sum(x => x.Age);
        }
        public int TinhTongTuoiDVBietBay()
        {
            List<IAnimal> tong =DanhSachDVBietBay ();
            return tong.Sum(x => x.Age);
        }

        public int TinhTongTuoiDVKoBietBay()
        {
            List<IAnimal> tong =DanhSachDVKhongBietBay();
            return tong.Sum(x => x.Age);
        }
        public void ThemVaoViTri(int x, IAnimal animal)
        {         
            collection.Insert(x, animal);
        }
        public void HienThiDSTangGiamTenTuoi()
        {
            Console.WriteLine("Sap xep giam theo ten ten");
            SapSepDVGiamTheoTen();
            Console.WriteLine("Sap xep giam theo ten tuoi");
            SapSepDVGiamTheoTuoi();
            Console.WriteLine("Sap xep tang theo ten ten");
            SapSepDVTangTheoTen();
            Console.WriteLine("Sap xep tang theo ten tuoi");
            SapSepDVTangTheoTuoi();
        }
        public void HienThiDSNhomBatBirdLion()
        {
            QuanLiDongVat dsBat = TimLoaiDV("Bat");
            Console.WriteLine("Dong vat thuoc loai Bat tang theo ten");
            dsBat.Xuat();

            QuanLiDongVat dsBird = TimLoaiDV("Bird");
            Console.WriteLine("Dong vat thuoc loai Bird tang theo ten");
            dsBird.Xuat();

            QuanLiDongVat dsLion = TimLoaiDV("Lion");
            Console.WriteLine("Dong vat thuoc loai Bat tang theo ten");
            dsLion.Xuat();
        }
        public void HienThiDSNhomBirdBatLionTangTheoTen()
        {
            

            QuanLiDongVat dsBat = TimLoaiDV("Bat");
            Console.WriteLine("Sap xep dv thuoc loai Bat tang theo ten");
            Console.WriteLine("Tang dan !! ");
            dsBat.SapSepDVTangTheoTen();
            Console.WriteLine("Giam dan !! ");
            dsBat.SapSepDVGiamTheoTen();

            QuanLiDongVat dsBird = TimLoaiDV("Bird");
            Console.WriteLine("Sap xep dv thuoc loai Bird tang theo ten");
            Console.WriteLine("Tang dan !! ");
            dsBird.SapSepDVTangTheoTen();
            Console.WriteLine("Giam dan !! ");
            dsBird.SapSepDVGiamTheoTen();

            QuanLiDongVat dsLion = TimLoaiDV("Lion");
            Console.WriteLine("Sap xep dv thuoc loai Lion tang theo ten");
            Console.WriteLine("Tang dan !! ");
            dsLion.SapSepDVTangTheoTen();
            Console.WriteLine("Giam dan !! ");
            dsLion.SapSepDVGiamTheoTen();

        }

    }   
}
