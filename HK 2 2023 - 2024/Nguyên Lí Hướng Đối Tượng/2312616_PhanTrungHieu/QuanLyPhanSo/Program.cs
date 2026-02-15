using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Numerics;

namespace QuanLyPhanSo
{
    class Program
    {
        static void Main(string[] args)
        {
            PhanSo a = new PhanSo();
            a.Xuat();
            PhanSo b = new PhanSo(3, 4);
            b.Xuat();
            PhanSo c = new PhanSo(4, 5);
            c.Xuat();
            PhanSo d = new PhanSo(5, 6);
            d.Xuat();
            PhanSo e = new PhanSo(6, 7);
            e.Xuat();
            Console.Write("Cong phan so thu nhat va phan so thu hai: ");
            PhanSo x = a.Cong(a, b);
            x.RutGon().Xuat();
            Console.Write("Tru phan so thu nhat va phan so thu hai: ");
            PhanSo y = a.Tru(a, b);
            y.RutGon().Xuat();
            Console.Write("Nhan phan so thu hai va phan so thu ba: ");
            PhanSo z = a.Nhan(b, c);
            z.RutGon().Xuat();
            Console.Write("Chia phan so thu hai va phan so thu ba: ");
            PhanSo m = a.Chia(b, c);
            m.RutGon().Xuat();
            Console.Write("Toan tu + : ");
            PhanSo q = b + c;
            q.RutGon().Xuat();
            Console.Write("Toan tu - : ");
            PhanSo p = b - c;
            p.RutGon().Xuat();
            Console.Write("Toan tu * : ");
            PhanSo l = b * c;
            l.RutGon().Xuat();
            Console.Write("Toan tu / : ");
            PhanSo v = b / c;
            v.RutGon().Xuat();

        }
    }
    class PhanSo
    {
        public int tu;
        public int mau;

        public PhanSo()
        {
            mau = 1;
        }
        public PhanSo(int t, int m)
        {
            tu = t;
            mau = m;
        }
        public PhanSo Cong(PhanSo a, PhanSo b)
        {
            PhanSo kq = new PhanSo();
            kq.tu = a.tu * b.mau + a.mau * b.tu;
            kq.mau = a.mau * b.mau;
            return kq;
        }
        public PhanSo Tru(PhanSo a, PhanSo b)
        {
            PhanSo kq = new PhanSo();
            kq.tu = a.tu * b.mau - a.mau * b.tu;
            kq.mau = a.mau * b.mau;
            return kq;
        }
        public PhanSo Nhan(PhanSo a, PhanSo b)
        {
            PhanSo kq = new PhanSo();
            kq.tu = a.tu * b.tu;
            kq.mau = a.mau * b.mau;
            return kq;
        }
        public PhanSo Chia(PhanSo a, PhanSo b)
        {
            PhanSo kq = new PhanSo();
            kq.tu = a.tu * b.mau;
            kq.mau = a.mau * b.tu;
            return kq;
        }
        public PhanSo RutGon()
        {
            int UCMax = UCLN(tu, mau);
            tu /= UCMax;
            mau /= UCMax;
            return this;
        }
        static int UCLN(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            return a.Cong(a, b);
        }
        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            return a.Tru(a, b);
        }
        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            return a.Nhan(a, b);
        }
        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            return a.Chia(a, b);
        }

        public void Xuat()
        {
            Console.WriteLine($"{tu}/{mau}");
        }
    }
}