using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiXe
{
    public  class Motorcycle:Vehicle,IMotorcycle
    {
        public string Loai {  get; set; }
        public void TangToc()
        {
            TocDo += 5;
            Console.WriteLine("\nDang tang toc!!!");
            Console.WriteLine("Toc do tang len 5. Toc do hien tai : " + TocDo);
        }
        public void GiamToc()
        {
            TocDo -= 5;
            Console.WriteLine("\nDang giam toc!!");
            Console.WriteLine("Toc do giam xuong  5. Toc do hien tai : " + TocDo);
        }
        public Motorcycle()
        {
        }
        public Motorcycle(string t)
        {
            string[] s = t.Split(',');
            Loai = s[0];
            Ten = s[1];
            TocDo = int.Parse(s[2]);
        }
        public override string ToString()
        {
            return string.Format("Loai xe :Motorcycle\nTen xe : {1}\nTocDo : {2}\n", "Motorcycle", Ten, TocDo);
        }


    }
}
