using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace KTTHU
{
    public enum SeLect
    {
        Ten,
        GiaTien,
    }
    public class DanhSachAnPham:IComparer<IAnPham>
    {
        List<IAnPham> collection =new List<IAnPham>();
        public SeLect ThuocTinh { get; set; }
        public IAnPham this[int index]
        {
            get
            {
                return collection[index];
            }
            set
            {
                collection[index] = value;
            }
        }
        public void DocFile(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            string line;
            IAnPham x=null;
            while ((line=sr.ReadLine())!=null)
            {
                string[] s = line.Split(',');
                string type = s[0];
                string ten = s[1];
                string nhaxuatban = s[2];
                float giatien = float.Parse(s[3]);

                if (s[0]=="Sach")
                {
                    int sotrang = int.Parse(s[4]);
                    x = new Sach(giatien, nhaxuatban, ten, sotrang);
                }
                else if (s[0]=="Tap chi")
                {
                    string diachi = s[4];
                    x=new TapChi(nhaxuatban,ten,giatien,diachi);
                }
                else if (s[0]=="Truyen tranh")
                {
                    x = new TruyenTranh(giatien, nhaxuatban, ten);
                }
                Them(x);
              
            }
        }
        public void Them (IAnPham anPham)
        {
            collection.Add(anPham);
        }
        public override string ToString()
        {
           StringBuilder sb = new StringBuilder();
            foreach (var item in collection)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        public void Xuat()
        {
            Console.WriteLine(this);
        }
        public float TimGiaMaxAP()
        {
            float max = collection[0].GiaTien;
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i].GiaTien>max)
                {
                    max = collection[i].GiaTien;
                }
            }
            return max;
        }
        public DanhSachAnPham TimAnPhamGiaTienMax(float giatien)
        {
            DanhSachAnPham kq = new DanhSachAnPham();
            foreach (var item in collection)
            {
                if (item.GiaTien==giatien)
                {
                    kq.Them(item);
                }
            }
            return kq;
        }
        public int Compare(IAnPham x,IAnPham y) 
        { 
            switch(ThuocTinh)
            {
                case SeLect.Ten:
                    return x.Ten.CompareTo(y.Ten);
                case SeLect.GiaTien:
                    return x.GiaTien.CompareTo(y.GiaTien);
                default:
                    return 0;
            } 
        
        }
        public void SapXep()
        {
            collection.Sort(Compare);
        }
        public DanhSachAnPham TimTruyenTranh(string nhaXuatBan)
        {
            DanhSachAnPham kq = new DanhSachAnPham();
            foreach (var item in collection)
            {
                if (item is TruyenTranh tt && tt.NhaXuatBan.Equals(nhaXuatBan.ToString(),StringComparison.OrdinalIgnoreCase))
                {
                    kq.Them(item);

                }
            }
            return kq;
            
        }
        public DanhSachAnPham TimAPCoGiaTienLonHon(float y)
        {
            DanhSachAnPham kq=new DanhSachAnPham();
            foreach (var item in collection)
            {
                if (item.GiaTien>y)
                {
                    kq.Them(item);
                }
            }
            return kq;
        }




    }
}
