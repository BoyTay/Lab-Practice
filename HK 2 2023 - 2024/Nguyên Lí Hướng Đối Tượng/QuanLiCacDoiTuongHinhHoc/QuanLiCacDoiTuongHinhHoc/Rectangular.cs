using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCacDoiTuongHinhHoc
{
     public class Rectangular:Shape
    {
        private double length;
        private double width;
        public Rectangular(double length, double width)
        {
            this.length = length;
            this.width = width;
        }
        public override double Area()
        {
            return length*width;
        }
        public override double Perimeter()
        {
            return (length+width)*2;
        }
        public override void Draw()
        {
            Console.WriteLine("Ve hinh chu nhat...");
        }
        public Rectangular(string tb)
        {
            string[] s = tb.Split(',');
            length = int.Parse(s[1]);
            width = int.Parse(s[2]);
        }
        public override string ToString()
        {
            return string.Format("Rectangular!!\n Lenght: {1}\n Width: {2}\n Area: {3}\n Perimeter: {4}\n", "Rectangular", length,width, Area(), Perimeter());
        }
    }
}

