using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuanLiXe
{
    public  class Car:Vehicle,ICar
    {
        public int SoChoNgoi { get; set; }
        public string Loai {  get; set; }
        public void DongCua()
        {
            if (SoChoNgoi > 7)
            {
                SoChoNgoi = 7;
            }
            else
            {
                SoChoNgoi = 0;
            }
            Console.WriteLine("\nDang dong cua!!!");
            Console.WriteLine("So cho ngoi duoc dong cua.So cho ngoi hien tai : " + SoChoNgoi);
        }
       public void MoCua()
        {
             Console.WriteLine("Dang mo cua");
        }
        public Car()
        {
        }
        public Car(string t)
        {
            string[] s = t.Split(',');
            Loai = s[0];
            Ten = s[1];
            TocDo = int.Parse(s[2]);
            SoChoNgoi = int.Parse(s[3]);
        }
        public override string ToString()
        {
            return string.Format("Loai xe : Car\nTen xe : {1}\nTocDo : {2}\nSo cho ngoi : {3}\n","Car",Ten,TocDo,SoChoNgoi);
        }

    }
}
