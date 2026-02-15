using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCacDoiTuongHinhHoc
{
    public class Triangle : Shape
    {      
        private double height;
        private int edge1;
        private int edge2;
        private int edge3;
        public Triangle( double height,int edge1,int edge2,int edge3)
        {    
            this.height = height;
            this.edge1 = edge1;
            this.edge2 = edge2;
            this.edge3 = edge3;
        }
        public override double Area()
        {
            return (edge1 * height) / 2;
        }
        public override double Perimeter()
        {
            return edge1 + edge2 + edge3;
        }
        public override void Draw()
        {
            Console.WriteLine("Ve hinh tam giac...");
        }
        public Triangle(string tb)
        {
            string[] s = tb.Split(',');
            height = int.Parse(s[1]);
            edge1 = int.Parse(s[2]);
            edge2 = int.Parse(s[3]);
            edge3 = int.Parse(s[4]);
        }
        public override string ToString()
        {
            return string.Format("Triangle!!\nHeight: {1}\n edge1: {2}\n edge2: {3}\n edge3: {4}\n Area: {5}\n Perimeter: {6}\n", "Triangle",height,edge1,edge2,edge3, Area(), Perimeter());
        }
    }
}

