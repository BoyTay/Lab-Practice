using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

namespace QuanLiAnPham
{
    public enum Select
    {
        Nam,
        NhaXuatBan,
        TuaDe,
        So,
        Tap,
        ISBN,
        TacGia,
    }
    public class DanhSachAnPham
    {

        List<AnPham> collection =new List<AnPham>();
        public Select ThuocTinh { get; set; }
        public void DocFile(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            AnPham x = null;
            string line;
            while ((line=sr.ReadLine())!=null)
            {
                string[] s = line.Split(',');
                string type = s[0];
                int Nam = int.Parse(s[1]);
                string NhaXuatBan = s[2];
                string TuaDe = s[3];                      
                if (s[0]=="Sach")
                {
                    string ISBN = s[4];
                    string TacGia = s[5];
                    x = new Sach(Nam, NhaXuatBan, TuaDe, ISBN, TacGia);
                }
                else if (s[0]=="Tap Chi")
                {
                    int So = int.Parse(s[4]);
                    int Tap = int.Parse(s[5]);
                    x =new TapChi(Nam,NhaXuatBan,TuaDe,So,Tap);
                }
                Them(x);
            }
        }
        public void Them(AnPham anPham)
        {
            collection.Add(anPham);
        }
        public void Xuat()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(new string('-', 82));
            sb.AppendLine($"{"Nam",-5} | {"Nha Xuat Ban",-15} | {"Tua De",-21} | {"ISBN/So",-15} | {"Tac Gia/Tap"}  | ");
            sb.AppendLine(new string('-', 82));
            foreach (var item in collection)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        public void Xoa(object x)
        {
            for (int i=collection.Count-1;i>-0;i--)
            {
                var obj = collection[i];
                switch(ThuocTinh)
                {
                    case Select.Nam:
                        if(obj.Nam==(int)x)
                        {
                            collection.RemoveAt(i);
                        }
                        break;
                    case Select.NhaXuatBan:
                        if (obj.NhaXuatBan.Equals(x.ToString(),StringComparison.OrdinalIgnoreCase))
                        {
                            collection.RemoveAt(i);
                        }
                        break;
                    case Select.TuaDe:
                        if (obj.TuaDe.Equals(x.ToString(),StringComparison.OrdinalIgnoreCase))
                        {
                            collection.RemoveAt(i);
                        }
                        break;
                    case Select.So:
                        if (obj is TapChi tc && tc.So==(int)x)
                        {
                            collection.RemoveAt(i);
                        }
                        break;
                    case Select.Tap:
                        if (obj is TapChi tc1 && tc1.Tap==(int)x)
                        {
                            collection.RemoveAt(i);
                        }
                        break;
                    case Select.ISBN:
                        if(obj is Sach s && s.ISBN.Equals(x.ToString(),StringComparison.OrdinalIgnoreCase))
                        {
                            collection.RemoveAt(i);
                        }
                        break;
                    case Select.TacGia:
                        if (obj is Sach s1 && s1.TacGia.Equals(x.ToString(),StringComparison.OrdinalIgnoreCase))
                        {
                            collection.RemoveAt(i);
                        }
                        break;
                }             
            }
        }
        public void NhapThuCong()
        {
            Console.Write("Nhap an pham (Sach,Tap Chi) : ");
            string type=Console.ReadLine();
            Console.Write("Nhap nam: ");
            int nam=int.Parse(Console.ReadLine());
            Console.Write("Nhap nha xuat ban : ");
            string nhaXB=Console.ReadLine();
            Console.Write("Nhap tua de : ");
            string tuaDe=Console.ReadLine();
            if (type=="Sach")
            {
                Console.Write("Nhap isbn : ");
                string isbn=Console.ReadLine();
                Console.Write("Nhap tac gia : ");
                string tacGia=Console.ReadLine();
                Sach s=new Sach(nam,nhaXB,tuaDe,isbn,tacGia);
                Them(s);
            }
            else if (type=="Tap Chi")
            {
                Console.Write("Nhap so : ");
                int so=int.Parse(Console.ReadLine());
                Console.Write("Nhap tap : ");
                int tap=int.Parse(Console.ReadLine());
                TapChi tc=new TapChi(nam,nhaXB,tuaDe,so,tap);   
                Them(tc);
            }
        }
        public DanhSachAnPham TimKiem(object x)
        {
            DanhSachAnPham kq = new DanhSachAnPham();
            foreach (var obj in collection)
            {           
                switch (ThuocTinh)
                {
                    case Select.Nam:
                        if (obj.Nam == (int)x)
                        {
                            kq.Them(obj);
                        }
                        break;
                    case Select.NhaXuatBan:
                        if (obj.NhaXuatBan.Equals(x.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            kq.Them(obj);
                        }
                        break;
                    case Select.TuaDe:
                        if (obj.TuaDe.Equals(x.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            kq.Them(obj);
                        }
                        break;
                    case Select.So:
                        if (obj is TapChi tc && tc.So == (int)x)
                        {
                            kq.Them(obj);
                        }
                        break;
                    case Select.Tap:
                        if (obj is TapChi tc1 && tc1.Tap == (int)x)
                        {
                            kq.Them(obj);
                        }
                        break;
                    case Select.ISBN:
                        if (obj is Sach s && s.ISBN.Equals(x.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            kq.Them(obj);
                        }
                        break;
                    case Select.TacGia:
                        if (obj is Sach s1 && s1.TacGia.Equals(x.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            kq.Them(obj);
                        }
                        break;
                }
            }
            return kq;
        }
        public int Compare(AnPham x, AnPham y)
        {
            switch(ThuocTinh)
            {
                case Select.Nam:
                    return x.Nam.CompareTo(y.Nam);
                case Select.NhaXuatBan:
                    return x.NhaXuatBan.CompareTo(y.NhaXuatBan);
                case Select.TuaDe:
                    return x.TuaDe.CompareTo(y.TuaDe);
                case Select.So:
                    return (x as TapChi).So.CompareTo((y as TapChi).So);
                case Select.Tap:
                    return (x as TapChi).Tap.CompareTo((y as TapChi).Tap);
                case Select.ISBN:
                    return (x as Sach).ISBN.CompareTo((y as Sach).ISBN);
                case Select.TacGia:
                    return (x as Sach).TacGia.CompareTo((y as Sach).TacGia);
                default:
                    return 0;
            }
        }
        public void SapXep()
        {
            collection.Sort(Compare);
        }
        public void CapNhatSach(Sach sach)
        {
            for (int i = 0;i<collection.Count;i++) 
            {
                if (collection[i] is Sach s && s.TuaDe.Equals(sach.TuaDe.ToString(),StringComparison.OrdinalIgnoreCase))
                {
                    collection[i] = sach; 
                    break;
                }            
            }
        }
        public void CapNhatTapChi(TapChi tapChi) 
        {
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i] is TapChi tc && tc.TuaDe.Equals(tapChi.TuaDe.ToString(),StringComparison.OrdinalIgnoreCase))
                {
                    collection[i]=tapChi; 
                    break;
                }
            }


        }

    }
    
   
        
    
}
