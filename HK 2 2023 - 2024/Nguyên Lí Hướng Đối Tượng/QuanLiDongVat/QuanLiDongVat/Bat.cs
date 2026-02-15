using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDongVat
{
    public class Bat : IAnimal, IFlyable // có thuộc tính Breed,2 phương thức Speak,Eat
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Species { get; set; }
        public Bat()
        {
        }      
        public Bat(string t)
        {
            string[] s = t.Split(',');
            Species = s[0];
            Name = s[1];
            Age = int.Parse(s[2]);

        }
        public void Speak()
        {
            Console.WriteLine("Chit chit");
        }

        public void Fly()
        {
            Console.WriteLine("Doi dang bay");
        }

        public override string ToString()
        {
            return string.Format("Loai:Bat\nTen:{1}\nTuoi:{2}\n", "Bat", Name, Age);
        }
    }
}
