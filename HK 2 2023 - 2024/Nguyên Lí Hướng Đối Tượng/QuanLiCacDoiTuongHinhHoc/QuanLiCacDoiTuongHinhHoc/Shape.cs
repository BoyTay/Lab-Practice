using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCacDoiTuongHinhHoc
{
    public abstract class Shape // Định nghĩa lớp trừu tượng Shape
    {
        public abstract double Area(); // Phương thức trừu tượng Area để tính diện tích
        public abstract double Perimeter(); // Phương thức trừu tượng Perimeter để tính chu vi

        public virtual void Draw() // Phương thức ảo Draw để vẽ hình
        {
            Console.WriteLine("Ve hinh....."); // In ra màn hình thông báo mặc định khi vẽ hình
        }
    }
}

