using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCacDoiTuongHinhHoc
{
    public class Rectangle:Shape
    {
        private double length;
        private double width;
        public Rectangle(double length)
        {
            this.length = length;
            
        }
        public override double Area()
        {
            return length*length;
        }
        public override double Perimeter()
        {
            return length*4;
        }
        public override void Draw()
        {
            Console.WriteLine("Ve hinh vuong...");
        }
        public Rectangle(string tb)
        {
            string[] s = tb.Split(',');         
            length = int.Parse(s[1]);
           
        }
        public override string ToString()
        {
            return string.Format("Rectangle!!\n Lenght: {1}\n Area: {2}\n Perimeter: {3}\n", "Rectangle", length, Area(), Perimeter());
        }

    }
}
