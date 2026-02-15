
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    public enum Selector
    {
        Ten,
        Tuoi,
        DiaChi,
        Luong,
        MaNhanVien,
        ViTri,
        Phong
    }

    public class QuanLyNhanVien : IComparer<Nguoi>
    {
        List<Nguoi> collection = new List<Nguoi>();

        public Selector ThuocTinh { get; set; }

        //public Nguoi this[int index]
        //{
        //    get { return collection[index]; }
        //    set { collection[index] = value; }
        //}

        public void DocFile(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            string line;
            NhanVien  temp = null;
            while ((line = sr.ReadLine()) != null)
            {
                string[] s = line.Split(',');
                string type = s[0];
                string diaChi = s[1];
                string ten = s[2];
                int tuoi = int.Parse(s[3]);
                decimal luong = decimal.Parse(s[4]);
                string maNhanVien = s[5];
                string viTri = s[6];
                string phong = s[7];

                if (s[0] == "Nhan Vien")
                {
                   temp = new NhanVien(luong, maNhanVien, viTri, diaChi, ten, tuoi);
                }
                else if (s[0] == "Quan Ly")
                {
                   temp = new QuanLy(phong, luong, maNhanVien, viTri, diaChi, ten, tuoi);
                }

                Them(temp);

            }
        }

        public void Them(Nguoi nguoi)
        {
            collection.Add(nguoi);
        }

        //public void Xoa(int vt)
        //{
        //    collection.RemoveAt(vt);
        //}
        public void Xoa(object x)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                var obj = collection[i];
                switch (ThuocTinh)
                {
                    case Selector.Ten:
                        if (obj.Ten.Equals(x.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            collection.RemoveAt(i);
                        }
                        break;
                    case Selector.DiaChi:
                        if (obj.DiaChi.Equals(x.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            collection.RemoveAt(i);
                        }
                        break;
                    case Selector.Tuoi:
                        if (obj.Tuoi == (int)x)
                        {
                            collection.RemoveAt(i);
                        }
                        break;
                    case Selector.ViTri:
                        if (obj is NhanVien nv1 && nv1.ViTri.Equals(x.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            collection.RemoveAt(i);
                        }
                        break;
                    case Selector.Luong:
                        if (obj is NhanVien nv2 && nv2.Luong==(decimal)x)
                        {
                            collection.RemoveAt(i);
                        }
                        break;
                    case Selector.MaNhanVien:
                        if (obj is NhanVien nv3 && nv3.MaNhanVien.Equals(x.ToString(),StringComparison.OrdinalIgnoreCase))
                        {
                            collection.RemoveAt(i);
                        }
                        break;
                    case Selector.Phong:
                        if(obj is QuanLy ql && ql.Phong.Equals(x.ToString(), StringComparison.OrdinalIgnoreCase)) 
                        {
                            collection.RemoveAt(i);
                        }
                        break;
                }
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
            sb.AppendLine($"| {"Ho Ten",-15} | {"Tuoi",-5} | {"DiaChi",-10} | {"Luong ($)",-11} | {"MaNV",-10} | {"Vi Tri",-25} | {"Phong"}");
            sb.AppendLine(new string('-', 100));
            foreach (var item in collection)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        //1.	Phương thức nhập thủ công
        public void NhapThongTinThuCong()
        {
            Console.Write("Nhập Người (Nhan Vien, Quan Ly):");
            string type = Console.ReadLine();

            Console.Write("Nhập tên:");
            string ten = Console.ReadLine();

            Console.Write("Nhập tuổi:");
            int tuoi = int.Parse(Console.ReadLine());

            Console.Write("Nhập địa chỉ:");
            string diaChi = Console.ReadLine();

            if (type == "Nhan Vien" || type == "Quan Ly")
            {
                Console.Write("Nhập lương:");
                decimal luong = decimal.Parse(Console.ReadLine());

                Console.Write("Nhập mã nhân viên:");
                string maNhanVien = Console.ReadLine();

                Console.Write("Nhập vị trí:");
                string viTri = Console.ReadLine();

                if (type == "Quan Ly")
                {
                    Console.Write("Nhập phòng:");
                    string phong = Console.ReadLine();

                    QuanLy quanLy = new QuanLy(phong, luong, maNhanVien, viTri, diaChi, ten, tuoi);
                    Them(quanLy);
                }
                else
                {
                    NhanVien nhanVien = new NhanVien(luong, maNhanVien, viTri, diaChi, ten, tuoi);
                    Them(nhanVien);
                }
            }
        }

        // tìm kiếm
        public QuanLyNhanVien TimKiem(object x)
        {
            QuanLyNhanVien kq = new QuanLyNhanVien();
            foreach (var obj in collection)
            {
                switch (ThuocTinh)
                {
                    case Selector.Ten:
                        if (obj.Ten.Equals(x.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            kq.Them(obj);
                        }
                        break;
                    case Selector.Tuoi:
                        if (obj.Tuoi == (int)x)
                        {
                            kq.Them(obj);
                        }
                        break;
                    case Selector.DiaChi:
                        if (obj.DiaChi.Equals(x.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            kq.Them(obj);
                        }
                        break;
                    case Selector.Luong:
                        if (obj is NhanVien nv && nv.Luong == (decimal)x)
                        {
                            kq.Them(obj);
                        }
                        break;
                    case Selector.MaNhanVien:
                        if (obj is NhanVien nv1 && nv1.MaNhanVien.Equals(x.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            kq.Them(obj);
                        }
                        break;
                    case Selector.ViTri:
                        if (obj is NhanVien nv2 && nv2.ViTri.Equals(x.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            kq.Them(obj);
                        }
                        break;
                    case Selector.Phong:
                        if (obj is QuanLy ql && ql.Phong.Equals(x.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            kq.Them(obj);
                        }
                        break;
                }
            }
            return kq;
        }

        // Sắp xếp
        public void HoanVi(int a, int b)
        {
            Nguoi temp = collection[a];
            collection[a] = collection[b];
            collection[b] = temp;
        }

        public void SapXep()
        {
            //for (int i = 0; i < collection.Count - 1; i++)
            //{
            //    for (int j = i + 1; j < collection.Count; j++)
            //    {
            //        if (Compare(this[i], this[j]) > 0)
            //            HoanVi(i, j);
            //    }
            //}
            collection.Sort(Compare);
        }

        public int Compare(Nguoi x, Nguoi y)
        {

            switch (ThuocTinh)
            {
                case Selector.Ten:
                    return x.Ten.CompareTo(y.Ten);
                case Selector.Tuoi:
                    return x.Tuoi.CompareTo(y.Tuoi);
                case Selector.DiaChi:
                    return x.DiaChi.CompareTo(y.DiaChi);
                case Selector.Luong:
                    return (x as NhanVien).Luong.CompareTo((y as NhanVien).Luong);
                case Selector.MaNhanVien:
                    return (x as NhanVien).MaNhanVien.CompareTo((y as NhanVien).MaNhanVien);
                case Selector.ViTri:
                    return (x as NhanVien).ViTri.CompareTo((y as NhanVien).ViTri);
                case Selector.Phong:
                    return (x as QuanLy).Phong.CompareTo((y as QuanLy).Phong);
                default:
                    return 0;
            }
        }

        //public void CapNhat(int vt, object thongTinMoi)
        //{
        //    //Nguoi nguoi = collection[vt];
        //    Nguoi nguoi = this[vt];
        //    switch (ThuocTinh)
        //    {
        //        case Selector.Ten:
        //            nguoi.Ten = thongTinMoi.ToString();
        //            break;
        //        case Selector.Tuoi:
        //            nguoi.Tuoi = (int)thongTinMoi;
        //            break;
        //        case Selector.DiaChi:
        //            nguoi.DiaChi = thongTinMoi.ToString();
        //            break;
        //        case Selector.Luong:
        //            (nguoi as NhanVien).Luong = (decimal)thongTinMoi;
        //            break;
        //        case Selector.MaNhanVien:
        //            (nguoi as NhanVien).MaNhanVien = thongTinMoi.ToString();
        //            break;
        //        case Selector.ViTri:
        //            (nguoi as NhanVien).ViTri = thongTinMoi.ToString();
        //            break;
        //        case Selector.Phong:
        //            (nguoi as QuanLy).Phong = thongTinMoi.ToString();
        //            break;
        //        default:
        //            break;
        //    }
        //    this[vt] = nguoi;

        //}
        public void CapNhatQuanLy(QuanLy quanLy)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i] is QuanLy ql && ql.MaNhanVien.Equals (quanLy.MaNhanVien.ToString(),StringComparison.OrdinalIgnoreCase))
                {
                    collection[i] = quanLy;
                    break;
                }
                
            }
        }
        public void CapNhatNhanVien(NhanVien nhanVien) 
        {
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i] is NhanVien nv1 && nv1.MaNhanVien.Equals(nhanVien.MaNhanVien.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    collection[i] = nhanVien;
                    break;

                }
                   
            }
        }

    }
}
