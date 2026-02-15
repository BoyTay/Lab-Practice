using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCacDoiTuongHinhHoc
{
    public class Circle : Shape // Định nghĩa lớp Circle kế thừa từ lớp Shape
    {
        private double radius; // Khai báo một biến riêng tư để lưu bán kính của hình tròn

        // Hàm khởi tạo của lớp Circle, nhận bán kính làm đối số
        public Circle(double radius)
        {
            this.radius = radius; // Gán giá trị bán kính được truyền vào cho biến radius
        }

        // Phương thức tính diện tích của hình tròn, ghi đè phương thức từ lớp cơ sở Shape
        public override double Area()
        {
            return Math.PI * radius * radius; // Trả về diện tích của hình tròn dựa trên công thức PI * r^2
        }

        // Phương thức tính chu vi của hình tròn, ghi đè phương thức từ lớp cơ sở Shape
        public override double Perimeter()
        {
            return 2 * Math.PI * radius; // Trả về chu vi của hình tròn dựa trên công thức 2 * PI * r
        }

        // Phương thức vẽ hình tròn, ghi đè phương thức từ lớp cơ sở Shape
        public override void Draw()
        {
            Console.WriteLine("Ve hinh tron....");
        }
        public Circle(string tb)
        {
            string[] s = tb.Split(',');      
            radius = int.Parse(s[1]);
        }
        public override string ToString()
        {
            return string.Format("Circle!!\nRadius: {1}\n Area: {2}\n Perimeter: {3}\n","Circle",radius,Area(),Perimeter());
        }
    }
}    
