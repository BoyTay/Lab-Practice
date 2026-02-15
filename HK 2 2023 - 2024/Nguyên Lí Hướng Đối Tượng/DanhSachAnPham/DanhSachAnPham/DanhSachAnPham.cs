using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;

namespace DanhSachAnPham
{
    public enum Select
    {
        GiaTien,
        NhaXuatBan,
        Ten,
        SoTrang,
        DiaChi,
    }
    public class DanhSachAnPham
    {
       List<IAnPham> collection= new List<IAnPham>();
       public  Select ThuocTinh {  get; set; }
       public void DocFile (string filename)
       {
            StreamReader sr = new StreamReader (filename);
            IAnPham x = null;
            string line;
            while ((line=sr.ReadLine())!=null)
            {
                string[] s = line.Split(',');
                string type = s[0];
                string ten = s[1];
                string nhaXuatBan = s[2];
                float giaTien = float.Parse(s[3]);
                if (type=="Sach")
                {
                    int soTrang = int.Parse(s[4]);
                    x = new Sach(giaTien, nhaXuatBan, ten, soTrang);
                }
                if (type=="Tap chi")
                {
                    string diaChi = s[4];
                    x=new TapChi(giaTien,nhaXuatBan,ten, diaChi);
                }
                Them(x);

            }
       }
        public void Them(IAnPham anPham)
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
        public int Compare(IAnPham x,IAnPham y)
        {
            switch(ThuocTinh)
            {
                case Select.Ten:
                    return y.Ten.CompareTo(x.Ten);
                default:
                    return 0;

            }                
        }
        public void SapXep()
        {
            collection.Sort(Compare);
        }
        public float TimGiaTienMax()
        {
            float max = collection[0].GiaTien;
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i].GiaTien>max)
                {
                    max= collection[i].GiaTien;
                }
            }
            return max;
        }
        public DanhSachAnPham TimAnPhamGiaMax(float giaTien) 
        {
            DanhSachAnPham kq=new DanhSachAnPham();
            foreach (var item in collection)
            {
                if (item.GiaTien==giaTien)
                {
                    kq.Them(item);
                }
            }
            return kq;

        }
       
    }
}
