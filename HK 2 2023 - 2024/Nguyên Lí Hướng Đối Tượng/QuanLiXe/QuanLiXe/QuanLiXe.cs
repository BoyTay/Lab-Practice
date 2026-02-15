using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiXe
{
    public  class QuanLiXe
    {
        List<IVehicle> collection = new List<IVehicle>();
        IVehicle x = null;
       
        public void DocFile(string filename)
        {

            StreamReader sr = new StreamReader("data.txt");
            string s = "";

            while ((s = sr.ReadLine()) != null)
            {
                string[] t = s.Split(',');
                if (t[0] =="Car")
                {
                    x = new Car(s);
                }
                else if (t[0] == "Motorcycle")
                {
                    x = new Motorcycle(s);
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
        public void Them(IVehicle x)
        {
            collection.Add(x);
        }
        public int DemSLCar()
        {
            return collection.Count(x => x is Car);
        }
        public int DemSLMotorcycle()
        {
            return collection.Count(x => x is Motorcycle);
        }
        public int DemSLCarVaMotorcycle()
        {
            return collection.Count(x => x is Car && x is Motorcycle);
        }
        public int DemSLCarHoacMotorcycle()
        {
            return collection.Count(x => x is Car || x is Motorcycle);
        }
        public int DemSLTheoTen(string ten)
        {
            return collection.Count(x => x.Ten.ToLower() == ten.ToLower());
        }
        public int DemSoChoNgoi(int soChoNgoi)
		{
            return collection.Count(x =>
            {
                if (x is Car) return ((Car)x).SoChoNgoi == soChoNgoi;
                return false;
            });
		}
        public int DemSLTheoTocDo(int tocDo)
		{
            return collection.Count(x => x.TocDo == tocDo);
		}
        public int DemSLTheoTenSoChoNgoi(string ten,int soChoNgoi)
		{
            return collection.Count(x =>
            {
                if (x is Car) return ((Car)x).SoChoNgoi == soChoNgoi && (x.Ten.ToLower() == ten.ToLower());
                return false;
            });           
		}
        public int DemSLTheoTenTocDo(string ten,int tocdo)
        {
            return collection.Count(x => x.Ten.ToLower() == ten.ToLower() && x.TocDo == tocdo);                      
        }
        public int DemSLTheoSoChoNgoiTocDo(int soChoNgoi, int tocDo)
        {
            return collection.Count(x =>
            {
                if (x is Car) return ((Car)x).SoChoNgoi == soChoNgoi && x.TocDo == tocDo;
                return false;
            });
        }
        public int DemSLTheoTenSoChoNgoiTocDo(string ten,int tocDo,int soChoNgoi)
        {
            return collection.Count(x =>
            {
                if (x is Car) return ((Car)x).SoChoNgoi == soChoNgoi && x.TocDo == tocDo && x.Ten.ToLower() == ten.ToLower();
                return false;
            });
        }
        public int DemXeTenDaiNhat()
        {
            int maxXe = collection.Max(x => x.Ten.Length);
            return collection.Count(x => x.Ten.Length == maxXe);
        }
        public int DemXeTenNganNhat()
        {
            int minXe = collection.Min(x => x.Ten.Length);
            return collection.Count(x => x.Ten.Length == minXe);
        }
        public int DemXeSoChoNgoiLonNhat()
        {
            int maxChoNgoi = collection.Max(x => {
                if (x is Car)
                    return ((Car)x).SoChoNgoi;
                return 0;
            });
            return collection.Count(x =>x is Car && ((Car)x).SoChoNgoi == maxChoNgoi);
        }
        public int DemXeSoChoNgoiItNhat()
        {
            int minChoNgoi = collection
            .OfType<Car>() // Lọc các đối tượng là Car
            .Select(car => car.SoChoNgoi) // Chọn ra số chỗ ngồi
            .DefaultIfEmpty(0) // Nếu không có Car nào thì trả về 0
            .Min();
            return  collection
            .OfType<Car>() // Lọc các đối tượng là Car
            .Count(car => car.SoChoNgoi == minChoNgoi); // Đếm số lượng Car có số chỗ ngồi bằng minChoNgoi
        }
        public int DemXeTocDoLonNhat()
        {
            int maxTocDo = collection.Max(x => x.TocDo);         
            return collection.Count(x=>x.TocDo==maxTocDo);
        }
        public int DemXeTocDoNhoNhat()
        { 
          int minTocDo =collection.Min(x => x.TocDo);
          return collection.Count(x=>x.TocDo== minTocDo);
        }
        //7.Tìm tất cả phương tiện theo loại kết hợp
        public List<IVehicle> TimDSCar()
        {
            List<IVehicle> kq = new List<IVehicle>();
            foreach (var i in collection)
                if (i is Car)
                    kq.Add(i);
            return kq;
        }
        public void DanhSachList(List<IVehicle> x)
        {
            foreach (var i in x)
            {
                Console.WriteLine(i);
            }
        }
        public List<IVehicle> TimDSMotorcycle()
        {
            List<IVehicle> kq = new List<IVehicle>();
            foreach(var i in collection)
            {
                if (i is Motorcycle)
                    kq.Add(i);
            }
            return kq;
        }
        public List<IVehicle> TimDSCarHoacMotorcycle()
        {
            List<IVehicle> kq = new List<IVehicle>();
            foreach (var i in collection)
            {
                if(i is Car || i is Motorcycle )
                {
                    kq.Add(i);
                }
            }
            return kq;
        }
        public List<IVehicle> TimDSCarVaMotorcycle()
        {
            List<IVehicle> kq = new List<IVehicle>();
            foreach(var i in collection)
            {
                if (i is Car && i is Motorcycle)
                {
                    kq.Add(i);
                }
            }
            return kq;
        }
        public List<IVehicle> TimDSTheoTen(string tenXe)
        {
            List<IVehicle> kq = new List<IVehicle>();
            foreach( var i in collection)
            {
                if(i.Ten.ToLower() ==tenXe.ToLower())
                {
                    kq.Add(i);
                }
            }
            return kq;
        }
        public List<IVehicle> TimDSTheoSoChoNgoi(int soChoNgoi)
        {
            List<IVehicle> kq = new List<IVehicle>();
            foreach(var i in collection)
            {
                if (i is Car && ((Car)i).SoChoNgoi==soChoNgoi)
                {
                    kq.Add(i);
                }
            }
            return kq;
        }
        public List<IVehicle> TimDSTheoTocDo(int tocDo)
        {
            List<IVehicle> kq = new List<IVehicle>();
            foreach(var i in collection)
            {
                if(i.TocDo == tocDo)
                {
                    kq.Add(i);
                }
            }
            return kq;
        }
        public List<IVehicle> TimDSTheoTenSoChoNgoi(string tenXe,int soChoNgoi)
        {
            List<IVehicle> kq = new List<IVehicle>();
            foreach(var i in collection)
            {
                if(i.Ten.ToLower()==tenXe.ToLower() && ( i is Car && ((Car)i).SoChoNgoi==soChoNgoi))
                {
                    kq.Add(i);
                }
            }
            return kq;
        }
        public List<IVehicle> TimDSTheoTenTocDo(string tenXe,int tocDo)
        {
            List<IVehicle> kq = new List<IVehicle>();
            foreach(var i in collection)
            {
                if(i.Ten.ToLower()==tenXe.ToLower() && (i.TocDo==tocDo))
                {
                    kq.Add(i);
                }
            }                 
            return kq;
        }
        public List<IVehicle> TimDSTheoSoChoNgoiTocDo(int soChoNgoi,int tocDo)
        {
            List<IVehicle> kq = new List<IVehicle>();

            foreach (var i in collection)
            {
                
                if (i is Car car)
                {
                   
                    if (car.SoChoNgoi == soChoNgoi && car.TocDo == tocDo)
                    {
                        kq.Add(i);
                    }
                }
            }

            return kq;
        }
        public List<IVehicle> TimDSTheoTenSoChoNgoiTocDo(string tenXe,int soChoNgoi,int tocDo)
        {
            return collection
         .Where(x => x is Car car && car.SoChoNgoi == soChoNgoi && car.TocDo == tocDo && car.Ten.ToLower() == tenXe.ToLower())
         .ToList();                             
        }
        public List<IVehicle> TimXeCoTenDaiNhat()
        {
            List<IVehicle> kq=new List<IVehicle>();
            int lengthNameMax=collection.Max(x=>x.Ten.Length);
            foreach (var i in collection)
            {
                if(i.Ten.Length==lengthNameMax)
                { 
                    kq.Add(i); 
                }
            }
            return kq;
        }
        public List<IVehicle> TimXeCoTenNganNhat()
        {
            List<IVehicle> kq=new List<IVehicle> ();
            int lengthNameMin=collection.Min(x=>x.Ten.Length);
            foreach (var i in collection)
            {
                if (i.Ten.Length ==lengthNameMin)
                {
                    kq .Add(i);
                }
            }
            return kq;
        }
        public List<IVehicle> TimXeCoSoChoNgoiLonNhat()
        {
            List<IVehicle> kq = new List<IVehicle>();      
            int seatMax = collection.OfType<Car>().Max(car => car.SoChoNgoi);       
            foreach (var i in collection)
            {
                if (i is Car car && car.SoChoNgoi == seatMax)
                {
                    kq.Add(car);
                }
            }
            return kq;
        }
        public List<IVehicle> TimXeCoSoChoNgoiItNhat()
        {
            List<IVehicle> kq = new List<IVehicle>();
            int seatMin = collection.OfType<Car>().Min(car => car.SoChoNgoi);
            foreach (var i in collection)
            {
                if(i is Car car)
                {
                   if(car.SoChoNgoi==seatMin) 
                        kq .Add(i);
                }
            }
            return kq;
        }
        public List<IVehicle> TimXeCoTocDoLonNhat()
        {
            List<IVehicle> kq=new List<IVehicle>();
            int speedMax = collection.Max(x => x.TocDo);
            foreach (var i in collection)
            {
                if(i.TocDo==speedMax)
                {
                    kq.Add(i);
                }
            }
            return kq;
        }
        public List<IVehicle> TimXeCoTocDoNhoNhat()
        {
            List<IVehicle> kq = new List<IVehicle>();
            int speedMin=collection.Min(x=>x.TocDo);
            foreach (var i in collection)
            {
                if(i.TocDo==speedMin)
                {
                    kq.Add(i);
                }
            }
            return kq;
        }

    }
}
