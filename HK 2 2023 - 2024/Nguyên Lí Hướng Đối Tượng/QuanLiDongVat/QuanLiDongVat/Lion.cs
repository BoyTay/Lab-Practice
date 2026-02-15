using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDongVat
{
    public class Lion : IAnimal // có thuộc tính Breed,2 phương thức Speak,Eat
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Species { get; set; }
        public Lion() { }
        public void Speak()
        {
            Console.WriteLine("Grum");
        }      
        public Lion(string t)
        {
            string[] s = t.Split(',');
            Species = s[0];
            Name = s[1];
            Age = int.Parse(s[2]);

        }
        public override string ToString()
        {
            return string.Format("Loai:Lion\nTen:{1}\nTuoi:{2}\n", "Lion", Name, Age);
        }
    }
}
