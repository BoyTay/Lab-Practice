using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace De2_2312616_PhanTrungHieu
{
    public enum Select
    {
        Ho,
        Ten,
        NhanVienID,
        Phong,
    }
    public class DanhSachNhanVien
    {

        List<QuanLy> collection = new List<QuanLy>();

        public Select ThuocTinh { get; set; }
        public void DocFile(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            QuanLy x = null;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] s = line.Split(',');
                string ho = s[0];
                string ten = s[1];
                int nhanVienID = int.Parse(s[2]);
                string phong = s[3];
                x = new QuanLy(ho, ten, nhanVienID, phong);
                Them(x);
            }

        }
        public void Them(QuanLy quanLy)
        {
            collection.Add(quanLy);
        }
        public void Xuat()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(new string('-', 35));
            sb.AppendLine($"{"Ho",-8} | {"Ten",-5} | {"ID",-8} | {"Phong"}|");
            sb.AppendLine(new string('-', 35));
            foreach (var item in collection)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        public void NhapThuCong()
        {
            Console.Write("Nhap ho : ");
            string ho = Console.ReadLine();
            Console.Write("Nhap ten : ");
            string ten = Console.ReadLine();
            Console.Write("Nhap ID : ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nhap phong : ");
            string phong = Console.ReadLine();
            QuanLy x = new QuanLy(ho, ten, id, phong);
            Them(x);
        }
        public DanhSachNhanVien TimKiem(object x)
        {
            DanhSachNhanVien kq = new DanhSachNhanVien();
            foreach (var obj in collection)
            {
                switch (ThuocTinh)
                {
                    case Select.Ho:
                        if (obj.Ho.Equals(x.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            kq.Them(obj);
                        }
                        break;
                    case Select.Ten:
                        if (obj.Ten.Equals(x.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            kq.Them(obj);
                        }
                        break;
                    case Select.NhanVienID:
                        if (obj.NhanVienID == (int)x)
                        {
                            kq.Them(obj);
                        }
                        break;
                    case Select.Phong:
                        if (obj.Phong.Equals(x.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            kq.Them(obj);
                        }
                        break;
                }
            }
            return kq;
        }
        public int Compare(QuanLy x, QuanLy y)
        {
            switch (ThuocTinh)
            {
                case Select.Ho:
                    return x.Ho.CompareTo(y.Ho);
                case Select.Ten:
                    return x.Ten.CompareTo(y.Ten);
                case Select.NhanVienID:
                    return x.NhanVienID.CompareTo(y.NhanVienID);
                case Select.Phong:
                    return x.Phong.CompareTo(y.Phong);
                default:
                    return 0;
            }
        }
        public void SapXep()
        {
            collection.Sort(Compare);
        }
        public void Xoa(object x)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                var obj = collection[i];
                switch (ThuocTinh)
                {
                    case Select.Ho:
                        if (obj.Ho.Equals(x.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            collection.RemoveAt(i);
                        }
                        break;
                    case Select.Ten:
                        if (obj.Ten.Equals(x.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            collection.RemoveAt(i);
                        }
                        break;
                    case Select.NhanVienID:
                        if (obj.NhanVienID == (int)x)
                        {
                            collection.RemoveAt(i);
                        }
                        break;
                    case Select.Phong:
                        if (obj.Phong.Equals(x.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            collection.RemoveAt(i);
                        }
                        break;
                }
            }
        }
        public void CapNhatQuanLy(QuanLy quanLy)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i] is QuanLy ql && ql.NhanVienID == quanLy.NhanVienID)
                {
                    collection[i] = quanLy;
                    break;
                }
            }
        }
    }
}
