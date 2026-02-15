using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuanLiCacDoiTuongHinhHoc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Shape hTron=new Circle(5);
            //Shape hVuong=new Rectangle(4,6);
            //Shape hChuNhat = new Rectangular(5, 10);
            //Shape hTamGiac = new Triangle(8, 1, 2, 3);
            //Console.WriteLine("Class hinh tron!!");
            //Console.WriteLine("Dien tich hinh tron: "+hTron.Area());
            //Console.WriteLine("Chu vi hinh tron: "+hTron.Perimeter());
            //hTron.Draw();
            //Console.WriteLine("\nClass hinh vuong!!");
            //Console.WriteLine("Dien tich hinh vuong: "+hVuong.Area());
            //Console.WriteLine("Chu vi hinh vuong: "+hVuong.Perimeter());
            //hVuong.Draw();
            //Console.WriteLine("\nClass hinh chu nhat!!");
            //Console.WriteLine("Dien tich hinh chu nhat: " + hChuNhat.Area());
            //Console.WriteLine("Chu vi hinh chu nhat: " + hChuNhat.Perimeter());
            //hChuNhat.Draw();
            //Console.WriteLine("\nClass hinh tam giac!!");
            //Console.WriteLine("Dien tich hinh tam giac: " + hTamGiac.Area());
            //Console.WriteLine("Chu vi hinh tam giac: " + hTamGiac.Perimeter());
            //hTamGiac.Draw();
            List<Shape> DSHinhHoc = new List<Shape>();
            StreamReader sr = new StreamReader("data.txt");
            string s = "";
            Shape a = null;
            while ((s = sr.ReadLine()) != null)
            {
                string[] t = s.Split(',');
                if (t[0] == "Rectangle")
                {
                    a = new Rectangle(s);
                }
                else if (t[0] == "Circle")
                {
                    a = new Circle(s);
                }
                else if (t[0] == "Rectangular")
                {
                   a = new Rectangular(s);
                }
                else if (t[0]=="Triangle")
                {
                    a = new Triangle(s);
                }
                DSHinhHoc.Add(a);          
            }
            foreach (Shape i in DSHinhHoc)
            {
                Console.WriteLine(i);
            }


            Console.ReadKey();
        }
    }
}
